using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення кількості рядків і стовпців матриці
        Console.Write("Введіть кількість рядків матриці: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців матриці: ");
        int cols = int.Parse(Console.ReadLine());

        // Ініціалізація матриці
        int[][] matrix = new int[rows][];
        Random rand = new Random(); // Генератор випадкових чисел

        // Заповнення матриці випадковими числами в діапазоні від 0 до 10
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                matrix[i][j] = rand.Next(0, 11); // Випадкові числа від 0 до 10
            }
        }

        // Виведення згенерованої матриці
        Console.WriteLine("\nЗгенерована матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i][j],3} ");
            }
            Console.WriteLine();
        }

        // Введення порогового значення для порівняння з середнім арифметичним
        Console.Write("\nВведіть порогове значення: ");
        double threshold = double.Parse(Console.ReadLine());

        // Підрахунок кількості рядків, середнє арифметичне яких менше за порогове значення
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
            double sum = 0;
            for (int j = 0; j < cols; j++)
            {
                sum += matrix[i][j];
            }

            double average = sum / cols;

            if (average < threshold)
            {
                count++;
            }
        }

        // Виведення результату
        Console.WriteLine($"\nКількість рядків, середнє арифметичне яких менше за {threshold}: {count}");
    }
}
