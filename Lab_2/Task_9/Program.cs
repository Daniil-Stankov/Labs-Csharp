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

        int? firstPositiveRowIndex = null;

        // Ініціалізація матриці
        int[][] matrix = new int[rows][];
        Random rand = new Random(); // Генератор випадкових чисел

        // Заповнення матриці випадковими числами в діапазоні від -100 до 5
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                matrix[i][j] = rand.Next(-100, 6); // Випадкові числа від -100 до 5
            }
        }

        // Виведення згенерованої матриці
        Console.WriteLine("\nЗгенерована матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i][j],4} ");
            }
            Console.WriteLine();
        }

        // Пошук першого рядка, що містить хоча б один додатний елемент
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] > 0)
                {
                    firstPositiveRowIndex = i + 1; // Додаємо 1, щоб нумерація починалася з 1
                    break;
                }
            }
            if (firstPositiveRowIndex != null)
                break;
        }

        // Виведення результату
        if (firstPositiveRowIndex != null)
        {
            Console.WriteLine($"\nПерший рядок, який містить хоча б один додатний елемент: {firstPositiveRowIndex}");
        }
        else
        {
            Console.WriteLine("\nУ матриці немає додатних елементів.");
        }

        // Виведення всіх додатних елементів матриці
        Console.WriteLine("\nУсі додатні елементи матриці:");
        bool hasPositiveElements = false;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] > 0)
                {
                    Console.Write($"{matrix[i][j],4} ");
                    hasPositiveElements = true;
                }
            }
        }

        if (!hasPositiveElements)
        {
            Console.WriteLine("Додатні елементи відсутні.");
        }
    }
}
