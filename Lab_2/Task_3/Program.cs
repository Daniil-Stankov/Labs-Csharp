using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // Запит розміру масиву від користувача
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Введіть розмір масиву: ");
            int arraySize = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (arraySize <= 0)
            {
                throw new ArgumentException("Розмір масиву повинен бути більше нуля.");
            }

            // Ініціалізація масиву з випадковими числами заданого розміру
            Random rand = new Random();
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 101); // Заповнення масиву числами від -100 до 100
            }

            // Виведення початкового масиву
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Початковий масив:");
            PrintArray(array);
            Console.ResetColor();

            // Розділяємо додатні і від'ємні елементи
            var positiveElements = array.Where(x => x > 0).ToArray();
            var negativeElements = array.Where(x => x < 0).ToArray();

            // Перевірка на наявність елементів, щоб уникнути помилок ділення
            if (positiveElements.Length == 0 || negativeElements.Length == 0)
            {
                throw new InvalidOperationException("У масиві немає додатних або від'ємних елементів для обчислення середнього.");
            }

            // Обчислюємо середнє для додатних і від'ємних елементів
            double avgPositive = positiveElements.Average();
            double avgNegative = negativeElements.Average();

            // Виведення розрахованих середніх значень з кольорами
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСереднє додатних елементів: {avgPositive:F2}");
            Console.WriteLine($"Середнє від'ємних елементів: {avgNegative:F2}");
            Console.ResetColor();

            // Обмежуємо значення елементів масиву
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > avgPositive)
                {
                    array[i] = (int)avgPositive;
                }
                else if (array[i] < avgNegative)
                {
                    array[i] = (int)avgNegative;
                }
            }

            // Виведення результату після обмеження значень
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nМасив після обмеження значень:");
            PrintArrayWithColors(array, avgPositive, avgNegative);
            Console.ResetColor();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Помилка: введені дані не є числовими значеннями.");
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Помилка: {ex.Message}");
            Console.ResetColor();
        }
        catch (InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Помилка: {ex.Message}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Непередбачена помилка: {ex.Message}");
            Console.ResetColor();
        }
    }

    // Метод для виведення масиву на екран
    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i],5}");
            if ((i + 1) % 10 == 0) // Виведення по 10 елементів в рядок
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }

    // Метод для виведення масиву з кольорами
    static void PrintArrayWithColors(int[] array, double avgPositive, double avgNegative)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == (int)avgPositive)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Додатні елементи, що перевищували середнє
            }
            else if (array[i] == (int)avgNegative)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Від'ємні елементи, що були менші за середнє
            }
            else
            {
                Console.ResetColor(); // Інші елементи
            }

            Console.Write($"{array[i],5}");

            if ((i + 1) % 10 == 0) // Виведення по 10 елементів в рядок
            {
                Console.WriteLine();
            }
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}
