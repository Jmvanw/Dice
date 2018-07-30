using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            //int result = Dice.D20();
            //Console.WriteLine(result);
            //Console.ReadLine();
            Start:
            Console.WriteLine("Input die size");
            int size;
            string s = Console.ReadLine();
            if (int.TryParse(s, out size)) { size = Convert.ToInt32(s); }

            Console.WriteLine("Input number of rolls");
            int times; // = Convert.ToInt32(Console.ReadLine());
            string nr = Console.ReadLine();
            if (int.TryParse(nr, out times)) { times = Convert.ToInt32(nr); }

            Console.WriteLine("Modifiers?");
            int mod;
            string m = Console.ReadLine();
            if (int.TryParse(m, out mod)) { mod = Convert.ToInt32(m); }
            int[] results = Dice.RollDice(size, times, mod);

            Console.WriteLine("[{0}]", string.Join(", ", results));
            Console.ReadLine();
            Console.WriteLine("Type 'Average' or 'Sum' or click a button for the count of your roll results." +
                "");
            string outputType = Console.ReadLine();
            if (outputType == "Average")
            {
                double resultsAverage = results.Average();
                Console.WriteLine(resultsAverage);
            }
            else if (outputType == "Sum")
            {
                int resultsSum = results.Sum();
                Console.WriteLine(resultsSum);
            }
            else
            {
                Console.WriteLine("value - total");
                var outval = from rolls in results
                             //orderby rolls descending
                             group rolls by rolls into rollGroup
                             select new { rollGroup, rollCount = rollGroup.Count() };
                foreach (var item in outval)
                {
                    Console.WriteLine("{0} - {1}", item.rollGroup.Key,item.rollCount);
                }


                Console.WriteLine("Order results? y or n");
                string orderReq = Console.ReadLine();
                if (orderReq == "y")
                    {
                    Console.WriteLine("value - total");
                    var outvalRolls = results.OrderByDescending(n => n).GroupBy(n => n);//lambdas are supposed to be more clear?
                    foreach (var number in outvalRolls)
                        Console.WriteLine("{0} - {1}", number.Key, number.Count());
                    }
                else
                {

                }
            }



            Console.ReadLine();

            goto Start;
        }
    }
}
