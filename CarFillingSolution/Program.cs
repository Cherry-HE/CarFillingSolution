using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFillingSolution
{
    class Program
    {
        static void Main(string[] args)
        {

            CarFilingSolution carFilingSolution = new CarFilingSolution();
            int[] array = new int[] { 3, 8, 3, 3, 2 };
            var time = carFilingSolution.solution(array, 7, 11, 5);
            Console.WriteLine(time);

            array = new int[] { 2, 8, 4, 3, 2 };
            time = carFilingSolution.solution(array, 7, 11, 3);
            Console.WriteLine(time);

            array = new int[] { 2, 8 };
            time = carFilingSolution.solution(array, 2, 3, 4);
            Console.WriteLine(time);

            array = new int[] { 5 };
            time = carFilingSolution.solution(array, 4, 0, 3);
            Console.WriteLine(time);

            Console.ReadLine();

        }
    }
}
