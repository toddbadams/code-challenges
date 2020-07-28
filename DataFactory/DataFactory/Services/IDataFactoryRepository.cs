using System.Threading.Tasks;

namespace DataFactory
{
    public interface IDataFactoryRepository
    {
        void CreateDataFactory();
        bool IsPendingCreation();
        void CreateLinkedService();
        void CreateDataSet();
        void CreatePipeline();
        Task<string> CreatePipelineRunId();
        bool IsPipelineRunInProgressOrQueued(string runId);
        object GetCopyActivityOutput(string runId);
    }
}
