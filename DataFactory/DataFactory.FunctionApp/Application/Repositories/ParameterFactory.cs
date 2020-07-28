using System;
using System.Collections.Generic;
using DataFactory.Application.Repositories;
using DataFactory.Repositories;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace DataFactory.Services
{
    public interface IParameterFactory
    {
        Factory DataFactory();
        LinkedServiceResource LinkedServiceResource();
        DatasetResource CreateDatasetResource();
        IList<DatasetReference> DatasetReferenceList(string value);
        PipelineResource CreatePipelineResource();
        Dictionary<string, object> CreatePipelineParameters();
        RunFilterParameters FilterParameters();
        DataFactoryManagementClient CreateDataFactoryManagementClient(string accessToken);
        AuthenticationContext AuthenticationContext();
        ClientCredential ClientCredential();
    }

    public class ParameterFactory : IParameterFactory
    {
        private readonly IConfigurationRepository _configuration;
        private readonly ISecretsRepository _secrets;

        
        private const string AuthorityUrl = "https://login.windows.net/";


        public ParameterFactory(IConfigurationRepository configuration, ISecretsRepository secrets)
        {
            _configuration = configuration;
            _secrets = secrets;
        }

        public Factory DataFactory() =>
            new Factory
            {
                Location = _configuration.Region,
                Identity = new FactoryIdentity()
            };

        private SecureString LinkedServicesConnectionString() =>
            new SecureString($"DefaultEndpointsProtocol=https;AccountName={_configuration.StorageAccount};AccountKey={_secrets.StorageKey}");

        private AzureStorageLinkedService CreateAzureStorageLinkedService() =>
            new AzureStorageLinkedService
            {
                ConnectionString = LinkedServicesConnectionString()
            };

        public LinkedServiceResource LinkedServiceResource() => new LinkedServiceResource(CreateAzureStorageLinkedService());

        private AzureBlobDataset CreateAzureBlobDataset()
        {
            return new AzureBlobDataset
            {
                LinkedServiceName = new LinkedServiceReference
                {
                    ReferenceName = _configuration.StorageAccountName
                },
                FolderPath = new Expression { Value = "@{dataset().path}" },
                Parameters = new Dictionary<string, ParameterSpecification>
                {
                    {"path", new ParameterSpecification {Type = ParameterType.String}}
                }
            };
        }

        public DatasetResource CreateDatasetResource()
        {
            return new DatasetResource(
                CreateAzureBlobDataset()
            );
        }

        public IList<DatasetReference> DatasetReferenceList(string value) =>
            new List<DatasetReference>
            {
                new DatasetReference
                {
                    ReferenceName = _configuration.DatasetName,
                    Parameters = new Dictionary<string, object> {{ "path", value}}
                }
            };

        public PipelineResource CreatePipelineResource() =>
            new PipelineResource
            {
                Parameters = new Dictionary<string, ParameterSpecification>
                {
                    { "inputPath", new ParameterSpecification { Type = ParameterType.String } },
                    { "outputPath", new ParameterSpecification { Type = ParameterType.String } }
                },
                Activities = new List<Activity>
                {
                    new CopyActivity
                    {
                        Name = "CopyFromBlobToBlob",
                        Inputs = DatasetReferenceList( "@pipeline().parameters.inputPath"),
                        Outputs = DatasetReferenceList( "@pipeline().parameters.outputPath"),
                        Source = new BlobSource(),
                        Sink = new BlobSink()
                    }
                }
            };

        public Dictionary<string, object> CreatePipelineParameters() =>
            new Dictionary<string, object>
            {
                { "inputPath", _configuration.InputBlobPath },
                { "outputPath", _configuration.OutputBlobPath }
            };

        public RunFilterParameters FilterParameters() =>
            new RunFilterParameters(DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow.AddMinutes(10));

        public DataFactoryManagementClient CreateDataFactoryManagementClient(string accessToken)
        {
            return new DataFactoryManagementClient(new TokenCredentials(accessToken))
            {
                SubscriptionId = _secrets.SubscriptionId
            };
        }

        public AuthenticationContext AuthenticationContext() =>
            new AuthenticationContext(AuthorityUrl + _secrets.TenantId);

        public ClientCredential ClientCredential() =>
            new ClientCredential(_secrets.ApplicationId, _secrets.AuthenticationKey);
    }
}