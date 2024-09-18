using System;

class Program
{
    static void Main()
    {
        double x, y;
        short h;
        double step = 0.25;  // Крок для x

        // Встановлення кодування UTF-8 для підтримки символів псевдографіки
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Виведення заголовка таблиці
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Періодичний графік функції:");

        for (int n = 0; n < 5; n++) // 5 періодів
        {
            // Заголовок таблиці
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|   x   |      y     |");
            Console.WriteLine("|-------|------------|");

            // Цикл по кожному періоду
            for (x = 0; x < 4; x += step)
            {
                // Розрахунок значення y
                if (x < 2)
                {
                    y = Math.Sqrt(1 - Math.Pow((x - 1), 2)); // Півколо
                }
                else
                {
                    y = -1; // Горизонтальна лінія
                }

                // Виведення значень x і y
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"| {x + n * 4,5:F2} | {y,10:F7} |");

                // Визначення позиції точки на екрані
                h = (short)((y + 1) * 10);

                // Використання псевдографіки для побудови графіка
                Console.ForegroundColor = ConsoleColor.White;

                // Логіка для малювання графіка
                if (x < 1) // Перша частина півкола (зліва)
                {
                    Console.Write(new string(' ', h) + "\\ ");
                }
                else if (x < 2) // Друга частина півкола (справа)
                {
                    Console.Write(new string(' ', h) + " /");
                }
                else // Горизонтальна лінія
                {
                    Console.Write(new string(' ', h) + "|");
                }

                Console.WriteLine(); // Перехід на новий рядок
            }

            // Пауза для перегляду графіка
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Натисніть клавішу Enter для продовження...");
            Console.ReadLine(); // Очікування натискання клавіші
        }

        // Скидання кольорів до стандартних
        Console.ResetColor();
    }
}

