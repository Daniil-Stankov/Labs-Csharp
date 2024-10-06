using System;
using System.IO;

class Program
{
    // Функція для повторення кожного символу, окрім знака питання
    static string RepeatCharactersExceptQuestionMark(string input)
    {
        if (input == null || input.Length == 0)
        {
            return input; // Якщо рядок порожній, повертаємо його без змін
        }

        char[] result = new char[input.Length * 2];
        int index = 0;

        for (int i = 0; i < input.Length; i++)
        {
            result[index++] = input[i];
            if (input[i] != '?')
            {
                result[index++] = input[i];
            }
        }

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

        // Запис результату в двійковий файл
        string binaryFilePath = "output4.dat";
        using (BinaryWriter writer = new BinaryWriter(File.Open(binaryFilePath, FileMode.Create)))
        {
            writer.Write(result);
        }

        // Читання з двійкового файлу та виведення на екран
        Console.WriteLine("Зміст двійкового файлу:");
        using (BinaryReader reader = new BinaryReader(File.Open(binaryFilePath, FileMode.Open)))
        {
            string readResult = reader.ReadString();
            Console.WriteLine(readResult);
        }
    }
}
