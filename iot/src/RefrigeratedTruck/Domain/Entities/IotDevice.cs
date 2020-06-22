using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Provisioning.Client;
using Microsoft.Azure.Devices.Provisioning.Client.Transport;
using Microsoft.Azure.Devices.Shared;
using RefrigeratedTruck.Application.Configuration;
using RefrigeratedTruck.Presentation;

namespace RefrigeratedTruck.Domain.Entities
{
    /// <summary>
    /// An IoT Device interface to Azure IoT Central
    /// </summary>
    public class IotDevice
    {
        private readonly IoTDeviceConfig _config;
        public  TwinCollection Properties { get; }
        public DeviceClient Client { get; private set; }

        public IotDevice(IoTDeviceConfig config)
        {
            _config = config;
            Properties = new TwinCollection {["TruckID"] = config.DeviceId};
        }

        public async Task RegisterAsync(SecurityProviderSymmetricKey security)
        {

            using var transport = new ProvisioningTransportHandlerMqtt(TransportFallbackType.TcpOnly);
            var client =
                ProvisioningDeviceClient.Create(_config.Endpoint, _config.ScopeId, security, transport);

            var result =  await client.RegisterAsync();
            if (result.Status != ProvisioningRegistrationStatusType.Assigned)
            {
                throw new ApplicationException("Failed to register device");
            }

            IAuthenticationMethod auth = new DeviceAuthenticationWithRegistrySymmetricKey(_config.DeviceId,
                (security as SecurityProviderSymmetricKey).GetPrimaryKey());
            Client = DeviceClient.Create(result.AssignedHub, auth, TransportType.Mqtt);
        }

       public async Task SendPropertiesAsync() => await Client.UpdateReportedPropertiesAsync(Properties);


       public async Task RegisterChangeHandler() => await Client.SetDesiredPropertyUpdateCallbackAsync(HandleSettingChanged, null);


       private async Task HandleSettingChanged(TwinCollection desiredProperties, object userContext)
       {
           var setting = "OptimalTemperature";
           if (desiredProperties.Contains(setting))
           {
               BuildAcknowledgement(desiredProperties, setting);
               Truck.optimalTemperature = (int)desiredProperties[setting]["value"];
               ConsoleMessage.Green($"Optimal temperature updated: {Truck.optimalTemperature}");
           }
           await Client.UpdateReportedPropertiesAsync(Properties);
       }


       private void BuildAcknowledgement(TwinCollection desiredProperties, string setting)
       {
           Properties[setting] = new
           {
               value = desiredProperties[setting]["value"],
               status = "completed",
               desiredVersion = desiredProperties["$version"],
               message = "Processed"
           };
       }
    }
}