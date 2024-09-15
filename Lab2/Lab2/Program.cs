using System;

class Program
{
    static void Main()
    {
        try
        {
            // Ввод данных
            Console.Write("Введите значения x и y: ");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            // Константы
            double a = 120;
            double b = 1;

            // Переменные для хранения результатов
            double t1, t2;

            // Проверка на ошибки перед вычислением
            if (x < 0)
            {
                throw new ArgumentException("Значение x не может быть отрицательным, так как под знаком квадратного корня.");
            }
            if (y == 0)
            {
                throw new DivideByZeroException("Значение y не может быть равно нулю, так как оно используется в знаменателе.");
            }

            // Вычисление t1
            t1 = (2 / (Math.Pow(a, 2) * y * Math.Sqrt(x))) + ((3 * Math.Pow(b, 2) * Math.Sqrt(x)) / (y * Math.Pow(a, 4)));

            // Вычисление t2
            double ax = a * x;

            // Проверка значений для синуса и тангенса
            if (Math.Sin(ax) == 0)
            {
                throw new ArithmeticException("Синус ax равен нулю, что вызвало деление на ноль.");
            }

            if (Math.Tan(ax / 2) <= 0)
            {
                throw new ArithmeticException("Тангенс аргумента ax/2 принимает недопустимое значение.");
            }

            t2 = (1 / a) * (Math.Log(Math.Tan(ax / 2)) - (1 / Math.Sin(ax)));

            // Вывод результатов
            Console.WriteLine($"t1 = {t1}");
            Console.WriteLine($"t2 = {t2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введенные данные не являются числовыми значениями.");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine($"Математическая ошибка: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Завершение программы.");
        }
    }
}
