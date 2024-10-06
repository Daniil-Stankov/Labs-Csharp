using System;
using System.IO;

class Program
{
    // Функція для складання абревіатури з перших букв слів
    static string CreateAbbreviation(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        string abbreviation = "";
        bool isNewWord = true;

        for (int i = 0; i < input.Length; i++)
        {
            if (isNewWord && char.IsLetter(input[i]))
            {
                abbreviation += input[i];
                isNewWord = false;
            }

            if (input[i] == ' ')
            {
                isNewWord = true;
            }
        }

        return abbreviation.ToUpper();
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення рядка
        Console.Write("Введіть текстовий рядок: ");
        string input = Console.ReadLine();

        // Виклик функції для складання абревіатури
        string result = CreateAbbreviation(input);

        // Запис результату в двійковий файл
        string binaryFilePath = "output5.dat";
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
