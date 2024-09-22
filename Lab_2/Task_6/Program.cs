using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення розмірів матриці з консолі
        Console.Write("Введіть кількість рядків матриці: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців матриці: ");
        int cols = int.Parse(Console.ReadLine());

        // Ініціалізація матриці з розмірами, заданими користувачем
        int[,] matrix = new int[rows, cols];
        int k = 1; // Лінійна послідовність чисел (ЛПЧ)

        // Заповнення матриці секторами вище та нижче діагоналей ЛПЧ
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j > i && j < cols - i - 1) // Сектори вище головної та побічної діагоналей
                {
                    matrix[i, j] = k++;
                }
                else if (j < i && j > cols - i - 1) // Сектори нижче головної та побічної діагоналей
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
        Console.WriteLine("\nМатриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],3} ");
            }
            Console.WriteLine();
        }
    }
}
