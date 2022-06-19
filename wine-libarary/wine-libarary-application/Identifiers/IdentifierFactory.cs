using System;

namespace wine_libarary_application.Identifiers
{
    public class IdentifierFactory : IIdentifierFactory
    {
        private const int Length = 6;

        public string Create() => Substring(Replace(AsBase64String()));

        private static string AsBase64String() => Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        private static string Replace(string id) => id.Replace("/", "_").Replace("+", "-");

        private static string Substring(string id) => id.Substring(0, Length);
    }
}
