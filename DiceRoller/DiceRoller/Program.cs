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

            Console.WriteLine("Input die size");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input number of rolls");
            int times = Convert.ToInt32(Console.ReadLine());
            int[] results = Dice.AnyDice(size, times);

            Console.WriteLine("[{0}]", string.Join(", ", results));
            Console.ReadLine();

        }
    }
}
