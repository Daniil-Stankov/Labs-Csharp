using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // Запит розміру колекції від користувача
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Введіть розмір колекції: ");
            int listSize = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (listSize <= 0)
            {
                throw new ArgumentException("Розмір колекції повинен бути більше нуля.");
            }

            // Ініціалізація колекції з випадковими числами заданого розміру
            Random rand = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                numbers.Add(rand.Next(-100, 101)); // Заповнення колекції числами від -100 до 100
            }

            // Виведення початкової колекції
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Початкова колекція:");
            PrintList(numbers);
            Console.ResetColor();

            // Розділяємо додатні і від'ємні елементи
            var positiveElements = numbers.Where(x => x > 0).ToList();
            var negativeElements = numbers.Where(x => x < 0).ToList();

            // Перевірка на наявність елементів, щоб уникнути помилок ділення
            if (positiveElements.Count == 0 || negativeElements.Count == 0)
            {
                throw new InvalidOperationException("У колекції немає додатних або від'ємних елементів для обчислення середнього.");
            }

            // Обчислюємо середнє для додатних і від'ємних елементів
            double avgPositive = positiveElements.Average();
            double avgNegative = negativeElements.Average();

            // Виведення розрахованих середніх значень з кольорами
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСереднє додатних елементів: {avgPositive:F2}");
            Console.WriteLine($"Середнє від'ємних елементів: {avgNegative:F2}");
            Console.ResetColor();

            // Обмежуємо значення елементів колекції
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > avgPositive)
                {
                    numbers[i] = (int)avgPositive;
                }
                else if (numbers[i] < avgNegative)
                {
                    numbers[i] = (int)avgNegative;
                }
            }

            // Виведення результату після обмеження значень
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nКолекція після обмеження значень:");
            PrintListWithColors(numbers, avgPositive, avgNegative);
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

    // Метод для виведення колекції на екран
    static void PrintList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write($"{list[i],5}");
            if ((i + 1) % 10 == 0) // Виведення по 10 елементів в рядок
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }

    // Метод для виведення колекції з кольорами
    static void PrintListWithColors(List<int> list, double avgPositive, double avgNegative)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == (int)avgPositive)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Додатні елементи, що перевищували середнє
            }
            else if (list[i] == (int)avgNegative)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Від'ємні елементи, що були менші за середнє
            }
            else
            {
                Console.ResetColor(); // Інші елементи
            }

            Console.Write($"{list[i],5}");

            if ((i + 1) % 10 == 0) // Виведення по 10 елементів в рядок
            {
                Console.WriteLine();
            }
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}
