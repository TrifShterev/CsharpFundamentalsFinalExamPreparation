using System;
using System.Text.RegularExpressions;

namespace Fancy_BarcodesRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"@#+(?<barcodes>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match barcodes = Regex.Match(input, pattern);
                string currentGroup = "";
                if (barcodes.Success)
                {
                    string barcode = barcodes.Groups["barcodes"].Value;
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        char symbol = barcode[j];
                        if (Char.IsDigit(symbol))
                        {
                            currentGroup += symbol;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                if (currentGroup == String.Empty)
                {
                    Console.WriteLine("Product group: 00");
                }
                else
                {
                    Console.WriteLine($"Product group: {currentGroup}");
                }
            }



        }
    }
}
