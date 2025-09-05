using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1_CS_Fundamentals_Temp
{
    class Program
    {
        // Please use this Template for (A1- C# Fundamentals).
        // And follow the same approach for all other Assignments of (Programming Fundamentals using C#) course.

        static void Main(string[] args)
        {
            T5();


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
        /// Write a C# program to find the Sum & Average of all items of the array.
        /// Note: Results shall be rounded by two digits(e.g., 10 / 3 = 3.33).
        /// </summary>
        static void T1()
        {
            #region Input array
            Console.WriteLine("Please enter array length");
            int Array_length = int.Parse(Console.ReadLine());
            float[] arr = new float[Array_length];
            float sum = 0;

            for (int i = 0; i < Array_length; i++)
            {
                Console.WriteLine("Please enter element {0}", i + 1);
                arr[i] = float.Parse(Console.ReadLine());
                sum += arr[i];
            }
            #endregion
            #region Sum & avg
            float avg = sum / Array_length;

            // Round to 2 decimal digits when displaying
            Console.WriteLine("sum = {0:F2}", sum);
            Console.WriteLine("avg = {0:F2}", avg);
            #endregion
        }


        /// <summary>
        /// Write a C# program to read n number of values in an array and display it in reverse order.
        /// </summary>
        static void T2()
        {
            #region Input array
            Console.WriteLine("Please enter array length");
            int Array_length = int.Parse(Console.ReadLine());
            float[] arr = new float[Array_length];

            for (int i = 0; i < Array_length; i++)
            {
                Console.WriteLine("Please enter element {0}", i + 1);
                arr[i] = float.Parse(Console.ReadLine());
            }
            #endregion 
            #region Reverse order
            Console.WriteLine("\nArray in Reverse Order:");
            for (int i = Array_length - 1; i >= 0; i--)
            {
                Console.WriteLine("element {0} = {1}", (Array_length - i), arr[i]);
            }
            #endregion            
        }


        /// <summary>
        /// Write a C# program to copy (Deep Copy) the items from one array into another array.
        /// </summary>
        static void T3()
        {
            #region Input array1
            Console.WriteLine("Please enter array length");
            int Array_length = int.Parse(Console.ReadLine());
            float[] arr1 = new float[Array_length];

            for (int i = 0; i < Array_length; i++)
            {
                Console.WriteLine("Please enter element {0}", i + 1);
                arr1[i] = float.Parse(Console.ReadLine());
            }
            #endregion
            #region array 2 deep copy
            float[] arr2 = new float[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr2[i] = arr1[i];
            }
            #endregion
            #region output array 2
            Console.WriteLine("\nArray 2 (Deep copied):");
            for (int i = 0; i <= arr2.Length - 1; i++)
            {
                Console.WriteLine("element {0} = {1}", (i), arr2[i]);
            }
            #endregion           
        }


        /// <summary>
        /// T4- Write a C# program to separate odd and even integers for a given array.
        /// Note: Put them in a 2D array with two rows, one for odds, and one for evens, then print them.
        /// </summary>
        static void T4()
        {
            #region Input array
            Console.WriteLine("Please enter array rows:");
            int Array_rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter array columns:");
            int Array_columns = int.Parse(Console.ReadLine());

            int[,] arr1 = new int[Array_rows, Array_columns];

            // Input array
            for (int i = 0; i < Array_rows; i++)
            {
                for (int j = 0; j < Array_columns; j++)
                {
                    Console.WriteLine("Please enter element [{0},{1}]:", i + 1, j + 1);
                    arr1[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int[,] sorted_array = new int[2, Array_rows * Array_columns];

            int evenIndex = 0;
            int oddIndex = 0;
            #endregion
            #region 2 rows (0 = evens, 1 = odds), and enough columns to hold all numbers
            for (int i = 0; i < Array_rows; i++)
            {
                for (int j = 0; j < Array_columns; j++)
                {
                    int x = arr1[i, j];

                    if (x % 2 == 0)
                    {
                        sorted_array[0, evenIndex] = x;  // row 0 for evens
                        evenIndex++;
                    }
                    else
                    {
                        sorted_array[1, oddIndex] = x;   // row 1 for odds
                        oddIndex++;
                    }
                }
            }
            #endregion
            #region Print sorted 2D array
            Console.WriteLine("\nEvens:");
            for (int i = 0; i < evenIndex; i++)
            {
                Console.Write(sorted_array[0, i] + " ");
            }

            Console.WriteLine("\nOdds:");
            for (int i = 0; i < oddIndex; i++)
            {
                Console.Write(sorted_array[1, i] + " ");
            }
            #endregion            
        }


        /// <summary>
        /// T5- Write a C# program to find the second smallest element in an array.
        /// </summary>
        static void T5()
        {
            #region Matrix 1 input
            Console.WriteLine("Matrix 1:");
            Console.WriteLine("Please enter array rows:");
            int Array_rows_1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter array columns:");
            int Array_columns_1 = int.Parse(Console.ReadLine());

            int[,] arr1 = new int[Array_rows_1, Array_columns_1];

            for (int i = 0; i < Array_rows_1; i++)
            {
                string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < Array_columns_1; j++)
                {
                    arr1[i, j] = int.Parse(parts[j]);
                }
            }
            #endregion
            #region Second smallest
            int smallest = int.MaxValue;
            int secondSmallest = int.MaxValue;

            // Loop through the array
            for (int i = 0; i < Array_rows_1; i++)
            {
                for (int j = 0; j < Array_columns_1; j++)
                {
                    int current = arr1[i, j];

                    if (current < smallest)
                    {
                        // Update second smallest before updating smallest
                        secondSmallest = smallest;
                        smallest = current;
                    }
                    else if (current > smallest && current < secondSmallest)
                    {
                        secondSmallest = current;
                    }
                }
            }

            // Check if second smallest exists
            if (secondSmallest == int.MaxValue)
            {
                Console.WriteLine("There is no second smallest element (all elements are equal).");
            }
            else
            {
                Console.WriteLine("Second smallest element is {0}", secondSmallest);
            }
            #endregion
        }


        /// <summary>
        /// T6- Write a C# program to count the total number of duplicate items in an array.
        /// For Example:
        /// Array: {1, 1, 1, 5, -12, -12, 7, 7}
        /// Expected output: 4
        /// </remarks>
        static void T6()
        {
            #region Input array
            Console.WriteLine("Please enter array length");
            int Array_length = int.Parse(Console.ReadLine());
            float[] arr1 = new float[Array_length];

            for (int i = 0; i < Array_length; i++)
            {
                Console.WriteLine("Please enter element {0}", i + 1);
                arr1[i] = float.Parse(Console.ReadLine());
            }
            #endregion
            #region Check for duplicates
            int duplicateCount = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                int count = 0;

                for (int j = i + 1; j < arr1.Length; j++)
                {
                    if (arr1[i] == arr1[j])
                    {
                        count++;
                        arr1[j] = int.MinValue; // mark as visited
                    }
                }

                if (count > 0 && arr1[i] != int.MinValue)
                    duplicateCount++;
            }
            Console.WriteLine("Dupilcate count = {0}", duplicateCount);
            Console.WriteLine(arr1);
            #endregion            
        }


        /// <summary>
        /// T7- Write a C# program to print all unique items in an array.
        /// For Example:
        /// Array: {1, 1, 1, 5, -12, -12}
        /// Expected output: {1, 5, -12}
        /// </summary>
        static void T7()
        {
            #region Input array
            Console.WriteLine("Please enter array length");
            int Array_length = int.Parse(Console.ReadLine());
            float[] arr1 = new float[Array_length];

            for (int i = 0; i < Array_length; i++)
            {
                Console.WriteLine("Please enter element {0}", i + 1);
                arr1[i] = float.Parse(Console.ReadLine());
            }
            #endregion
            #region Print unique items
            int count = 0;
            bool[] visited = new bool[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                if (!visited[i]) // if not already processed
                {
                    Console.Write(arr1[i] + " ");
                    // mark all later duplicates of arr1[i] as visited
                    for (int j = i + 1; j < arr1.Length; j++)
                    {
                        if (arr1[i] == arr1[j])
                            visited[j] = true;
                    }
                }
            }
            #endregion
        }


        /// <summary>
        /// T8- Write a C# program to sort items of an array in descending order.
        /// </summary>
        static void T8()
        {
            #region Input array
            Console.WriteLine("Please enter array length");
            int Array_length = int.Parse(Console.ReadLine());
            float[] arr1 = new float[Array_length];

            for (int i = 0; i < Array_length; i++)
            {
                Console.Write("Please enter element {0}: ", i + 1);
                arr1[i] = float.Parse(Console.ReadLine());
            }
            #endregion
            #region Bubble Sort (Descending)
            float temp;
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                for (int j = i + 1; j < arr1.Length; j++)
                {
                    if (arr1[i] < arr1[j]) // Descending: swap if current < next
                    {
                        temp = arr1[i];
                        arr1[i] = arr1[j];
                        arr1[j] = temp;
                    }
                }
            }
            #endregion                                 
            #region Output
            Console.WriteLine("\nArray in descending order:");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }
            #endregion
        }


        /// <summary>
        /// T9- Write a C# program to add two Matrices of the same size and print the resultant Matrix.
        /// </summary>
        static void T9()
        {
            #region Matrix 1 input
            Console.WriteLine("Matrix 1:");
                        Console.WriteLine("Please enter array rows:");
                        int Array_rows_1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter array columns:");
                        int Array_columns_1 = int.Parse(Console.ReadLine());

                        int[,] arr1 = new int[Array_rows_1, Array_columns_1];

                        for (int i = 0; i < Array_rows_1; i++)
                        {                            
                            string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            for (int j = 0; j < Array_columns_1; j++)
                            {
                                arr1[i, j] = int.Parse(parts[j]);
                            }
                        }
            #endregion
            #region Matrix 2 input
            Console.WriteLine("Matrix 2:");
            Console.WriteLine("Please enter array rows:");
            int Array_rows_2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter array columns:");
            int Array_columns_2 = int.Parse(Console.ReadLine());

            int[,] arr2 = new int[Array_rows_2, Array_columns_2];

            for (int i = 0; i < Array_rows_2; i++)
            {                
                string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < Array_columns_2; j++)
                {
                    arr2[i, j] = int.Parse(parts[j]);
                }
            }
            #endregion
            #region check if same dimension
            if (Array_columns_1 == Array_columns_2 && Array_rows_1 == Array_rows_2)
            {
                // print matrix
                Console.WriteLine("\nMatrix1:");
                for (int i = 0; i < Array_rows_1; i++)
                {
                    for (int j = 0; j < Array_columns_1; j++)
                    {
                        Console.Write(arr1[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nMatrix2:");
                for (int i = 0; i < Array_rows_2; i++)
                {
                    for (int j = 0; j < Array_columns_1; j++)
                    {
                        Console.Write(arr2[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            else
            {
                Console.WriteLine("Cannot add the matrices as they are of different dimensions!!");
            }
            #endregion
            #region add matrices
            int[,] arr3 = new int[Array_rows_2, Array_columns_2];
            for (int i = 0; i < Array_rows_2; i++)
            {
                for (int j = 0; j < Array_columns_2; j++)
                {
                    arr3[i, j] = arr2[i, j] + arr1[i, j];
                }
            }

            Console.WriteLine("\nMatrix sum:");
            for (int i = 0; i < Array_rows_2; i++)
            {
                for (int j = 0; j < Array_columns_1; j++)
                {
                    Console.Write(arr3[i, j] + "\t");
                }
                Console.WriteLine();
            }
            #endregion
        }
        


        /// <summary>
        /// T10- Write a C# program to find the sum of the Right Diagonal of a given matrix.
        /// </summary>
        static void T10()
        {
            #region Matrix 1 input
            Console.WriteLine("Matrix 1:");
            Console.WriteLine("Please enter array rows:");
            int Array_rows_1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter array columns:");
            int Array_columns_1 = int.Parse(Console.ReadLine());

            int[,] arr1 = new int[Array_rows_1, Array_columns_1];

            for (int i = 0; i < Array_rows_1; i++)
            {
                string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < Array_columns_1; j++)
                {
                    arr1[i, j] = int.Parse(parts[j]);
                }
            }
            #endregion
            #region Right digonal sum
            int sum = 0;
            for (int i = 0; i < Array_rows_1; i++)
            {
                int j = Array_columns_1 - 1 - i;  // column index for right diagonal
                sum += arr1[i, j];
            }
            Console.WriteLine("Sum = {0}", sum);
            #endregion
        }


        /// <summary>
        /// T11- Write a C# program to check whether a given matrix is an Identity Matrix or not.
        static void T11()
        {
            #region Matrix 1 input
            Console.WriteLine("Matrix 1:");
            Console.WriteLine("Please enter array rows:");
            int Array_rows_1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter array columns:");
            int Array_columns_1 = int.Parse(Console.ReadLine());

            int[,] arr1 = new int[Array_rows_1, Array_columns_1];

            for (int i = 0; i < Array_rows_1; i++)
            {
                string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < Array_columns_1; j++)
                {
                    arr1[i, j] = int.Parse(parts[j]);
                }
            }
            #endregion
            #region Check identity matrix 
            int count = 0;
            for (int i = 0; i < Array_rows_1; i++)
            {
                for (int j = 0; j < Array_columns_1; j++)
                {
                    if (i == j) {if (arr1[i, j] != 1) { count++; }}
                    else { if (arr1[i, j] != 0) { count++; } }
                }
            }
            if (count > 0)
            {
                Console.WriteLine("Not identity matrix!!");
            }
            else
            {
                Console.WriteLine("Identity matrix");
            }
            #endregion
        }

        /// <summary>
        /// T12- Write a C# program to multiply two Square Matrices and print the resultant Matrix.
        /// Note: Search for the mathematical approach to multiply two Matrices.
        /// </summary>
        static void T12()
        {
            #region Matrix 1 input
            Console.WriteLine("Matrix 1:");
            Console.Write("Enter number of rows: ");
            int rows1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int cols1 = int.Parse(Console.ReadLine());

            int[,] matrix1 = new int[rows1, cols1];

            for (int i = 0; i < rows1; i++)
            {                
                string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols1; j++)
                {
                    matrix1[i, j] = int.Parse(parts[j]);
                }
            }
            #endregion

            #region Matrix 2 input
            Console.WriteLine("\nMatrix 2:");
            Console.Write("Enter number of rows: ");
            int rows2 = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int cols2 = int.Parse(Console.ReadLine());

            int[,] matrix2 = new int[rows2, cols2];

            for (int i = 0; i < rows2; i++)
            {                
                string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols2; j++)
                {
                    matrix2[i, j] = int.Parse(parts[j]);
                }
            }
            #endregion

            #region Check if multiplication is possible
            if (cols1 != rows2)
            {
                Console.WriteLine("\nCannot multiply the matrices: columns of matrix 1 must equal rows of matrix 2.");
                return;
            }
            #endregion

            #region Multiply matrices
            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            #endregion

            #region Print matrices
            Console.WriteLine("\nMatrix 1:");
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Console.Write(matrix1[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nMatrix 2:");
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    Console.Write(matrix2[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nResult Matrix:");
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}
