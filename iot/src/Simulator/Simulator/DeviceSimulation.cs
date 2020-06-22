using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace Simulator
{
    public class DeviceSimulation
    {

        // The three connection string for the different IoT Devices being simulated (Truck, Airplane, Container)

        private static readonly string connectionString_Truck = "HostName=tba-iot-hub.azure-devices.net;DeviceId=TruckDevice;SharedAccessKey=yp2Z7keWS/MQyerSfv69LeTjTnwP2LQT6InVcD/TPUU=";
        private static readonly string connectionString_Airplane = "HostName=tba-iot-hub.azure-devices.net;DeviceId=AirplaneDevice;SharedAccessKey=kKSFolxmEex1WlceSm7YdoN93UkMW6NRoRD8BG9rU/4=";
        private static readonly string connectionString_Container = "HostName=tba-iot-hub.azure-devices.net;DeviceId=ContainerDevice;SharedAccessKey=Phbdz0RLlo92ro332MmTKWnnpCGrSFGPnPgaHLk1ARk=";


        // The DeviceClient's for the three different IoT Devices being simulated
        private static DeviceClient deviceClient_Truck;
        private static DeviceClient deviceClient_Airplane;
        private static DeviceClient deviceClient_Container;


        private static void Main(string[] args)
        {
            Console.WriteLine("Device Simulation");
            Console.WriteLine("This app simulations Temperature and Humidity sensors from the following devices:");
            Console.WriteLine(" - Container: The shipping container.");
            Console.WriteLine(" - Truck: The truck transporting the container.");
            Console.WriteLine(" - Airplain: The airplane transporting the container.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("The Container is being shipped via Truck and Airplain, and the container sensor readings will vary depending on which transport vehicle is currently transporting the container.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press Ctrl-C to exit.");
            Console.WriteLine(string.Empty);

            // Connect to the IoT hub using the MQTT protocol
            // Create a DeviceClient for each IoT Device being simulated
            deviceClient_Truck = DeviceClient.CreateFromConnectionString(connectionString_Truck, TransportType.Mqtt);
            deviceClient_Airplane = DeviceClient.CreateFromConnectionString(connectionString_Airplane, TransportType.Mqtt);
            deviceClient_Container = DeviceClient.CreateFromConnectionString(connectionString_Container, TransportType.Mqtt);

            SendDeviceToCloudMessagesAsync();

            Console.ReadLine();
        }


        // Truck transport sensor values
        const double truckTemperature_min = 20;
        const double truckTemperature_max = 40;
        static double truckTemperature = 20;
        const double truckHumidity_min = 45;
        const double truckHumidity_max = 65;
        static double truckHumidity = 60;

        // Airplane transport sensor values
        const double airplaneTemperature_min = 0;
        const double airplaneTemperature_max = 25;
        static double airplaneTemperature = 15;
        const double airplaneHumidity_min = 35;
        const double airplaneHumidity_max = 50;
        static double airplaneHumidity = 45;

        // Container sensor values
        static double containerTemperature = 20;
        static double containerHumidity = 45;
        static bool containerTransportIsTruck = true;


        // Variables used to automate the change in Transport for the Container between Truck and Airplane
        static double transportMaxDuration = 30; // 30 seconds
        static DateTime lastTransportChange = DateTime.Now;


        // Random number generator
        static Random rand = new Random();


        private static double GenerateSensorReading(double currentValue, double min, double max)
        {
            double percentage = 5; // 5%

            // generate a new value based on the previous supplied value
            // The new value will be calculated to be within the threshold specified by the "percentage" variable from the original number.
            // The value will also always be within the the specified "min" and "max" values.
            double value = currentValue * (1 + ((percentage / 100) * (2 * rand.NextDouble() - 1)));

            value = Math.Max(value, min);
            value = Math.Min(value, max);

            return value;
        }


        static string CreateJSON(double temperature, double humidity)
        {
            var telemetry = new
            {
                temperature = temperature,
                humidity = humidity
            };

            return JsonConvert.SerializeObject(telemetry);
        }

        // Generate Telemetry message containing JSON data for the specified values
        static Message CreateMessage(string messageString)
        {
            var message = new Message(Encoding.ASCII.GetBytes(messageString));

            // MESSAGE CONTENT TYPE
            message.ContentType = "application/json";
            message.ContentEncoding = "UTF-8";

            return message;
        }

        // Async method to send simulated telemetry
        private static async void SendDeviceToCloudMessagesAsync()
        {
            while (true)
            {
                // /////////////////////////////////////////////////////////////////////////////////////////////////
                // SEND SIMULATED TRUCK SENSOR TELEMETRY

                // Generate simulated Truck sensor readings
                truckTemperature = GenerateSensorReading(truckTemperature, truckTemperature_min, truckTemperature_max);
                truckHumidity = GenerateSensorReading(truckHumidity, truckHumidity_min, truckHumidity_max);

                // Create Truck JSON message
                var truckJson = CreateJSON(truckTemperature, truckHumidity);
                var truckMessage = CreateMessage(truckJson);

                // Send Truck telemetry message
                await deviceClient_Truck.SendEventAsync(truckMessage);
                Console.WriteLine("{0} > Sending TRUCK message: {1}", DateTime.Now, truckJson);


                // /////////////////////////////////////////////////////////////////////////////////////////////////
                // SEND SIMULATED AIRPLANE SENSOR TELEMETRY

                // Generate simulated Airplane sensor readings
                airplaneTemperature = GenerateSensorReading(airplaneTemperature, airplaneTemperature_min, airplaneTemperature_max);
                airplaneHumidity = GenerateSensorReading(airplaneHumidity, airplaneHumidity_min, airplaneHumidity_max);

                // Create Airplane JSON message
                var airplaneJson = CreateJSON(airplaneTemperature, airplaneHumidity);
                var airplaneMessage = CreateMessage(airplaneJson);

                // Send Airplane telemetry message
                await deviceClient_Airplane.SendEventAsync(airplaneMessage);
                Console.WriteLine("{0} > Sending AIRPLANE message: {1}", DateTime.Now, airplaneJson);


                // /////////////////////////////////////////////////////////////////////////////////////////////////
                // SEND SIMULATED CONTAINER SENSOR TELEMETRY


                // Change Transport between Truck and Airplane based on duration set
                TimeSpan transportDuration = DateTime.Now - lastTransportChange;
                if (transportDuration.TotalSeconds > transportMaxDuration)
                {
                    containerTransportIsTruck = !containerTransportIsTruck;
                    lastTransportChange = DateTime.Now;
                    Console.WriteLine("{0} > CONTAINER transport changed to: {1}", DateTime.Now, containerTransportIsTruck ? "TRUCK" : "AIRPLANE");
                }

                // Container Telemetry min/max thresholds
                double minTemperature = containerTransportIsTruck ? truckTemperature_min : airplaneTemperature_min;
                double maxTemperature = containerTransportIsTruck ? truckTemperature_max : airplaneTemperature_max;
                double minHumidity = containerTransportIsTruck ? truckHumidity_min : airplaneHumidity_min;
                double maxHumidity = containerTransportIsTruck ? truckHumidity_max : airplaneHumidity_max;

                // Generate simulated Container sensor readings
                containerTemperature = GenerateSensorReading(containerTemperature, minTemperature, maxTemperature);
                containerHumidity = GenerateSensorReading(containerHumidity, minHumidity, maxHumidity);

                // Create Container JSON message
                var containerJson = CreateJSON(containerTemperature, containerHumidity);
                var containerMessage = CreateMessage(containerJson);

                // Send Container telemetry message
                await deviceClient_Container.SendEventAsync(containerMessage);
                Console.WriteLine("{0} > Sending CONTAINER message: {1}", DateTime.Now, containerJson);

                await Task.Delay(1000);
            }
        }
    }
}