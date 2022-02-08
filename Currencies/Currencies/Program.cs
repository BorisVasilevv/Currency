using System;

namespace Currencies
{
    class Program
    {

        static void Main(string[] args)
        {
            FileHelper.FileExistsTest();
            string[] data = FileHelper.ReadFile();

            int amountOfCurrencies = data.Length;
            Currency[] currencies = new Currency[amountOfCurrencies];
            currencies[0] = new Currency() { Name = data[0], Buy = 1, Sold = 1 };
            for (int i = 1; i < amountOfCurrencies; i++)
            {
                currencies[i] = Currency.FromStringToCurrensy(data[i]);
            }

            for (int i = 0; i < amountOfCurrencies; i++)
            {
                Currency[] newCostCurrencies = new Currency[amountOfCurrencies];
                for (int j = 0; j < amountOfCurrencies; j++)
                {
                    double buy, sold;
                    string name;
                    name = currencies[j].Name;
                    buy = Math.Round(currencies[j].Buy / currencies[i].Buy, 2);
                    sold = Math.Round(currencies[j].Sold / currencies[i].Buy, 2);
                    newCostCurrencies[j] = new Currency { Name = name, Buy = buy, Sold = sold };
                }
                if(i!=0) FileHelper.WriteToFile(currencies[i].Name, newCostCurrencies);
            }
        }
    }
}

