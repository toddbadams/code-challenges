namespace RefrigeratedTruck.Application.Configuration
{
    public readonly struct IoTDeviceConfig
    {
        public string ScopeId { get; }

        public string DeviceId { get; }

        public string PrimaryKey { get; }

        public string Endpoint { get; }

        public IoTDeviceConfig(string endpoint, string primaryKey, string deviceId, string scopeId)
        {
            Endpoint = endpoint;
            PrimaryKey = primaryKey;
            DeviceId = deviceId;
            ScopeId = scopeId;
        }
    }
}