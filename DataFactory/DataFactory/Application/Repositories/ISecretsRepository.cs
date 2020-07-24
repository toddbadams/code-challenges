namespace DataFactory.Repositories
{
    public interface ISecretsRepository
    {
        string TenantId { get; }
        string ApplicationId { get; }
        string AuthenticationKey { get; }
        string SubscriptionId { get; }
        string StorageKey { get; }
    }
}