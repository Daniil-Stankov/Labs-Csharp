using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Ініціалізація масиву з випадковими числами
        Random rand = new Random();
        int[] array = new int[100];

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

        // Обчислюємо середнє для додатних і від'ємних елементів
        double avgPositive = positiveElements.Length > 0 ? positiveElements.Average() : 0;
        double avgNegative = negativeElements.Length > 0 ? negativeElements.Average() : 0;

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
