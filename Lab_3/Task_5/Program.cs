using System;

class Program
{
    // Функція для складання абревіатури з перших букв слів
    static string CreateAbbreviation(string input)
    {
        // Перевірка на null або порожній рядок
        if (string.IsNullOrEmpty(input))
        {
            return ""; // Якщо рядок порожній, повертаємо порожню абревіатуру
        }

        // Створюємо змінну для збереження абревіатури
        string abbreviation = "";

        // Розбиваємо рядок на слова за пробілами
        bool isNewWord = true;
        for (int i = 0; i < input.Length; i++)
        {
            if (isNewWord && char.IsLetter(input[i]))
            {
                abbreviation += input[i]; // Додаємо першу букву кожного слова
                isNewWord = false; // Позначаємо, що ми всередині слова
            }

            // Перевіряємо, коли починається нове слово
            if (input[i] == ' ')
            {
                isNewWord = true;
            }
        }

        // Повертаємо отриману абревіатуру
        return abbreviation.ToUpper(); // Перетворюємо в верхній регістр
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення рядка
        Console.Write("Введіть текстовий рядок: ");
        string input = Console.ReadLine();

        // Виклик функції для складання абревіатури
        string result = CreateAbbreviation(input);

        // Виведення результату
        Console.WriteLine($"Абревіатура: {result}");
    }
}
