using System;
using Tba.CqrsEs.Application.Interfaces;

namespace Tba.CqrsEs.Application
{
    public class IdentifierFactory : IIdentifierFactory
    {
        private const int LENGTH = 6;

        public string Create() => Substring(Replace(AsBase64String()));

        private static string AsBase64String() => Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        private static string Replace(string id) => id.Replace("/", "_").Replace("+", "-");

        private static string Substring(string id) => id.Substring(0, LENGTH);
    }
}
