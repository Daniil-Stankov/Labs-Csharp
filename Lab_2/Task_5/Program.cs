using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        const int S = 9; // Розмір матриці 9x9
        int[,] matrix = new int[S, S]; // Створення квадратної матриці
        int k = 1; // Лінійна послідовність чисел (ЛПЧ)

        // Заповнення матриці секторами вище та нижче діагоналей ЛПЧ
        for (int i = 0; i < S; i++)
        {
            for (int j = 0; j < S; j++)
            {
                if (j > i && j < S - i - 1) // Сектори вище головної та побічної діагоналей
                {
                    matrix[i, j] = k++;
                }
                else if (j < i && j > S - i - 1) // Сектори нижче головної та побічної діагоналей
                {
                    matrix[i, j] = k++;
                }
                else
                {
                    matrix[i, j] = 0; // Залишок матриці заповнюємо нулями
                }
            }
        }

        // Виведення матриці
        Console.WriteLine("Матриця:");
        for (int i = 0; i < S; i++)
        {
            for (int j = 0; j < S; j++)
            {
                Console.Write($"{matrix[i, j],3} ");
            }
            Console.WriteLine();
        }
    }
}
