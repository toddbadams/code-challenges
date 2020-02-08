namespace Gateway.Application.Interfaces
{
    public interface IConfigurationProvider
    {
        string Get(string key);
    }
}