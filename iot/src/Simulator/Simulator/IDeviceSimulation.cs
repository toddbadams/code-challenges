using System.Threading.Tasks;

namespace Simulator
{
    public interface IDeviceSimulation
    {
        /// <summary>
        /// Send telemetry data to Azure IOT Hub
        /// </summary>
        /// <returns></returns>
        Task SendMessagesAsync();
    }
}