using System;
using System.IO;

class Program
{
    // Функція переведення з десяткової системи у шістнадцяткову
    static string DecimalToHexadecimal(string decimalString)
    {
        if (!IsValidDecimalString(decimalString))
        {
            return "Некоректне десяткове число!";
        }

        int decimalNumber = StringToInt(decimalString);

        if (decimalNumber == 0)
        {
            return "0";
        }

        string hexResult = "";
        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 16;
            hexResult = GetHexCharacter(remainder) + hexResult;
            decimalNumber /= 16;
        }

        return hexResult;
    }

    static bool IsValidDecimalString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;

        foreach (char c in s)
        {
            if (c < '0' || c > '9')
            {
                return false;
            }
        }
        return true;
    }

    static int StringToInt(string s)
    {
        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result = result * 10 + (s[i] - '0');
        }
        return result;
    }

    static char GetHexCharacter(int remainder)
    {
        if (remainder < 10)
        {
            return (char)('0' + remainder);
        }
        else
        {
            return (char)('A' + (remainder - 10));
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Повний шлях до файлу (замініть на відповідний)
        string inputFilePath = @"D:\учеба\DOtNet (3 курс)\Repos\Lab_3\Task_1\input1.txt";
        string outputFilePath = @"D:\учеба\DOtNet (3 курс)\Repos\Lab_3\Task_1\output1.txt";

        // Перевірка наявності файлу
        if (File.Exists(inputFilePath))
        {
            // Читання з файлу
            string decimalString = File.ReadAllText(inputFilePath).Trim();

            // Перетворення у шістнадцяткову систему
            string hexResult = DecimalToHexadecimal(decimalString);

            // Запис результату в файл
            File.WriteAllText(outputFilePath, $"Шістнадцяткове представлення: {hexResult}");
            Console.WriteLine("Результат записано у файл output1.txt");
        }
        else
        {
            Console.WriteLine($"Файл {inputFilePath} не знайдено.");
        }
    }
}
