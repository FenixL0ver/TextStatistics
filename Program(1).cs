using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Доп_задания
{
    class Program
    {
        static void Main(string[] args)
        {
           

            var TxtStat = new TextStatistics("Шла Саша по шоссе и сосала сушку Карл у Клары украл коралы, а Клара у Карла украла кларнет");
            Console.WriteLine(TxtStat.Count);
            Console.WriteLine(TxtStat.Contains("Саша"));
            Console.WriteLine(TxtStat.CountWord("Шла"));
            Console.WriteLine(TxtStat.CountWord("по"));
            Console.WriteLine(TxtStat.CountWord("где"));
            Console.WriteLine(TxtStat.FindMinByBool(3));

            Console.WriteLine(TxtStat.FindMaxNotMore(5));

            foreach (var x in TxtStat.GetWordsByStart("с"))
            {
                Console.WriteLine(x);
            }

            TxtStat.PrintInAlphabetOrder();
            Console.ReadLine();
        }
    }
}
