namespace PricingCalculator.Domain.Services
{
    public interface IBuyDiscountServiceFactory
    {
        IBuyGetDiscountService Beans();
    }
}