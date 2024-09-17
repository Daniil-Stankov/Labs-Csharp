using System;

class Program
{
    static void Main()
    {
        // Встановлення кодування UTF-8 для підтримки символів псевдографіки
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Введення координат
        Console.Write("Введіть координату x: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Введіть координату y: ");
        double y = double.Parse(Console.ReadLine());

        // Логічні виражения для першої та другої областей
        bool inFirstRegion = (x * x + y * y >= 1) && (x <= 0) && (y >= 0);
        bool inSecondRegion = (x > 0) && (y > 0) && (x < 1) && (y < 1);

        // Вивід результата с використанням тернарного оператора
        Console.WriteLine(inFirstRegion || inSecondRegion ?
            "Точка потрапляє в задану область." :
            "Точка не потрапляє в задану область.");
    }
}
