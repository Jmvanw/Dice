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

        public static void DisplayResults(int[][] results)
        {
            //Console.WriteLine("[{0}]", string.Join(", ", results));


            for (int i = 0; i < results.Length; i++)
            {
                //Console.WriteLine(groupedNameArray[i][0]);
                //Console.WriteLine($"#{i + 1}: {string.Join(", ", results[i])}");
                {
                    System.Console.Write("Element({0}): ", i + 1);

                    for (int j = 0; j < results[i].Length; j++)
                    {
                        System.Console.Write(results[i][j] + ", ");
                    }
                    System.Console.WriteLine();
                }
                //Console.ReadLine();
            }
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
