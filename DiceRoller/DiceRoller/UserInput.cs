using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    public class UserInput
    {

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

        public int[] GetModifierNum(int[] masterList)
        {
            Console.WriteLine("how many modifiers?");
            string m1 = Console.ReadLine();
            if (int.TryParse(m1, out int modNum)) { modNum = Convert.ToInt32(m1); }
            var groupCount = 4;
            var minGroupSize = masterList.Length / groupCount;
            var extraItems = masterList.Length % groupCount;

            var groupedNames = new List<List<int>>();

            for (int i = 0; i < modNum; i++)
            {
                groupedNames.Add(masterList.Skip(i * minGroupSize).Take(minGroupSize).ToList());

                if (i < extraItems)
                {
                    groupedNames[i].Add(masterList[masterList.Length - 1 - i]);
                }
            }

            Console.WriteLine("Here are the groups:");
            for (int index = 0; index < groupedNames.Count; index++)
            {
                Console.WriteLine($"#{index + 1}: {string.Join(", ", groupedNames[index])}");
            }

            Console.Write("\nDone!\nPress any key to exit...");
            Console.ReadKey();

            return masterList;

            //var splitResults = results.Split(modNum);
            //for (int i=0; i <= modNum; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.WriteLine("a[{0},{1}] = {2}", i, j, splitResults[i,j]);
            //    } 
            //}
            //Console.WriteLine(splitResults);
            //Console.WriteLine("splitResults");
            //return results;
        }

        public int GetModifiers()
        {
            Console.WriteLine("What are your modifiers?");

            string m1 = Console.ReadLine();
            if (int.TryParse(m1, out int mod1)) { mod1 = Convert.ToInt32(m1); }
            return mod1;
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

            Console.WriteLine("{0,5}  -  {1,5}", "value", "total");
            var outval = from rolls in results
                             //orderby rolls descending
                         group rolls by rolls into rollGroup
                         select new { rollGroup, rollCount = rollGroup.Count() };
            foreach (var item in outval)
            {
                Console.WriteLine("{0,3}    -  {1,3}", item.rollGroup.Key, item.rollCount);
            }


            Console.WriteLine("Order results? y or n");
            string orderReq = Console.ReadLine();
            if (orderReq == "y")
            {
                Console.WriteLine("{0,5}  -  {1,5}", "value", "total");
                var outvalRolls = results.OrderByDescending(n => n).GroupBy(n => n);//lambdas are supposed to be more clear? 
                foreach (var number in outvalRolls)
                    Console.WriteLine("{0,3}    -  {1,3}", number.Key, number.Count());
            }
            else
            {
                //not sure what I'm putting here
            }
        }
    }
}
