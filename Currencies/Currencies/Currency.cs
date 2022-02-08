using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currencies
{
    
    public class Currency
    {
        const int NameCurrencyIndex = 0;
        const int SoldCurrencyIndex = 1;
        const int ByuCurrencyIndex = 2;

        public string Name { get; set; }

        private double sold;
        public double Sold 
        { 
            get 
            {
                return sold;
            }
            set
            {
                if(value > 0)
                    sold = value;
            }
        }

        private double byu;
        public double Buy
        {
            get
            {
                return byu;
            }
            set
            {
                if (value > 0)
                    byu = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} {sold} {byu}";
        }

        public static Currency FromStringToCurrensy(string str)
        {
            Currency currency = new Currency();
            string[] data = str.Split(' ');
            currency.Name = data[NameCurrencyIndex];
            currency.sold = Convert.ToDouble(data[SoldCurrencyIndex]);
            currency.byu = Convert.ToDouble(data[ByuCurrencyIndex]);
            return currency;
        }
    }
}
