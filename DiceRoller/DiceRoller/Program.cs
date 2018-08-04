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

            bool endProg = false;
            while (!endProg)  //this can end when the user hits the x, not before. muahaha
            {
                UserInput user1 = new UserInput();

                int size = user1.GetSize();
                int times = user1.GetNumberOfRolls();
                
                int mod = user1.GetModifiers();
                

                int[] results = Dice.RollDice(size, times, mod);
                int[] modNum = user1.GetModifierNum(results);
                Console.WriteLine("that was the groups");
                Results.DisplayResults(results);

                Console.WriteLine("Type 'Average' or 'Sum' or click a button for the count of your roll results.");
                string outputType = Console.ReadLine();
                if (outputType == "Average")
                {
                    double resultsAverage = user1.GetAverage(results);
                    Console.WriteLine(resultsAverage);
                }
                else if (outputType == "Sum")
                {
                    int targetResults = user1.GetSum(results);
                    Console.WriteLine(targetResults);
                }
                else
                {
                    user1.BreakItUp(results);
                }


                Console.ReadLine();

            }
        }
    }

}
