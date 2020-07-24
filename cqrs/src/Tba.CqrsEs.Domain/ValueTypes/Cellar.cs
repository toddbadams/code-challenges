namespace Tba.CqrsEs.Domain.Entities
{
    public class Cellar
    {
        public Cellar(string name, string address, string accountReference)
        {
            Name = name;
            Address = address;
            AccountReference = accountReference;
        }

        public string Name { get; }
        public string Address { get; }
        public string AccountReference { get; }
    }
}
