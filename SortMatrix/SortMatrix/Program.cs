using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MatrixOperations_JaggedArray
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Input length of array: ");
            int digits = Int32.Parse(Console.ReadLine());
            int[] arr = new int[digits];
            string primaryArr = null;
            string answer = null;
            int max = 0;
            Console.WriteLine("Which way do you prefer: \n\"random\" - Input by Random;\n\"hand\" - Input by hand");
            string key = Convert.ToString(Console.ReadLine().Trim());
            switch (key)
            {
                case "random":
                    Random random = new Random();
                    arr[0] = random.Next(-100, 100);
                    primaryArr = primaryArr + arr[0] + ' ';
                    max = arr[0];
                    for (int i = 1; i < digits; i++)
                    {
                        arr[i] = random.Next(-100, 100);
                        primaryArr = primaryArr + arr[i] + ' ';
                        if (max < arr[i])
                        {
                            max = arr[i];
                        }
                    }
                    break;
                case "hand":
                    Console.WriteLine("Input array: ");
                    string[] value = Console.ReadLine().Trim().Split();
                    arr[0] = Convert.ToInt32(value[0]);
                    primaryArr = primaryArr + arr[0] + ' ';
                    max = arr[0];
                    for (int i = 1; i < digits; i++)
                    {
                        arr[i] = Convert.ToInt32(value[i]);
                        primaryArr = primaryArr + arr[i] + ' ';
                        if (max < arr[i])
                        {
                            max = arr[i];
                        }
                    }
                    break;
                default: break;
            }
            Console.WriteLine("\nPrimary Array: {0}\nArray langth - {1}", primaryArr, digits);
            int counter = 0;
            if (max % 2 == 0)
            {
                int[] finalArr = new int[arr.Length];
                for (int i = 0; i < digits; i++)
                {
                    if (arr[i] == max)
                    {
                        Array.Resize(ref finalArr, finalArr.Length + 1);
                        finalArr[i] = arr[i] / 2;
                        finalArr[i + 1] = arr[i] / 2;
                        answer = answer + finalArr[i] + ' ' + finalArr[i + 1] + ' ';
                        counter += 2;
                    }
                    else
                    {
                        finalArr[i] = arr[i];
                        answer = answer + arr[i] + ' ';
                        counter++;
                    }
                }
                Console.WriteLine("\nAnswer: {0}\nArray langth - {1}", answer, finalArr.Length);
            }
            else
                Console.WriteLine("\nAnswer: {0}\nArray langth - {1}", primaryArr, arr.Length);
        }

        static void Task2()
        {
            Console.WriteLine("Input amount of Columns: ");
            int colomns = Int32.Parse(Console.ReadLine());
            int[][] arr = new int[colomns][];
            string primaryArr = null;
            string answer = null;
            int maxValue = 0;
            int maxPlace = 0;
            for (int i = 0; i < colomns; i++)
            {
                Console.WriteLine("Input elements {0} row" + " (all in one line through spaces)", i);
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(" ∖".ToCharArray(), StringSplitOptions.RemoveEmptyEntries), int.Parse);
                primaryArr = primaryArr + arr[i][0] + ' ';
                int max = arr[i][0];
                for (int j = 1; j < arr[i].Length; j++)
                {
                    if (max < arr[i][j])
                    {
                        max = arr[i][j];
                    }
                    if (maxValue < max)
                    {
                        maxValue = arr[i][j];
                        maxPlace = i;
                    }
                    primaryArr = primaryArr + arr[i][j] + ' ';
                }
                primaryArr = primaryArr + '\n';
            }

            int[][] arrCopy = new int[colomns + 1][];

            for (int i = 0; i <= maxPlace; i++)
            {
                arrCopy[i] = new int[arr[i].Length];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    int temp = arr[i][j];

                    arrCopy[i][j] = temp;
                    answer = answer + arrCopy[i][j] + ' ';
                }
                answer = answer + '\n';
            }
            arrCopy[maxPlace + 1] = new int[arr[maxPlace].Length + 1];
            for (int i = 0; i < (arr[maxPlace].Length) + 1; i++)
            {
                arrCopy[maxPlace + 1][i] = 0;
                answer = answer + arrCopy[maxPlace + 1][i] + ' ';
            }
            answer = answer + '\n';
            for (int i = maxPlace + 1; i < colomns; i++)
            {
                arrCopy[i] = new int[arr[i].Length];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    int temp = arr[i][j];
                    arrCopy[i][j] = temp;
                    answer = answer + arrCopy[i][j] + ' ';
                }
                answer = answer + '\n';
            }

            Console.WriteLine("\nPrimary Array:\n{0}", primaryArr);
            Console.WriteLine("Answer:\n{0}\n", answer);

        }

        static void Task3()
        {
            Console.WriteLine("Input amount of Rows and Columns: ");
            string[] value = Console.ReadLine().Trim().Split();
            int rows = Convert.ToInt32(value[0]);
            int columns = Convert.ToInt32(value[1]);
            string firstMatrix = null;
            string oddNumbers = null;
            int[,] matrix = new int[rows, columns]; //Create Matrix
            int[][] oddMatrix = new int[rows][];
            int globalCounter = 0;
            Console.WriteLine("Which way do you prefer: \n\"random\" - Input by Random;\n\"hand\" - Input by hand");
            string key = Convert.ToString(Console.ReadLine().Trim());
            switch (key)
            {
                case "random":
                    for (int i = 0; i < rows; i++) //Filling Matrix
                    {
                        Random random = new Random();
                        int oddCounter = 0;
                        int oddIndex = 0;
                        for (int j = 0; j < columns; j++)
                        {
                            matrix[i, j] = random.Next(-100, 100);
                            if (Math.Abs(matrix[i, j] % 2) == 1)
                            {
                                oddIndex++;
                            }
                        }
                        oddMatrix[i] = new int[oddIndex];
                        for (int j = 0; j < columns; j++)
                        {
                            if (Math.Abs(matrix[i, j] % 2) == 1)
                            {
                                oddMatrix[i][oddCounter] = matrix[i, j];
                                oddNumbers = oddNumbers + matrix[i, j] + ' ';
                                oddCounter++;
                            }
                            firstMatrix = firstMatrix + matrix[i, j] + ' ';
                        }
                        globalCounter += oddCounter;
                        firstMatrix = firstMatrix + '\n';
                        oddNumbers = oddNumbers + '\n';
                    }
                    break;
                case "hand":
                    Console.WriteLine("Input matrix {0} x {1}", rows, columns);
                    for (int i = 0; i < rows; i++)
                    {
                        oddMatrix[i] = new int[columns];
                        value = Console.ReadLine().Trim().Split(); //Filling Matrix
                        int oddCounter = 0;
                        int oddIndex = 0;
                        for (int j = 0; j < columns; j++)
                        {
                            matrix[i, j] = Convert.ToInt32(value[j]);
                            if (Math.Abs(matrix[i, j] % 2) == 1)
                            {
                                oddIndex++;
                            }
                        }
                        oddMatrix[i] = new int[oddIndex];
                        for (int j = 0; j < columns; j++)
                        {
                            if (Math.Abs(matrix[i, j] % 2) == 1)
                            {
                                oddMatrix[i][oddCounter] = matrix[i, j];
                                oddNumbers = oddNumbers + matrix[i, j] + ' ';
                                oddCounter++;
                            }
                            firstMatrix = firstMatrix + matrix[i, j] + ' ';
                        }
                        globalCounter += oddCounter;
                        firstMatrix = firstMatrix + '\n';
                        oddNumbers = oddNumbers + '\n';
                    }
                    break;

            }
            Console.WriteLine("\nPrimary Matrix:\n{0}", firstMatrix);
            string sortedOddMatrix = null;
            int counter = 0;
            int[] finalArray = new int[globalCounter]; //
            for (int i = 0; i < oddMatrix.Length; i++)
            {
                Array.Sort(oddMatrix[i]);
                for (int j = 0; j < oddMatrix[i].Length; j++)
                {
                    finalArray[counter] = oddMatrix[i][j];
                    sortedOddMatrix = sortedOddMatrix + oddMatrix[i][j] + ' ';
                    counter++;
                }
                sortedOddMatrix = sortedOddMatrix + '\n';
            }
            string oneDimensionalArray = null;
            string coincideIndex = null;
            for (int i = 0; i < finalArray.Length; i++)
            {
                oneDimensionalArray = oneDimensionalArray + finalArray[i] + ' ';
                if (finalArray[i] == i)
                {
                    coincideIndex = coincideIndex + i + ' ';
                }
            }
            Console.WriteLine("\nOnly odd numbers Array:\n{0}", oddNumbers);
            Console.WriteLine("\nSorted odd numbers Array:\n{0}", sortedOddMatrix);
            Console.WriteLine("\nArray converted to one dimensional Array:\n{0}", oneDimensionalArray);
            Console.WriteLine("\nValue coincide with index of the numbers:\n{0}\n", coincideIndex);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("1 - Divide by 2 max elem in array\n2 - Jagged array\n3 - Matrix operations");
            Console.WriteLine("Choose task: ");
            int key = Int32.Parse(Console.ReadLine());
            switch (key)
            {
                case 1: Program.Task1(); break; // If the maximum among the elements of the array is an even number V, then replace each of such maxima with two consecutive identical numbers V / 2(and if the maximum is odd, then leave the array unchanged)
                case 2: Program.Task2(); break; // Add a row after the row containing the largest element (if there are several elements in different places with the same maximum value, then take the first of them)
                case 3: Program.Task3(); break;
                // Rewrite only the odd elements from each row of the matrix P into the corresponding rows of the matrix Q.
                // Sort the rows of the resulting matrix Q in ascending order.
                // Form a one-dimensional array from the rows of the matrix Q and determine those elements whose values ​​coincide with their own index.
                default: break;
            }
        }
    }
}
