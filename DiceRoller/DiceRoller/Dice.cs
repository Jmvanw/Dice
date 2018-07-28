using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    class Dice
    {
        public static int D4()
        {
            Random roll = new Random();
            int result = roll.Next(1, 5);
            return result;
        }

        public static int D6()
        {
            Random roll = new Random();
            int result = roll.Next(1, 7);
            return result;
        }

        public static int D8()
        {
            Random roll = new Random();
            int result = roll.Next(1, 9);
            return result;
        }

        public static int D10()
        {
            Random roll = new Random();
            int result = roll.Next(1, 11);
            return result;
        }

        public static int D12()
        {
            Random roll = new Random();
            int result = roll.Next(1, 13);
            return result;
        }

        public static int D20()
        {
            Random roll = new Random();
            int result = roll.Next(1, 21);
            return result;
        }

        public static int[] AnyDice(int size, int times)
        {
            int[] results = new int[times];

            Random roll = new Random();
            for (int i=0; i < results.Length; i++)
            {
                results[i] = roll.Next(1, size+1);
            }
            return results;
        }



    }
}
