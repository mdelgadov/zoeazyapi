using System;

namespace ZoEazy.Api.Model
{
    public class Money
    {
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }

        public Money()
        {
            Amount = 0;
            CurrencyId = new Currency().Id;
        }

        public Money(decimal amount)
        {
            Amount = amount;
            CurrencyId = new Currency().Id;
        }

        public Money(decimal amount, int currencyId)
        {
            Amount = amount;
            CurrencyId = new Currency().Id;
        }

        public Tuple<decimal, Currency> getMoney(decimal amount)
        {
            return new Tuple<decimal, Currency>(amount, new Currency());
        }

        public Tuple<decimal, Currency> getMoney(decimal amount, int currencyId)
        {
            var currency = new Currency();
            if (currencyId != currency.Id) throw new Exception("Invalid currency");

            return new Tuple<decimal, Currency>(amount, new Currency());
        }

        public Tuple<decimal, Currency> getMoney(decimal amount, string name)
        {
            var currency = new Currency();
            if (name != currency.Name && name != currency.ShortName && name != currency.ShortName && name != currency.Symbol)
                throw new Exception("Invalid currency");

            return new Tuple<decimal, Currency>(amount, new Currency());
        }
    }
}