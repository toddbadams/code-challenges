using System;
using System.Text.Json;
using System.Threading;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using AzureMapsToolkit;
using AzureMapsToolkit.Common;
using RefrigeratedTruck.Application.Configuration;
using RefrigeratedTruck.Domain;
using RefrigeratedTruck.Domain.Entities;
using RefrigeratedTruck.Presentation;

namespace RefrigeratedTruck
{
    public class Program
    {
        // Azure maps 
        static AzureMapsServices _azureMapsServices;

        // IoT Central 
        static DeviceClient _sDeviceClient;
        static CancellationTokenSource _cts;

        private const string ScopeId = "0ne0010D331";
        private const string DeviceId = "RefrigeratedTruck1";
        private const string PrimaryKey = "CQswL3r82wg7+C+91wW0mspv/EEDm9jkqvfCvnXCD2Q=";
        private const string Endpoint = "global.azure-devices-provisioning.net";

        private const double StartingLat = 47.644702;
        private const double StartingLon = -122.130137;



        static void Main(string[] args)
        {
            // Connect to Azure Maps.
            _azureMapsServices = new AzureMapsServices(AzureMapsConfig.AzureMapsKey);
            var config = new IoTDeviceConfig(Endpoint, PrimaryKey, DeviceId, ScopeId);
            var truck = new Truck(_azureMapsServices,
                new Coordinate() { Longitude = StartingLon, Latitude = StartingLat }, config);



            try
            {
                using (var security = new SecurityProviderSymmetricKey(config.DeviceId, config.PrimaryKey, null))
                {
                    ConsoleMessage.Amber($"Registering IoT device. ID = {security.GetRegistrationID()}");
                    truck.RegisterAsync(security).GetAwaiter().GetResult();
                    ConsoleMessage.Green("Device successfully connected to Azure IoT Central");
                }

                truck.SendPropertiesAsync().GetAwaiter().GetResult();
                ConsoleMessage.Green($"Sent device properties: {JsonSerializer.Serialize(truck.Properties)}");

                ConsoleMessage.Amber("Register settings changed handler...");
                truck.RegisterChangeHandler().GetAwaiter().GetResult();
                ConsoleMessage.Amber("Done");

                _cts = new CancellationTokenSource();

                // Create a handler for the direct method calls.
                _sDeviceClient.SetMethodHandlerAsync("GoToCustomer", truck.CmdGoToCustomer, null).Wait();
                _sDeviceClient.SetMethodHandlerAsync("Recall", truck.CmdRecall, null).Wait();

                truck.SendTruckTelemetryAsync(_cts.Token, _sDeviceClient);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                _cts.Cancel();
            }
            catch (Exception ex)
            {
                ConsoleMessage.Red(ex.Message);
            }
        }
    }
}



