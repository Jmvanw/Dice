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

        public int GetNumberofModifiers()
        {
            Console.WriteLine("how many modifiers?");
            string m1 = Console.ReadLine();
            if (int.TryParse(m1, out int modNum)) { modNum = Convert.ToInt32(m1); }
            return modNum;
        }

        public int[] GetModifiers(int modNum)
        {
            Console.WriteLine("What are your " + modNum + " modifiers?");

            int[] modifierArray = new int[modNum];
            for (int i = 0; i < modifierArray.Length; i++)
            {
                Console.WriteLine("Modifier {0}:", i);
                string m1 = Console.ReadLine();
                if (int.TryParse(m1, out int modifierToAdd)) { modNum = Convert.ToInt32(m1); }
                modifierArray[i] = modifierToAdd;
            }
            return modifierArray;
        }

        public int[] SplitByModifierNumber(int[] masterList, int modNum)
        {
            var minGroupSize = masterList.Length / modNum;
            var extraItems = masterList.Length % modNum;


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

            Console.ReadKey();
            int[][] groupedNameArray = groupedNames.Select(a => a.ToArray()).ToArray();
            Console.WriteLine("Here is the groupedNameArray");
            for (int i = 0; i< groupedNameArray.Length; i++)
            {
                Console.WriteLine(groupedNameArray[i][0]);
            }
            return masterList;
            //return groupedNameArray;

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
    

        public int[] ApplyModifierArray(int[] splitResults, int[] modifierArray, int numberOfModifiers)
        {
            
            int[] moddedResults = new int[numberOfModifiers];
            for (int i=0,j=0; i < modifierArray.Length; i++, j++)
            {
                moddedResults[i] = splitResults[i] + modifierArray[j];
            }
            
            return moddedResults;
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
