using System;
using System.Collections.Generic;

class Turn
{
    private int[] elements;
    private int front;
    private int rear;
    private int maxSize;
    private int size;

    // Конструктор з фіксованою розмірністю
    public Turn(int maxSize)
    {
        this.maxSize = maxSize;
        elements = new int[maxSize];
        front = 0;
        rear = -1;
        size = 0;
    }

    // Перевірка чи черга пуста
    public bool IsEmpty()
    {
        return size == 0;
    }

    // Перевірка чи черга заповнена
    public bool IsFull()
    {
        return size == maxSize;
    }

    // Оператор додавання елемента до черги
    public static Turn operator +(Turn turn, int element)
    {
        if (turn.IsFull())
        {
            // Якщо черга заповнена, збільшуємо її розмір динамічно
            turn.Resize();
        }

        turn.rear = (turn.rear + 1) % turn.maxSize;
        turn.elements[turn.rear] = element;
        turn.size++;
        return turn;
    }

    // Оператор видалення елемента з черги
    public static Turn operator -(Turn turn)
    {
        if (!turn.IsEmpty())
        {
            turn.front = (turn.front + 1) % turn.maxSize;
            turn.size--;
        }
        return turn;
    }

    // Метод для виведення черги
    public void Show()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Черга пуста.");
            return;
        }

        Console.Write("Елементи черги: ");
        for (int i = 0; i < size; i++)
        {
            int index = (front + i) % maxSize;
            Console.Write(elements[index] + " ");
        }
        Console.WriteLine();
    }

    // Метод для збільшення розміру черги
    private void Resize()
    {
        int newSize = maxSize * 2;
        int[] newElements = new int[newSize];

        for (int i = 0; i < size; i++)
        {
            newElements[i] = elements[(front + i) % maxSize];
        }

        elements = newElements;
        front = 0;
        rear = size - 1;
        maxSize = newSize;
    }

    // Метод для видалення кожного n-го елемента черги
    public void RemoveEveryNthElement(int n)
    {
        if (n <= 0 || n > size)
        {
            Console.WriteLine("Некоректне значення для N.");
            return;
        }

        List<int> remainingElements = new List<int>();

        for (int i = 0; i < size; i++)
        {
            if ((i + 1) % n != 0)
            {
                remainingElements.Add(elements[(front + i) % maxSize]);
            }
        }

        // Очищуємо чергу та додаємо залишені елементи назад
        size = 0;
        front = 0;
        rear = -1;

        foreach (int el in remainingElements)
        {
            this.Add(el); // Виклик методу додавання
        }
    }

    // Метод для додавання елемента в чергу без оператора
    public void Add(int element)
    {
        if (IsFull())
        {
            Resize();
        }

        rear = (rear + 1) % maxSize;
        elements[rear] = element;
        size++;
    }
}

class Program
{
    static Random rand = new Random();

    // Метод для генерації випадкового числа
    static int GetRandomElement()
    {
        return rand.Next(1, 100); // Випадкові числа від 1 до 100
    }

    // Тестування класу Turn
    static void Main()
    {
        // Створення масиву об'єктів класу Turn
        int queueCount = 3;  // кількість черг
        Turn[] queues = new Turn[queueCount];

        for (int i = 0; i < queueCount; i++)
        {
            queues[i] = new Turn(5);  // початковий розмір черги 5
            for (int j = 0; j < 6; j++)  // додаємо 6 елементів для перевірки динамічного розширення
            {
                queues[i] = queues[i] + GetRandomElement();
            }
        }

        // Виведення черг перед видаленням
        Console.WriteLine("Черги перед видаленням елементів:");
        foreach (Turn queue in queues)
        {
            queue.Show();
        }

        // Видалення кожного 2-го елемента з черг
        foreach (Turn queue in queues)
        {
            queue.RemoveEveryNthElement(2);
        }

        // Виведення черг після видалення
        Console.WriteLine("\nЧерги після видалення кожного 2-го елемента:");
        foreach (Turn queue in queues)
        {
            queue.Show();
        }
    }
}
