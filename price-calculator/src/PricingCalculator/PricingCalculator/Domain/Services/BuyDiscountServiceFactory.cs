namespace PricingCalculator.Domain.Services
{
    public class BuyDiscountServiceFactory : IBuyDiscountServiceFactory
    {
        public IBuyGetDiscountService Beans() => new BuyGetDiscountService("Beans", 2, "Bread", 0.5);
    }
}