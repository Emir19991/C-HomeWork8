// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] CreateMatrixFormula(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            matrix[i, j] = rnd.Next(min, max + 1); 
        }
    }
    return matrix;
}


void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j] + ""} "); 
        }
        Console.WriteLine();
    }
}

int Sumlements(int[,] matrix, int i)
{
  int sumLine = matrix[i,0];
  for (int j = 1; j < matrix.GetLength(1); j++)
  {
    sumLine += matrix[i,j];
  }
  return sumLine;
}




int MinSumElements(int[,] matrix)
{
    int minSumLine = 0;
    int sum = Sumlements(matrix, 0);

    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int temp = Sumlements(matrix, i);
        if (sum > temp)
        {
            sum = temp;
            minSumLine = i;
        }
    }
    return minSumLine;     
}

int[,] array2d = CreateMatrixFormula(4, 4, 1, 9);
PrintMatrix(array2d);

int minSumElements = MinSumElements(array2d);
Console.WriteLine($"Наименьшая сумма в строке {minSumElements + 1}");   

