using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class DiscountManagerStart
    {
        public decimal Calculate(decimal amount, int type, int years)
        {
            decimal result = 0;
            decimal disc = years > 5 ? (decimal)5 / 100 : (decimal)years / 100;
            if (type == 1)
            {
                result = amount;
            }
            else if (type == 2)
            {
                result = amount - 0.1m * amount - disc * (amount - 0.1m * amount);
            }
            else if (type == 3)
            {
                result = 0.7m * amount - disc * 0.7m * amount;
            }
            else if (type == 4)
            {
                result = amount - 0.5m * amount - disc * (amount - 0.5m * amount);
            }
            return result;
        }
    }

    public enum AccountStatus
    {
        NotRegistered = 1,
        SimpleCustomer = 2,
        ValuableCustomer = 3,
        MostValuableCustomer = 4
    }

    public class DiscountManagerStep1Naming
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal loyaltyDiscountPercent = timeOfHavingAccountInYears > 5 ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;
            if (accountStatus == AccountStatus.NotRegistered)
            {
                priceAfterDiscount = price;
            }
            else if (accountStatus == AccountStatus.SimpleCustomer)
            {
                priceAfterDiscount = price - 0.1m * price - loyaltyDiscountPercent * (price - 0.1m * price);
            }
            else if (accountStatus == AccountStatus.ValuableCustomer)
            {
                priceAfterDiscount = 0.7m * price - loyaltyDiscountPercent * 0.7m * price;
            }
            else if (accountStatus == AccountStatus.MostValuableCustomer)
            {
                priceAfterDiscount = price - 0.5m * price - loyaltyDiscountPercent * (price - 0.5m * price);
            }
            return priceAfterDiscount;
        }
    }

    public class DiscountManagerStep2PrivateMethods
    {
        private const int MaxYearsForLoyaltyDiscount = 5;

        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            var loyaltyDiscountPercent = (decimal)LoyaltyDiscountYears(timeOfHavingAccountInYears)/100;
            priceAfterDiscount = accountStatus switch
            {
                AccountStatus.NotRegistered => _discount(price, loyaltyDiscountPercent, 1.0m),
                AccountStatus.SimpleCustomer => _discount(price, loyaltyDiscountPercent, 0.9m),
                AccountStatus.ValuableCustomer => _discount(price, loyaltyDiscountPercent, 0.7m),
                AccountStatus.MostValuableCustomer => _discount(price, loyaltyDiscountPercent, 0.5m),
                _ => priceAfterDiscount
            };
            return priceAfterDiscount;
        }

        private static int LoyaltyDiscountYears(int timeOfHavingAccountInYears) =>
            timeOfHavingAccountInYears > MaxYearsForLoyaltyDiscount
                ? MaxYearsForLoyaltyDiscount
                : timeOfHavingAccountInYears;

        private readonly Func<decimal, decimal, decimal, decimal> _discount =
            (price, discountForLoyaltyInPercentage, discountPercent) =>
                discountPercent * price * (1 - discountForLoyaltyInPercentage);
    }

    public class DiscountManagerStep3Dictionary
    {
        private const int MaxYearsForLoyaltyDiscount = 5;
        private readonly IDictionary<AccountStatus, decimal> _accountDiscount;

        public DiscountManagerStep3Dictionary()
        {
            _accountDiscount = new Dictionary<AccountStatus, decimal>()
            {
                {AccountStatus.NotRegistered, 1.0m},
                {AccountStatus.SimpleCustomer, 0.9m},
                {AccountStatus.ValuableCustomer, 0.7m},
                {AccountStatus.MostValuableCustomer, 0.5m}
            };
        }

        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears) => 
            _discount(price, LoyaltyDiscountYears(timeOfHavingAccountInYears), _accountDiscount[accountStatus]);

        private static decimal LoyaltyDiscountYears(int timeOfHavingAccountInYears) =>
           (decimal) (timeOfHavingAccountInYears > MaxYearsForLoyaltyDiscount
                ? MaxYearsForLoyaltyDiscount
                : timeOfHavingAccountInYears) / 100;

        private readonly Func<decimal, decimal, decimal, decimal> _discount =
            (price, discountForLoyaltyInPercentage, discountPercent) =>
                discountPercent * price * (1 - discountForLoyaltyInPercentage);
    }

    public class DiscountService
    {
        public decimal Calculate(decimal amount, int points)
        {
            return 0;
        }
    }
}
