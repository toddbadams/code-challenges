namespace DataFactory.Application.Repositories
{
    public interface IConfigurationRepository
    {
        string Region { get; }
        string ResourceGroup { get; }
        string DataFactoryName { get; }
        string StorageAccountName { get; }
        string StorageAccount { get; }
        string DatasetName { get; }
        string PipelineName { get; }
        string InputBlobPath { get; }
        string OutputBlobPath { get; }
    }
}