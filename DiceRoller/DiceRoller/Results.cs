using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    static class Results
    {
        public static void DisplayResults(int[] results)
        {
            Console.WriteLine("[{0}]", string.Join(", ", results));
            Console.ReadLine();
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int modNum)
        {
            for (var i = 0; i < (float)array.Length / modNum; i++)
            {
                yield return array.Skip(i * modNum).Take(modNum);
            }
        }
    }
}
