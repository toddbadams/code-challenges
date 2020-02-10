using System;
using Tba.CqrsEs.Application.Interfaces;

namespace Tba.CqrsEs.Application
{
    public class IdentifierFactory : IIdentifierFactory
    {
        public string Create() => Substring(Replace(AsBase64String()),22);

        private static string AsBase64String() => Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        private static string Replace(string id) => id.Replace("/", "_").Replace("+", "-");

        private static string Substring(string id, int length) => id.Substring(0, 22);
    }
}
