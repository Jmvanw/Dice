using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    public class UserInput
    {
        public static void DisplayResults(int[] results)
        {
            Console.WriteLine("[{0}]", string.Join(", ", results));
            Console.ReadLine();
        }

        public int GetSize()
        {
            Console.WriteLine("Input die size");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int size)) { size = Convert.ToInt32(s); }
            return size;
        }

        public int GetNumberOfRolls()
        {
            Console.WriteLine("Input number of rolls");
            string nr = Console.ReadLine();
            if (int.TryParse(nr, out int times)) { times = Convert.ToInt32(nr); }
            return times;
        }

        public int GetModifiers()
        {
            Console.WriteLine("Modifiers?");
            string m = Console.ReadLine();
            if (int.TryParse(m, out int mod)) { mod = Convert.ToInt32(m); }
            return mod;
        }

        public double GetAverage(int[] results)
        {
            double resultsAverage = results.Average();
            return resultsAverage;
        }

        public int GetSum(int[] results)
        {
            Console.WriteLine("Targets?");
            string t = Console.ReadLine();
            if (int.TryParse(t, out int targetNumber)) { targetNumber = Convert.ToInt32(t); }
            else { targetNumber = 1; }
            int resultsSum = results.Sum();
            int resultsTarget = resultsSum / targetNumber;
            return resultsTarget;
        }

        public void BreakItUp(int[] results)
        {

            Console.WriteLine("value - total");
            var outval = from rolls in results
                             //orderby rolls descending
                         group rolls by rolls into rollGroup
                         select new { rollGroup, rollCount = rollGroup.Count() };
            foreach (var item in outval)
            {
                Console.WriteLine("{0} - {1}", item.rollGroup.Key, item.rollCount);
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
    }
}
