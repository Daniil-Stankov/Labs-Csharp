using System;

class Program
{
    static void Main()
    {
        // Ввод количества строк
        Console.Write("Введите количество сплавов: ");
        int count = int.Parse(Console.ReadLine());

        // Массивы для хранения данных
        string[] alloys = new string[count];
        double[] resistances = new double[count];
        double[] tempCoefficients = new double[count];
        int[] maxTemperatures = new int[count];

        // Ввод данных
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите данные для сплава {i + 1}:");
            Console.Write("Название сплава: ");
            alloys[i] = Console.ReadLine();
            Console.Write("Омір (ом*мкм^2/м): ");
            resistances[i] = double.Parse(Console.ReadLine());
            Console.Write("Температурний коефіцієнт опору (1/град): ");
            tempCoefficients[i] = double.Parse(Console.ReadLine());
            Console.Write("Максимальна температура (°C): ");
            maxTemperatures[i] = int.Parse(Console.ReadLine());
        }

        // Отрисовка таблицы
        DrawTable(alloys, resistances, tempCoefficients, maxTemperatures);

        // Секция с единицами измерения
        DrawUnitsSection();
    }

    static void DrawTable(string[] alloys, double[] resistances, double[] tempCoefficients, int[] maxTemperatures)
    {
        // Заголовки колонок
        var headers = new string [] {
            "Сплав", "Омір (ом*кв.мм/м)", "Температурний коефіцієнт опору (1/град)", "Максимальна температура (°C)"
        };

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Отрисовка верхней границы таблицы
        Console.WriteLine("┌───────────────────┬──────────────────────────┬──────────────────────────────────────────────┬──────────────────────────────┐");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        // Отрисовка заголовков
        Console.WriteLine($"│ {headers[0],-17} │ {headers[1],-25}│ {headers[2],-44} │ {headers[3],-29}│");

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Отрисовка разделительной линии
        Console.WriteLine("├───────────────────┼──────────────────────────┼──────────────────────────────────────────────┼──────────────────────────────┤");

        // Отрисовка строк данных
        for (int i = 0; i < alloys.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"│ {alloys[i],-17} │ {resistances[i],-25}│ {tempCoefficients[i],-44} │{maxTemperatures[i],-30}│");
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Отрисовка линии перед секцией с единицами измерения
        Console.WriteLine("├───────────────────┴──────────────────────────┴──────────────────────────────────────────────┴──────────────────────────────┤");
    }

    static void DrawUnitsSection()
    {
        // Секция с единицами измерения
        string units = "Одиниці вимірювання: опір – ом*кв.мм/м; температурний коефіцієнт опору – 1/град; температура – рад.С";

        Console.ForegroundColor = ConsoleColor.Magenta;
        // Отрисовка секции с единицами измерения
        Console.WriteLine($"│ {units,-123}│");

        Console.ForegroundColor = ConsoleColor.Cyan;
        // Нижняя граница таблицы
        Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
    }
}
