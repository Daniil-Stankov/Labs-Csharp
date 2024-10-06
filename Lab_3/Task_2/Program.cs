using System;
using System.IO;

class Program
{
    static string ConcatStrings(string str1, string str2)
    {
        if (str1 == null) str1 = "";
        if (str2 == null) str2 = "";

        int newLength = str1.Length + str2.Length;
        char[] result = new char[newLength];

        for (int i = 0; i < str1.Length; i++)
        {
            result[i] = str1[i];
        }

        for (int i = 0; i < str2.Length; i++)
        {
            result[str1.Length + i] = str2[i];
        }

        return new string(result);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Читання з файлу
        string inputFilePath = @"D:\учеба\DOtNet (3 курс)\Repos\Lab_3\Task_2\input2.txt";
        string outputFilePath = @"D:\учеба\DOtNet (3 курс)\Repos\Lab_3\Task_2\output2.txt";

        if (File.Exists(inputFilePath))
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            if (lines.Length >= 2)
            {
                string str1 = lines[0].Trim();
                string str2 = lines[1].Trim();

                // Об'єднання рядків
                string result = ConcatStrings(str1, str2);

                // Запис результату в файл
                File.WriteAllText(outputFilePath, $"Результат об'єднання: {result}");
                Console.WriteLine("Результат записано у файл output2.txt");
            }
            else
            {
                Console.WriteLine("У файлі повинно бути як мінімум два рядки.");
            }
        }
        else
        {
            Console.WriteLine("Файл не знайдено.");
        }
    }
}
