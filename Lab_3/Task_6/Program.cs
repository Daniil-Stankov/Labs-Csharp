using System;
using System.Text.RegularExpressions;

class Program
{
    // Функція для підрахунку кількості чисел у тексті
    static int CountNumbers(string input)
    {
        int count = 0;

        // Розбиваємо рядок на слова за пробілами
        string[] words = input.Split(' ');

        // Перевіряємо кожне слово, чи є воно числом
        foreach (string word in words)
        {
            // Використовуємо регулярний вираз для перевірки, чи слово є числом
            if (Regex.IsMatch(word, @"^-?\d+$"))
            {
                count++;
            }
        }

        return count;
    }

    // Функція для виведення слів, що складаються тільки з латинських літер
    static void PrintLatinWords(string input)
    {
        Console.WriteLine("Слова, що складаються тільки з латинських літер:");

        // Розбиваємо рядок на слова за пробілами
        string[] words = input.Split(' ');

        // Перевіряємо кожне слово, чи воно складається тільки з латинських літер
        foreach (string word in words)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine(word);
            }
        }
    }

    // Функція для видалення кожного другого слова
    static string RemoveEverySecondWord(string input)
    {
        // Розбиваємо рядок на слова за пробілами
        string[] words = input.Split(' ');

        // Створюємо новий рядок для збереження результату
        string result = "";

        // Додаємо до результату кожне перше, третє, п'яте і т.д. слово
        for (int i = 0; i < words.Length; i++)
        {
            if (i % 2 == 0)
            {
                result += words[i] + " ";
            }
        }

        // Видаляємо зайвий пробіл з кінця
        return result.Trim();
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення текстового рядка
        Console.Write("Введіть текстовий рядок: ");
        string input = Console.ReadLine();

        // а) Підрахунок кількості чисел у тексті
        int numberCount = CountNumbers(input);
        Console.WriteLine($"Кількість чисел у тексті: {numberCount}");

        // б) Виведення всіх слів, що складаються тільки з латинських літер
        PrintLatinWords(input);

        // в) Видалення кожного другого слова
        string result = RemoveEverySecondWord(input);
        Console.WriteLine($"Текст після видалення кожного другого слова: {result}");
    }
}
