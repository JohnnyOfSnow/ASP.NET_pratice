using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base_console
{
    class Program
    {
        static void Main(string[] args)
        {

            createNumList();
            Console.ReadKey(); // Avoid console closing when program is running done.
        }

        static void createNumList()
        {
            var fibonacciNumbers = new List<int> { 1, 1 };
           


            while(fibonacciNumbers.Count < 20)
            {
                var pervious = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var pervious2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(pervious + pervious2);
            }

  

            foreach(var fibo in fibonacciNumbers)
            {
                Console.WriteLine($"FibonacciNumber: {fibo}");
            }

        }

        /**
        static void createStringList()
        {
            //var names = new List<string> { "<name>", "Area", "Lina" };
            var names = new List<string>();
            names.Add("<name>");
            names.Add("Lina");
            names.Add("Area");

            
            foreach (var name in names)
            {
                Console.WriteLine($"Hello, {name.ToUpper()}");
            }

            //Console.WriteLine($"My name is {names[0]}");
            //Console.WriteLine($"And I add {names[1]} , {names[2]} in my list.");
            //Console.WriteLine($"The list has {names.Count} people in it.");

            
            var index = names.IndexOf("Fiple");
            if (index != -1)
                Console.WriteLine($"The name {names[index]} is at {index}");

            var notFound = names.IndexOf("Not Found"); // not found return -1
            Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");
            

            
            names.Sort();
            foreach(var name in names)
            {
                Console.WriteLine($"Hello, {name.ToUpper()}");
            }

        }*/
       

        static void ifTest()
        {
            int a = 5;
            int b = 3;
            int c = 4;
            if ((a + b + c > 10) || (a == b))
            {
                Console.WriteLine("The answer is greater than 10.");
                Console.WriteLine("Or the first number is same as second number");
            }
            else 
            { 
                Console.WriteLine("The answer is not greater than 10.");
                Console.WriteLine("And the first number is not same as second number");
            }
        }

        static void loopTest()
        {
            int count = 0;

            /**
            while (count < 10)
            {
                Console.WriteLine($"Hello World, and the count is {count}");
                count++;
            }*/

            /**
            do
            {
                Console.WriteLine($"Hello World, and the count is {count}");
                count++;
            } while (count < 10);*/

            /**
            for(count = 0; count < 10; count++)
            {
                Console.WriteLine($"Hello World, and the count is {count}");
            }*/
        }
        /**
         *  您已經了解 C# 語言中的 if 陳述式和迴圈建構，
         *  接著看看您是否能夠撰寫 C# 程式碼，
         *  以找出從整數 1 至 20 能夠被 3 整除之數字的總和。
         */
         
        static void getThreeNumberTotal()
        {
            int total = 0;
            
            for(int count = 1; count < 21; count++)
            {
                if(count % 3 == 0)
                {
                    total = total + count;
                }
            }
            Console.WriteLine($"The answer is {total}");
        }

    }
}
