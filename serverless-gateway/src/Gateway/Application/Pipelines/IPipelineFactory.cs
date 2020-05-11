namespace Gateway.Application.Pipelines
{
    public interface IPipelineFactory
    {
        Pipeline Authorized();
    }
}