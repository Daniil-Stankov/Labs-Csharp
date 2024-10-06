using System;
using System.IO;

class Program
{
    static string InsertQuestionMarkAfterLetters(string input)
    {
        if (input == null || input.Length == 0)
        {
            return input;
        }

        char[] result = new char[input.Length * 2];

        int index = 0;

        for (int i = 0; i < input.Length; i++)
        {
            result[index++] = input[i];
            if (char.IsLetter(input[i]))
            {
                result[index++] = '?';
            }
        }

        return new string(result, 0, index);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Читання з файлу
        string inputFilePath = @"D:\учеба\DOtNet (3 курс)\Repos\Lab_3\Task_3\input3.txt";
        string outputFilePath = @"D:\учеба\DOtNet (3 курс)\Repos\Lab_3\Task_3\output3.txt";

        if (File.Exists(inputFilePath))
        {
            string input = File.ReadAllText(inputFilePath).Trim();

            // Вставка знаку питання
            string result = InsertQuestionMarkAfterLetters(input);

            // Запис результату в файл
            File.WriteAllText(outputFilePath, $"Результат: {result}");
            Console.WriteLine("Результат записано у файл output3.txt");
        }
        else
        {
            Console.WriteLine("Файл не знайдено.");
        }
    }
}
