using System;
using Tba.CqrsEs.Domain.Enums;

namespace Tba.CqrsEs.Domain.ValueTypes
{
    public class WineDetails
    {
        public int Vintage { get; set; }
        public int Quantity { get; set; }
        public PackSize PackSize { get; set; }
        public BottleSize BottleSize { get; set; }
        public DutyStatus DutyStatus { get; set; }
        public float UnitCost { get; set; }
        public DateTime AcquiredOn { get; set; }
        public string? AcquiredFrom { get; set; }
        public string? RotationNumber { get; set; }
        public string? Note { get; set; }
    }
}