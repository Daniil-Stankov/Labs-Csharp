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
            Console.Write("Введіть розмір масиву: ");
            int arraySize = int.Parse(Console.ReadLine());

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
            Console.WriteLine("Початковий масив:");
            PrintArray(array);

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

            // Виведення результату
            Console.WriteLine("\nМасив після обмеження значень:");
            PrintArray(array);
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: введені дані не є числовими значеннями.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непередбачена помилка: {ex.Message}");
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
}
