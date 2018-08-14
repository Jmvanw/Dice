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
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("Input die size, default is 20");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int size)) { size = Convert.ToInt32(s); }
            else { size = 20; }
            return size;
        }

        public int GetNumberOfRolls()
        {
            Console.WriteLine("Input number of rolls, default is 1");
            string nr = Console.ReadLine();
            if (int.TryParse(nr, out int times) && nr != "0")
            {
                times = Convert.ToInt32(nr);
            }
            else { times = 1; }

            return times;
        }

        public int GetNumberofModifiers()
        {
            Console.WriteLine("how many modifiers? Default is 1");
            string m1 = Console.ReadLine();
            if (int.TryParse(m1, out int modNum)) { modNum = Convert.ToInt32(m1); }
            return modNum;
        }

        public int GetModifiers() //if there are no modifiers
        {
            Console.WriteLine("Modifier value?");
            string m = Console.ReadLine();
            if (int.TryParse(m, out int mod)) { mod = Convert.ToInt32(m); }
            return mod;
        }

        public int[] GetModifiers(int modNum)
        {
            Console.WriteLine("What are your " + modNum + " modifiers?");

            int[] modifierArray = new int[modNum];
            for (int i = 0; i < modifierArray.Length; i++)
            {
                Console.WriteLine("Modifier {0}:", i + 1);
                string m1 = Console.ReadLine();
                if (int.TryParse(m1, out int modifierToAdd)) { modNum = Convert.ToInt32(m1); }
                modifierArray[i] = modifierToAdd;
            }
            return modifierArray;
        }

        public int[][] SplitByModifierNumber(int[] masterList, int modNum)
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

            //Console.WriteLine("Here are the groups:");
            //for (int index = 0; index < groupedNames.Count; index++)
            //{
            //    Console.WriteLine($"#{index + 1}: {string.Join(", ", groupedNames[index])}");
            //}

            //Console.ReadKey();
            int[][] groupedNameArray = groupedNames.Select(a => a.ToArray()).ToArray();
            //Console.WriteLine("Here is the groupedNameArray");
            //Results.DisplayResults(groupedNameArray);
            return groupedNameArray;
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


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////Modification section///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int[] ApplyModifierArray(int[][] splitResults, int modifierA, int modifierB, int modifierC, int modifierD, int modifierE) //this is all messy should have used lists
        {

            int[] splitResultsFirst = splitResults[0];
            splitResultsFirst = Array.ConvertAll(splitResultsFirst, x => x + modifierA);
            int[] splitResultsSecond = splitResults[1];
            splitResultsSecond = Array.ConvertAll(splitResultsSecond, x => x + modifierB);
            int[] splitResultsThird = splitResults[2];
            splitResultsThird = Array.ConvertAll(splitResultsThird, x => x + modifierC);
            int[] splitResultsFourth = splitResults[3];
            splitResultsFourth = Array.ConvertAll(splitResultsFourth, x => x + modifierD);
            int[] splitResultsFifth = splitResults[3];
            splitResultsFifth = Array.ConvertAll(splitResultsFifth, x => x + modifierE);

            int[] recombinedResults = new int[splitResultsFirst.Length + splitResultsSecond.Length + splitResultsThird.Length + splitResultsFourth.Length + splitResultsFifth.Length];

            Array.Copy(splitResultsFirst, recombinedResults, splitResultsFirst.Length);
            Array.Copy(splitResultsSecond, 0, recombinedResults, splitResultsFirst.Length, splitResultsSecond.Length);
            Array.Copy(splitResultsThird, 0, recombinedResults, splitResultsFirst.Length + splitResultsSecond.Length, splitResultsThird.Length);
            Array.Copy(splitResultsFourth, 0, recombinedResults, splitResultsFirst.Length + splitResultsSecond.Length + splitResultsThird.Length, splitResultsFourth.Length);
            Array.Copy(splitResultsFifth, 0, recombinedResults, splitResultsFirst.Length + splitResultsSecond.Length + splitResultsThird.Length + splitResultsFourth.Length, splitResultsFifth.Length);

            return recombinedResults;
        }


        public int[] ApplyModifierArray(int[][] splitResults, int modifierA, int modifierB, int modifierC, int modifierD)
        {

            int[] splitResultsFirst = splitResults[0];
            splitResultsFirst = Array.ConvertAll(splitResultsFirst, x => x + modifierA);
            int[] splitResultsSecond = splitResults[1];
            splitResultsSecond = Array.ConvertAll(splitResultsSecond, x => x + modifierB);
            int[] splitResultsThird = splitResults[2];
            splitResultsThird = Array.ConvertAll(splitResultsThird, x => x + modifierC);
            int[] splitResultsFourth = splitResults[3];
            splitResultsFourth = Array.ConvertAll(splitResultsFourth, x => x + modifierD);

            int[] recombinedResults = new int[splitResultsFirst.Length + splitResultsSecond.Length + splitResultsThird.Length + splitResultsFourth.Length];

            Array.Copy(splitResultsFirst, recombinedResults, splitResultsFirst.Length);
            Array.Copy(splitResultsSecond, 0, recombinedResults, splitResultsFirst.Length, splitResultsSecond.Length);
            Array.Copy(splitResultsThird, 0, recombinedResults, splitResultsFirst.Length + splitResultsSecond.Length, splitResultsThird.Length);
            Array.Copy(splitResultsFourth, 0, recombinedResults, splitResultsFirst.Length + splitResultsSecond.Length + splitResultsThird.Length, splitResultsFourth.Length);

            return recombinedResults;
        }

        public int[] ApplyModifierArray(int[][] splitResults, int modifierA, int modifierB, int modifierC)
        {

            int[] splitResultsFirst = splitResults[0];
            splitResultsFirst = Array.ConvertAll(splitResultsFirst, x => x + modifierA);
            int[] splitResultsSecond = splitResults[1];
            splitResultsSecond = Array.ConvertAll(splitResultsSecond, x => x + modifierB);
            int[] splitResultsThird = splitResults[2];
            splitResultsThird = Array.ConvertAll(splitResultsThird, x => x + modifierC);

            int[] recombinedResults = new int[splitResultsFirst.Length + splitResultsSecond.Length + splitResultsThird.Length];

            Array.Copy(splitResultsFirst, recombinedResults, splitResultsFirst.Length);
            Array.Copy(splitResultsSecond, 0, recombinedResults, splitResultsFirst.Length, splitResultsSecond.Length);
            Array.Copy(splitResultsThird, 0, recombinedResults, splitResultsFirst.Length + splitResultsSecond.Length, splitResultsThird.Length);

            return recombinedResults;
        }

        public int[] ApplyModifierArray(int[][] splitResults, int modifierA, int modifierB)
        {

            int[] splitResultsFirst = splitResults[0];
            splitResultsFirst = Array.ConvertAll(splitResultsFirst, x => x + modifierA);
            int[] splitResultsSecond = splitResults[1];
            splitResultsSecond = Array.ConvertAll(splitResultsSecond, x => x + modifierB);
            int[] recombinedResults = new int[splitResultsFirst.Length + splitResultsSecond.Length];

            Array.Copy(splitResultsFirst, recombinedResults, splitResultsFirst.Length);
            Array.Copy(splitResultsSecond, 0, recombinedResults, splitResultsFirst.Length, splitResultsSecond.Length);

            return recombinedResults;

            //int[] moddedResults = new int[2];
            //for (int i = 0, j = 0; i < splitResults.Length; i++, j++)
            //{
            //    moddedResults[i] = splitResults[i] + modifierA;
            //    moddedResults[i][j] = splitResults[][j] + modifierB;
            //}

            //int[][] moddedResults = splitResults.Select(i => i.Select(j => j + modifierB).ToArray()).ToArray();

            //for (int i = 0; i < moddedResults.Length; i++)
            //{
            //    System.Console.Write("moddedResults({0}): ", i + 1);
            //    for (int j = 0; j < moddedResults[i].Length; j++)
            //    {
            //        System.Console.Write(moddedResults[i][j] + "\t");
            //    }
            //    System.Console.WriteLine();
            //}
            //Console.ReadLine();
            //int[] testing = new int[2];
            //return testing;
            //return moddedResults;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////End Modification section///////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public double GetAverage(int[] results)
        {
            double resultsAverage = results.Average();
            return resultsAverage;
        }

        public int DivideSum(int[] results)
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
            Results.DisplayResults(results);
            Console.WriteLine("{0,5}  -  {1,5}", "value", "total");
            var outval = from rolls in results
                             //orderby rolls descending
                         group rolls by rolls into rollGroup
                         select new { rollGroup, rollCount = rollGroup.Count() };
            foreach (var item in outval)
            {
                Console.WriteLine("{0,3}    -  {1,3}", item.rollGroup.Key, item.rollCount);
            }
            int resultsSum = results.Sum();
            double resultsAverage = results.Average();
            Console.WriteLine("Sum: {0}", results.Sum());
            Console.WriteLine("Average: {0}", results.Average());


            Console.WriteLine("Type 'y' to order results");
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
