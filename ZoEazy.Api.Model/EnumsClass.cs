using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZoEazy.Api.Model
{
    public static class Enums
    {
        public static IEnumerable<T> Get<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }
        public static Indexed[] BankAccountType()
        {
            var type = typeof(BankAccountType);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] CornerType()
        {
            var type = typeof(CornerType);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] CreditCardBrand()
        {
            var type = typeof(CreditCardEnum);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] CreditCardState()
        {
            var type = typeof(CreditCardStatus);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] DayOfMonth()
        {
            var type = typeof(DayOfMonth);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] Hour()
        {
            var type = typeof(Hour);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] LongPeriod()
        {
            var type = typeof(LongPeriod);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] Month()
        {
            var type = typeof(Month);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] Quarter()
        {
            var type = typeof(Quarter);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] Suffixes()
        {
            var type = typeof(Suffixes);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name == "any" ? "" : name
                })
                .ToArray();
            return data;

        }
        public static Indexed[] InitialWebsiteState()
        {
            var type = typeof(InitialWebsiteState);
            var data = Enum
                .GetNames(type)
                .Select(name => new Indexed
                {
                    Id = (int)Enum.Parse(type, name),
                    Name = name
                })
                .ToArray();
            return data;

        }

    }
}
