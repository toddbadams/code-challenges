namespace Simulator.Repositories
{
    public interface ISecretsRepository
    {
        string BlobStorageConnectionString { get; }
    }
}