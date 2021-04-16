using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nRowIdx = dimensions[0];
            int mColIdx = dimensions[1];

            char[,] matrix = new char[nRowIdx, mColIdx];
            string snake = Console.ReadLine();
            Queue<char> snakeQueue = CreateQueue(snake);
            char[,]filledMatrix = FillMatrix(matrix, snakeQueue);            

            PrintMatrix(filledMatrix);
        }

        private static char[,] FillMatrix(char[,] matrix, Queue<char> snakeQueue)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char currLetter = snakeQueue.Peek();   // SoftUni
                        snakeQueue.Enqueue(currLetter);       // SoftUniS
                        matrix[row, col] = snakeQueue.Dequeue(); //oftUniS                   
                    }
                }
                else if (row % 2 == 1)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char currLetter = snakeQueue.Peek();   // SoftUni
                        snakeQueue.Enqueue(currLetter);       // SoftUniS
                        matrix[row, col] = snakeQueue.Dequeue(); //oftUniS                   
                    }
                }
            }

            return matrix;
        }

        private static Queue<char> CreateQueue(string snake)
        {
            Queue<char> filledQueue = new Queue<char>();

            for (int i = 0; i < snake.Length; i++)
            {
                filledQueue.Enqueue(snake[i]);
            }

            return filledQueue;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int rol = 0; rol < matrix.GetLength(0); rol++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[rol, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
