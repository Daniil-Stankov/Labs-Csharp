using System;

class Program
{
    static void Main(string[] args)
    {
        // Введення параметрів з клавіатури
        Console.Write("Введіть кількість членів ряду: ");
        int maxTerms = int.Parse(Console.ReadLine());

        Console.Write("Введіть допустиму похибку: ");
        double tolerance = double.Parse(Console.ReadLine());

        double sum = 0.0;  // Змінна для збереження суми ряду
        double term = 0.0; // Змінна для збереження значення поточного члена ряду
        int n = 1;         // Лічильник для номера члена ряду
        bool accuracyAchieved = false;  // Флаг для позначення досягнення похибки

        // Цикл для обчислення суми ряду
        for (int i = 1; i <= maxTerms; i++)
        {
            term = ComputeTerm(i);
            sum += term;

            // Виведення значення кожного члена ряду
            Console.WriteLine($"Член {i}: {term}, Поточна сума: {sum}");

            // Перевірка досягнення заданої точності
            if (Math.Abs(term) < tolerance)
            {
                accuracyAchieved = true;
                n = i;  // Запам'ятовуємо кількість членів, які було обчислено
                break;  // Вихід з циклу
            }
        }

        // Виведення результату
        if (accuracyAchieved)
        {
            Console.WriteLine($"Сума ряду досягнута за {n} членів з точністю {tolerance}: {sum:F8}");
            Console.WriteLine($"Фінальна похибка: {Math.Abs(term):F8}");
        }
        else
        {
            Console.WriteLine($"Сума ряду після {maxTerms} членів: {sum:F8}");
            Console.WriteLine($"Фінальна похибка: {Math.Abs(term):F8}");
        }
    }

    // Метод для обчислення n-го члена ряду
    static double ComputeTerm(int n)
    {
        double numerator = Math.Pow(n, 3) + 1;
        double denominator = Math.Pow(n, 3) + 5;
        return Math.Pow(-1, n) * (1 - (numerator / denominator));
    }
}
