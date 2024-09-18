using System;

class Program
{
    static void Main()
    {
        // Встановлення кодування UTF-8 для підтримки символів псевдографіки
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення кількості сплавів
        Console.Write("Введіть кількість сплавів: ");
        int count = int.Parse(Console.ReadLine());

        // Масиви для збереження даних
        string[] alloys = new string[count];
        double[] resistances = new double[count];
        double[] tempCoefficients = new double[count];
        int[] maxTemperatures = new int[count];

        // Введення даних
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введіть дані для сплаву {i + 1}:");
            Console.Write("Назва сплаву: ");
            alloys[i] = Console.ReadLine();
            Console.Write("Омічний опір (ом*кв.мм/м): ");
            resistances[i] = double.Parse(Console.ReadLine());
            Console.Write("Температурний коефіцієнт опору (1/град): ");
            tempCoefficients[i] = double.Parse(Console.ReadLine());
            Console.Write("Максимальна температура (°C): ");
            maxTemperatures[i] = int.Parse(Console.ReadLine());
        }

        // Відображення таблиці
        DrawTable(alloys, resistances, tempCoefficients, maxTemperatures);

        // Секція з одиницями вимірювання
        DrawUnitsSection();
    }

    static void DrawTable(string[] alloys, double[] resistances, double[] tempCoefficients, int[] maxTemperatures)
    {
        // Заголовки стовпців
        var headers = new string[] {
            "Сплав", "Омічний опір (ом*кв.мм/м)", "Температурний коефіцієнт опору (1/град)", "Максимальна температура (°C)"
        };

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Відображення верхньої межі таблиці
        Console.WriteLine("┌───────────────────┬──────────────────────────┬──────────────────────────────────────────────┬──────────────────────────────┐");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        // Відображення заголовків
        Console.WriteLine($"│ {headers[0],-17} │ {headers[1],-25}│ {headers[2],-44} │ {headers[3],-29}│");

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Відображення роздільної лінії
        Console.WriteLine("├───────────────────┼──────────────────────────┼──────────────────────────────────────────────┼──────────────────────────────┤");

        // Відображення рядків даних
        for (int i = 0; i < alloys.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"│ {alloys[i],-17} │ {resistances[i],-25}│ {tempCoefficients[i],-44} │{maxTemperatures[i],-30}│");
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Відображення лінії перед секцією з одиницями вимірювання
        Console.WriteLine("├───────────────────┴──────────────────────────┴──────────────────────────────────────────────┴──────────────────────────────┤");
    }

    static void DrawUnitsSection()
    {
        // Секція з одиницями вимірювання
        string units = "Одиниці вимірювання: опір – ом*кв.мм/м; температурний коефіцієнт опору – 1/град; температура – °C";

        Console.ForegroundColor = ConsoleColor.Magenta;
        // Відображення секції з одиницями вимірювання
        Console.WriteLine($"│ {units,-123}│");

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Нижня межа таблиці
        Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
    }
}
