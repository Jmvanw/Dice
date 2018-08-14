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
                int[] results = new int[times];
                int numberOfModifiers = user1.GetNumberofModifiers();
                if (numberOfModifiers > 1)
                {

                    int[] modifierArray = user1.GetModifiers(numberOfModifiers);
                    //int[] results = Dice.RollDice(size, times, mod);
                    results = Dice.RollDice(size, times);
                    int[][] splitResults = user1.SplitByModifierNumber(results, numberOfModifiers);
                    Console.WriteLine("SplitResults =");
                    Results.DisplayResults(splitResults);
                    //int[] moddedResults = user1.ApplyModifierArray(splitResults, modifierArray, numberOfModifiers);
                    //List<object> moddedResultsList = moddedResults.Cast<Object>().ToList();
                    int[] moddedResults = user1.ApplyModifierArray(splitResults, modifierArray[0], modifierArray[1]);

                    if (modifierArray.Length > 4)
                    {
                        moddedResults = user1.ApplyModifierArray(splitResults, modifierArray[0], modifierArray[1], modifierArray[2], modifierArray[3], modifierArray[4]);
                    }
                    else if (modifierArray.Length > 3)
                    {
                        moddedResults = user1.ApplyModifierArray(splitResults, modifierArray[0], modifierArray[1], modifierArray[2], modifierArray[3]);
                    }
                    else if (modifierArray.Length > 2)
                    {
                        moddedResults = user1.ApplyModifierArray(splitResults, modifierArray[0], modifierArray[1], modifierArray[2]);
                    }

                    //if (numberOfModifiers == 2)
                    //{
                    //    int ModifierA = modifierArray[0];
                    //    int ModifierB = modifierArray[1];

                    //    int[] moddedResults = new int[2];
                    //    moddedResults = user1.Apply2ModifierArray(splitResults, ModifierA, ModifierB);
                    //}

                    //int[] modNum = user1.GetModifierNum(results);
                    Console.WriteLine("adding modifiers to results");
                    Results.DisplayResults(moddedResults);
                    results = moddedResults;
                }
                else if (numberOfModifiers == 1)
                {
                    int mod = user1.GetModifiers();
                    results = Dice.RollDice(size, mod, times);

                }
                else
                {
                    results = Dice.RollDice(size, times);
                }

                user1.BreakItUp(results);

                Console.WriteLine("Type 'y' to divide your sum evenly between targets");
                string outputType = Console.ReadLine();
                if (outputType == "y")
                {
                    int targetResults = user1.DivideSum(results);
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
