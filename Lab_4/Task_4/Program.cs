using System;
using System.Collections.Generic;

// Клас Supplier (Постачальник)
class Supplier
{
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    // Конструктор класу Supplier
    public Supplier(string companyName, string address, string phoneNumber)
    {
        CompanyName = companyName;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    // Метод для виведення інформації про постачальника
    public void Show()
    {
        Console.WriteLine($"Постачальник: {CompanyName}, Адреса: {Address}, Телефон: {PhoneNumber}");
    }
}

// Клас Product (Продукт)
class Product
{
    private string name;
    private string manufacturer;
    private double price;
    private int shelfLife;
    private int quantity;

    // Поле для агрегації - об'єкт класу Supplier
    public Supplier Supplier { get; set; }

    // Конструктор класу Product
    public Product(string name, string manufacturer, double price, int shelfLife, int quantity, Supplier supplier = null)
    {
        this.name = name;
        this.manufacturer = manufacturer;
        this.price = price;
        this.shelfLife = shelfLife;
        this.quantity = quantity;
        this.Supplier = supplier;
    }

    // Методи класу Product
    public void Show()
    {
        Console.WriteLine($"Назва: {name}, Виробник: {manufacturer}, Ціна: {price}, Термін зберігання: {shelfLife} днів, Кількість: {quantity}");
        if (Supplier != null)
        {
            Supplier.Show(); // Якщо постачальник існує, показуємо його
        }
        else
        {
            Console.WriteLine("Постачальник: не призначено");
        }
    }

    // Метод для додавання або заміни постачальника
    public void AssignSupplier(Supplier supplier)
    {
        Supplier = supplier;
        Console.WriteLine($"Постачальник призначений для продукту \"{name}\".");
    }

    // Метод для видалення постачальника
    public void RemoveSupplier()
    {
        Supplier = null;
        Console.WriteLine($"Постачальника видалено з продукту \"{name}\".");
    }
}

class Program
{
    static Supplier CreateSupplierFromUserInput()
    {
        Console.Write("Введіть назву компанії постачальника: ");
        string companyName = Console.ReadLine();

        Console.Write("Введіть адресу постачальника: ");
        string address = Console.ReadLine();

        Console.Write("Введіть телефон постачальника: ");
        string phoneNumber = Console.ReadLine();

        return new Supplier(companyName, address, phoneNumber);
    }

    static Product CreateProductFromUserInput(Supplier supplier = null)
    {
        Console.Write("Введіть назву продукту: ");
        string name = Console.ReadLine();

        Console.Write("Введіть виробника: ");
        string manufacturer = Console.ReadLine();

        Console.Write("Введіть ціну продукту: ");
        double price;
        while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.Write("Неправильний формат ціни. Введіть знову: ");
        }

        Console.Write("Введіть термін зберігання (у днях): ");
        int shelfLife;
        while (!int.TryParse(Console.ReadLine(), out shelfLife) || shelfLife < 0)
        {
            Console.Write("Неправильний формат терміну зберігання. Введіть знову: ");
        }

        Console.Write("Введіть кількість продукту: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.Write("Неправильний формат кількості. Введіть знову: ");
        }

        return new Product(name, manufacturer, price, shelfLife, quantity, supplier);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Попередньо створені постачальники
        Supplier supplier1 = new Supplier("Компанія 1", "Київ, вул. Хрещатик 1", "123-456-789");
        Supplier supplier2 = new Supplier("Компанія 2", "Львів, пр. Свободи 20", "987-654-321");

        // Створюємо продукти без постачальників
        List<Product> products = new List<Product>
        {
            new Product("Молоко", "Виробник 1", 25.5, 7, 100),
            new Product("Хліб", "Виробник 2", 10, 2, 200),
            new Product("Йогурт", "Виробник 1", 18, 10, 50)
        };

        // Меню для користувача
        while (true)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Вивести всі продукти");
            Console.WriteLine("2. Призначити постачальника для продукту");
            Console.WriteLine("3. Видалити постачальника з продукту");
            Console.WriteLine("4. Додати новий продукт");
            Console.WriteLine("5. Вийти");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                foreach (var product in products)
                {
                    product.Show();
                }
            }
            else if (choice == "2")
            {
                Console.Write("Введіть номер продукту для призначення постачальника: ");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < products.Count)
                {
                    Supplier supplier = CreateSupplierFromUserInput();
                    products[index].AssignSupplier(supplier);
                }
                else
                {
                    Console.WriteLine("Неправильний індекс.");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введіть номер продукту для видалення постачальника: ");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < products.Count)
                {
                    products[index].RemoveSupplier();
                }
                else
                {
                    Console.WriteLine("Неправильний індекс.");
                }
            }
            else if (choice == "4")
            {
                products.Add(CreateProductFromUserInput());
                Console.WriteLine("Новий продукт додано.");
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Неправильний вибір.");
            }
        }
    }
}
