using System.Threading.Tasks;
using DataFactory.FunctionApp;
using Microsoft.Azure.Management.DataFactory.Models;

namespace DataFactory
{
    public interface IDataFactoryRepository
    {
        // todo - move to active directory repo
        Task<string> CreateAccessToken();

        Task<Factory> CreateDataFactory(DataFactoryAccess dfAccess);
        Task<bool> IsPendingCreation(DataFactoryAccess dfAccess);
        Task<LinkedServiceResource> CreateLinkedService(DataFactoryAccess dfAccess);

        void CreateDataSet(DataFactoryAccess dfAccess);
        void CreatePipeline(DataFactoryAccess dfAccess);
        Task<string> CreatePipelineRunId(DataFactoryAccess dfAccess);
        bool IsPipelineRunInProgressOrQueued(DataFactoryAccess dfAccess, string runId);
        object GetCopyActivityOutput(DataFactoryAccess dfAccess, string runId);


    }
}
