using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currencies
{
    public class FileHelper
    {
        static string fileName = "..\\..\\..\\..\\ratesCurrency.txt";
        public static void FileExistsTest()
        {          
            string[] textForTest = new string[] { "RUB", "USD 75,00 76,84", "EUR 85,76 88,76", "JPY 64,97 69,25" };
            if (!File.Exists(fileName))
                File.WriteAllLines(fileName, textForTest);
        }

        public static string[] ReadFile()
        {
            return File.ReadAllLines(fileName);
        }

        public static void WriteToFile(string mainName,Currency[] currencies)
        {
            string newFileName = $"..\\..\\..\\..\\{mainName}ratesCurrency.txt";
            string[] lines = new string[currencies.Length+1];
            lines[0] = mainName;
            int amountOfFullString = 0;
            while(amountOfFullString<lines.Length-1)
            {
                amountOfFullString++;
                if (currencies[amountOfFullString-1].Name == mainName)
                {
                    continue;
                }
                else
                {
                    lines[amountOfFullString] = currencies[amountOfFullString-1].ToString();                  
                }
            }

            lines= lines.Where(x => x != null).ToArray();
            File.WriteAllLines(newFileName, lines);
        }
    }
}
