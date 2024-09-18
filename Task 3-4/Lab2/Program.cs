using System;

class Program
{
    static void Main()
    {
        // Встановлення кодування UTF-8 для підтримки символів псевдографіки
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // Введення даних
            Console.Write("Введіть значення x і y: ");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            // Константи
            double a = 120;
            double b = 1;

            // Змінні для збереження результатів
            double t1, t2;

            // Перевірка на помилки перед обчисленням
            if (x < 0)
            {
                throw new ArgumentException("Значення x не може бути від'ємним, оскільки під знаком квадратного кореня.");
            }
            if (y == 0)
            {
                throw new DivideByZeroException("Значення y не може бути рівним нулю, оскільки воно використовується в знаменнику.");
            }

            // Обчислення t1
            t1 = (2 / (Math.Pow(a, 2) * y * Math.Sqrt(x))) + ((3 * Math.Pow(b, 2) * Math.Sqrt(x)) / (y * Math.Pow(a, 4)));

            // Обчислення t2
            double ax = a * x;

            // Перевірка значень для синуса та тангенса
            if (Math.Sin(ax) == 0)
            {
                throw new ArithmeticException("Синус ax дорівнює нулю, що спричинило ділення на нуль.");
            }

            if (Math.Tan(ax / 2) <= 0)
            {
                throw new ArithmeticException("Тангенс аргументу ax/2 приймає недопустиме значення.");
            }

            t2 = (1 / a) * (Math.Log(Math.Tan(ax / 2)) - (1 / Math.Sin(ax)));

            // Виведення результатів
            Console.WriteLine($"t1 = {t1}");
            Console.WriteLine($"t2 = {t2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: введені дані не є числовими значеннями.");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine($"Математична помилка: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Виникла непередбачена помилка: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Завершення програми.");
        }
    }
}
