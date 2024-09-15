using System;

class Program
{
    static void Main()
    {
        // Ввод координат
        Console.Write("Введите координату x: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Введите координату y: ");
        double y = double.Parse(Console.ReadLine());

        // Логические выражения для первой и второй областей
        bool inFirstRegion = (x * x + y * y >= 1) && (x <= 0) && (y >= 0);
        bool inSecondRegion = (x > 0) && (y > 0) && (x < 1) && (y < 1);

        // Вывод результата с использованием тернарного оператора
        Console.WriteLine(inFirstRegion || inSecondRegion ?
            "Точка потрапляє в задану область." :
            "Точка не потрапляє в задану область.");
    }
}
