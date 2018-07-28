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
            int result = Dice.D20();
            Console.WriteLine(result);
            Console.ReadLine();

            int[] results = Dice.AnyDice(20, 5);

            Console.WriteLine("[{0}]", string.Join(", ", results));
            Console.ReadLine();

        }
    }
}
