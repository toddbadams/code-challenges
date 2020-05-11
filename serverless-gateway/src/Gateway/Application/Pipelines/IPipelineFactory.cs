using Gateway.Application.Pipelines;

namespace Gateway.Application.Interfaces
{
    public interface IPipelineFactory
    {
        Pipeline Authorized();
    }
}