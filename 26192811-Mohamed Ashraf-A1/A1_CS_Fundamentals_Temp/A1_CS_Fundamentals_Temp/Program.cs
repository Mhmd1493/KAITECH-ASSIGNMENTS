using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_CS_Fundamentals_Temp
{
    class Program
    {
        // Please use this Template for (A1- C# Fundamentals).
        // And follow the same approach for all other Assignments of (Programming Fundamentals using C#) course.

        static void Main(string[] args)
        {
            T9();


            Console.WriteLine("\n\n");
        }



        #region Helping Functions

        // 'Divide & Conquer' is always the best technique for solving problems.
        // You can always divide your big problem to small problems, and solve each apart.
        // Each small problem can be solved in a separate 'Function'.
        // Then you can gather these Functions to solve your big problem.
        // These 'Helping Functions' are exmaples for such aproach.
        // Feel free to use these two functions and create your own ones to help you solve your bigger problems.

        /// <summary>
        /// Ckecks if the input is numeric ('double') or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsDouble(string str)
        {
            return double.TryParse(str, out _);  // Search for 'Output Parameter' and learn how to use it.
        }

        /// <summary>
        /// Forces the user to enter a 'number' as an input.
        /// </summary>
        /// <remarks>
        /// (Defencive Coding)
        /// </remarks>
        /// <returns></returns>
        static double DoubleInput()
        {
            string input = Console.ReadLine();

            while (!IsDouble(input))
            {
                Console.WriteLine("Please, Enter a Valid Number");
                input = Console.ReadLine();
            }

            return double.Parse(input);
        }

        #endregion



        /// <summary>
        /// Write a C# program to take two numbers from the user and check whether they are equal or not.
        /// </summary>
        static void T1()
        {
            Console.WriteLine("Please, enter first number");
            double num1 = DoubleInput();

            Console.WriteLine("Please, enter second number");
            double num2 = DoubleInput();

            if (num1 == num2)
                Console.WriteLine("\nNumbers are equal");
            else
                Console.WriteLine("\nNumbers are not equal");
        }


        /// <summary>
        /// Write a C# program that takes a number as input and checks whether it’s even or odd.
        /// </summary>
        static void T2()
        {
            Console.WriteLine("Please, enter the number");
            double num1 = DoubleInput();
            if (num1 % 2 == 0)
            {
                Console.WriteLine("\nNumber is even");
            }
            else if (num1 == 0)
                Console.WriteLine("\nNumber is even");
            else
                Console.WriteLine("\nNumber is odd");
        }


        /// <summary>
        /// Write a C# program to take two numbers from the user and print the sum.
        /// </summary>
        static void T3()
        {
            Console.WriteLine("Please, enter first number");
            double num1 = DoubleInput();

            Console.WriteLine("Please, enter second number");
            double num2 = DoubleInput();

            Console.WriteLine("Sum = {0}", num1 + num2);
        }


        /// <summary>
        /// Write a C# program to read a candidate’s age and determine whether he is eligible for casting his vote or not. The accepted age is 18 years.
        /// </summary>
        static void T4()
        {
            Console.WriteLine("Please enter candidate’s age");
            double num1 = DoubleInput();
            if (num1 < 18)
            {
                Console.WriteLine("The candidate is ineligible");
            }
            else
            {
                Console.WriteLine("The candidate is eligible");
            }
        }


        /// <summary>
        /// Write a C# program that takes two numbers as input and performs (+, -, x, /) operations on them, then display the result of these operations.
        /// </summary>
        static void T5()
        {
            Console.WriteLine("Please, enter first number");
            double num1 = DoubleInput();

            Console.WriteLine("Please, enter second number");
            double num2 = DoubleInput();

            Console.WriteLine("\nSum = {0}", num1 + num2);
            Console.WriteLine("\nDifference = {0}", num1 - num2);
            Console.WriteLine("\nProduct = {0}", num1 * num2);
            Console.WriteLine("\nQuotient = {0}", num1 / num2);
        }


        /// <summary>
        /// Write a C# program that takes five numbers as input, then calculate and print their Sum & Average (using Loops).
        /// </summary>
        /// <remarks>
        /// Don’t use Sum() and Average() functions.
        /// </remarks>
        static void T6()
        {
            double[] arr = new double[5];
            double sum1 = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please, enter number {0}", i);
                arr[i] = DoubleInput();
            }
            for (int i = 0; i < 5; i++)
            {
                sum1 = sum1 + arr[i];
            }
            Console.WriteLine("Sum is {0}", sum1);
            Console.WriteLine("Average is {0}", sum1/arr.Length);
        }


        


        /// <summary>
        /// Write a C# program to check whether a triangle can be formed by the given values of angles entered by the user.
        /// </summary>
        static void T7()
        {
            double[] arr = new double[5];
            double sum2 = 0;
                   for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please, enter angle {0}", i);
                arr[i] = DoubleInput();
            }
            for (int i = 0; i < 3; i++)
            {
                sum2 = sum2 + arr[i];
            }
            if (sum2 == 180)
            {
                Console.WriteLine("The angles can form a triangle");
            }
            else
            {
                Console.WriteLine("The angles can't form a triangle");
            }
        }


        /// <summary>
        /// Write a C# program that takes a number as input and prints its multiplication table (using Loops).
        /// </summary>
        static void T8()
        {
            Console.WriteLine("Please, enter number");
            var num1 = DoubleInput();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}x{1}={2}",num1, i, num1*i);
            }
        }


        /// <summary>
        /// Write a program in C# Sharp to accept a grade and declare the equivalent description.
        /// </summary>
        static void T9()
        {
            Console.WriteLine("Please enter your grade");
            var grade = Console.ReadLine();
            if (grade == "A")
            {
                Console.WriteLine("Excellent");
            }
            else if (grade == "B")
            {
                Console.WriteLine("Very good");
            }
            else if (grade == "C")
            {
                Console.WriteLine("Good");
            }
            else if (grade == "D")
            {
                Console.WriteLine("Pass");
            }
            else if (grade == "F")
            {
                Console.WriteLine("Fail");
            }
            else
            {
                Console.WriteLine("Please enter a letter only from (A,B,C,D or F)!");
                grade = Console.ReadLine();
            }
        }


        /// <summary>
        /// Write a C# program to take two numbers from the user and swap them.
        /// </summary>
        static void T10()
        {
            Console.WriteLine("Please, enter first number");
            double num1 = DoubleInput();

            Console.WriteLine("Please, enter second number");
            double num2 = DoubleInput();

            var x = num2;
            num2 = num1;
            num1 = x;

            Console.WriteLine("Number 1 ={0}", num1);
            Console.WriteLine("Number 2 ={0}", num2);
        }
    }
}
