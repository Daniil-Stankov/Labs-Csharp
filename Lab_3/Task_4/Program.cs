using System;

class Program
{
    // Функція для повторення кожного символу, окрім знака питання
    static string RepeatCharactersExceptQuestionMark(string input)
    {
        // Перевірка на null або порожній рядок
        if (input == null || input.Length == 0)
        {
            return input; // Якщо рядок порожній, повертаємо його без змін
        }

        // Створюємо новий масив символів для зберігання результату
        char[] result = new char[input.Length * 2]; // Максимальний розмір, якщо всі символи будуть повторені

        int index = 0;

        // Проходимо по кожному символу в рядку
        for (int i = 0; i < input.Length; i++)
        {
            result[index++] = input[i]; // Додаємо символ до масиву
            // Якщо символ не '?', повторюємо його
            if (input[i] != '?')
            {
                result[index++] = input[i];
            }
        }

        // Перетворюємо масив назад у рядок і повертаємо результат
        return new string(result, 0, index); 
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення рядка
        Console.Write("Введіть текстовий рядок: ");
        string input = Console.ReadLine();

        // Виклик функції для повторення кожного символу, окрім знака питання
        string result = RepeatCharactersExceptQuestionMark(input);

        // Виведення результату
        Console.WriteLine($"Результат: {result}");
    }
}
