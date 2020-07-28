namespace DataFactory.FunctionApp
{
    public readonly struct DataFactoryAccess
    {
        public DataFactoryAccess(string token, string name)
        {
            Token = token;
            Name = name;
        }

        public string Token { get; }
        public string Name { get; }
    }
}