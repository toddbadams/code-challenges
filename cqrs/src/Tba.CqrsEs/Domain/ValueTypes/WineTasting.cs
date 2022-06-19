namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class WineTasting
    {
        public WineTasting(string id, Wine? wine, WineAppearance? wineAppearance)
        {
            Id = id;
            Wine = wine;
            WineAppearance = wineAppearance;
        }

        public string Id { get; }
        public Wine Wine { get; }
        public WineAppearance WineAppearance { get; }
    }
}