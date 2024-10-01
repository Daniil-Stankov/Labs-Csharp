using System;

class Program
{
    // Функція для об'єднання двох рядків без використання бібліотечних функцій
    static string ConcatStrings(string str1, string str2)
    {
        if (str1 == null) str1 = "";
        if (str2 == null) str2 = "";

        // Довжина нового рядка буде рівна сумі довжин двох рядків
        int newLength = str1.Length + str2.Length;

        char[] result = new char[newLength];

        // Копіюємо символи першого рядка
        for (int i = 0; i < str1.Length; i++)
        {
            result[i] = str1[i];
        }

        // Копіюємо символи другого рядка
        for (int i = 0; i < str2.Length; i++)
        {
            result[str1.Length + i] = str2[i];
        }

        // Перетворюємо масив символів назад у рядок
        return new string(result);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення двох рядків
        Console.Write("Введіть перший рядок: ");
        string str1 = Console.ReadLine();

        Console.Write("Введіть другий рядок: ");
        string str2 = Console.ReadLine();

        // Виклик функції для додавання другого рядка в кінець першого
        string result = ConcatStrings(str1, str2);

        // Виведення результату
        Console.WriteLine($"Результат об'єднання: {result}");
    }
}
