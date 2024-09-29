using System;

class Program
{
    // Функція для вставки знаку питання після кожної букви
    static string InsertQuestionMarkAfterLetters(string input)
    {
        // Перевірка на null або порожній рядок
        if (input == null || input.Length == 0)
        {
            return input; // Якщо рядок порожній, повертаємо його без змін
        }

        // Створюємо новий масив символів для зберігання результату
        char[] result = new char[input.Length * 2]; // Кожна літера отримає додатковий символ '?'

        int index = 0; // Індекс для заповнення масиву результату

        // Проходимо по кожному символу в рядку
        for (int i = 0; i < input.Length; i++)
        {
            result[index++] = input[i]; // Копіюємо символ
            // Якщо символ є буквою, додаємо знак питання
            if (char.IsLetter(input[i]))
            {
                result[index++] = '?';
            }
        }

        // Перетворюємо масив назад у рядок і повертаємо результат
        return new string(result, 0, index); // Обрізаємо масив до заповненої довжини
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення рядка
        Console.Write("Введіть текстовий рядок: ");
        string input = Console.ReadLine();

        // Виклик функції для вставки знаку питання
        string result = InsertQuestionMarkAfterLetters(input);

        // Виведення результату
        Console.WriteLine($"Результат: {result}");
    }
}
