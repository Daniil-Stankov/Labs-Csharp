using System;

class Program
{
    // Функція переведення з десяткової системи у шістнадцяткову
    static string DecimalToHexadecimal(string decimalString)
    {
        // Перевірка на коректність введеного значення
        if (!IsValidDecimalString(decimalString))
        {
            return "Некоректне десяткове число!";
        }

        // Перетворення рядка в ціле число (без використання стандартної функції int.Parse)
        int decimalNumber = StringToInt(decimalString);

        if (decimalNumber == 0)
        {
            return "0";
        }

        // Переведення в шістнадцятковий формат
        string hexResult = "";
        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 16;
            hexResult = GetHexCharacter(remainder) + hexResult;
            decimalNumber /= 16;
        }

        return hexResult;
    }

    // Функція перевірки чи є рядок коректним цілим числом
    static bool IsValidDecimalString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;

        // Перевірка кожного символа, чи це число
        foreach (char c in s)
        {
            if (c < '0' || c > '9')
            {
                return false;
            }
        }
        return true;
    }

    // Функція для перетворення рядка у ціле число (без використання int.Parse)
    static int StringToInt(string s)
    {
        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result = result * 10 + (s[i] - '0');
        }
        return result;
    }

    // Функція для перетворення залишку на відповідний шістнадцятковий символ
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

        // Введення десяткового числа у вигляді рядка
        Console.Write("Введіть десяткове число: ");
        string decimalString = Console.ReadLine();

        // Виклик функції для переведення в шістнадцятковий формат
        string hexResult = DecimalToHexadecimal(decimalString);

        // Виведення результату
        Console.WriteLine($"Шістнадцяткове представлення: {hexResult}");
    }
}
