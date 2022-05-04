using lambda6_csharp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda6_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            string path = @"c:\temp\in.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        var aux = sr.ReadLine().ToString().Split(',');
                        string name = aux[0];
                        double price = double.Parse(aux[1],CultureInfo.InvariantCulture);
                        
                        products.Add(new Product(name, price));
                    }
                    var averagePrice = products.Average(p => p.Price);

                    Console.WriteLine(averagePrice.ToString("F2",CultureInfo.InvariantCulture));
                    var productsLowerPrice = products.Where(p => p.Price < averagePrice).Select(p => p);
                    var productsOrdened = productsLowerPrice.OrderByDescending(p => p.Name).Select(p => p.Name);
                    foreach (var p in productsOrdened)
                    {
                        Console.WriteLine(p);
                    }

                }

            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            Console.ReadKey();
            
        }
    }
}
