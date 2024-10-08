using System;
using System.Collections.Generic;

// Клас Category (Категорія), який є частиною композиції з класом Product
class Category
{
    public string Name { get; private set; }

    public Category(string name)
    {
        Name = name;
    }

    public void ShowCategory()
    {
        Console.WriteLine($"Категорія: {Name}");
    }
}

// Клас Product, який має композицію з класом Category
class Product
{
    // Поля класу
    private string name;
    private string manufacturer;
    private double price;
    private int shelfLife; // Термін зберігання у днях
    private int quantity;
    private Category category; // Композиція з класом Category

    // Конструктор класу Product, який створює об'єкт категорії
    public Product(string name, string manufacturer, double price, int shelfLife, int quantity, string categoryName)
    {
        this.name = name;
        this.manufacturer = manufacturer;
        this.price = price;
        this.shelfLife = shelfLife;
        this.quantity = quantity;
        this.category = new Category(categoryName); // Композиція: створення категорії разом з продуктом
    }

    // Гетери та сетери
    public string GetName() => name;
    public void SetName(string name) => this.name = name;

    public string GetManufacturer() => manufacturer;
    public void SetManufacturer(string manufacturer) => this.manufacturer = manufacturer;

    public double GetPrice() => price;
    public void SetPrice(double price) => this.price = price;

    public int GetShelfLife() => shelfLife;
    public void SetShelfLife(int shelfLife) => this.shelfLife = shelfLife;

    public int GetQuantity() => quantity;
    public void SetQuantity(int quantity) => this.quantity = quantity;

    // Метод для виведення інформації про товар разом з категорією
    public void Show()
    {
        Console.WriteLine($"Назва: {name}, Виробник: {manufacturer}, Ціна: {price}, Термін зберігання: {shelfLife} днів, Кількість: {quantity}");
        category.ShowCategory();
    }

    // Додаткові методи
    public bool IsPriceLessThan(double maxPrice)
    {
        return price <= maxPrice;
    }

    public bool IsShelfLifeMoreThan(int minShelfLife)
    {
        return shelfLife > minShelfLife;
    }
}

class Program
{
    // Метод для створення продукту через введення параметрів користувачем
    static Product CreateProductFromUserInput()
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

        Console.Write("Введіть назву категорії продукту: ");
        string categoryName = Console.ReadLine();

        return new Product(name, manufacturer, price, shelfLife, quantity, categoryName);
    }

    // Метод для редагування продукту
    static void EditProduct(Product product)
    {
        Console.WriteLine("Редагування продукту:");
        Console.Write("Введіть нову назву (або натисніть Enter для пропуску): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName)) product.SetName(newName);

        Console.Write("Введіть нового виробника (або натисніть Enter для пропуску): ");
        string newManufacturer = Console.ReadLine();
        if (!string.IsNullOrEmpty(newManufacturer)) product.SetManufacturer(newManufacturer);

        Console.Write("Введіть нову ціну (або натисніть Enter для пропуску): ");
        string newPriceInput = Console.ReadLine();
        if (double.TryParse(newPriceInput, out double newPrice)) product.SetPrice(newPrice);

        Console.Write("Введіть новий термін зберігання (або натисніть Enter для пропуску): ");
        string newShelfLifeInput = Console.ReadLine();
        if (int.TryParse(newShelfLifeInput, out int newShelfLife)) product.SetShelfLife(newShelfLife);

        Console.Write("Введіть нову кількість (або натисніть Enter для пропуску): ");
        string newQuantityInput = Console.ReadLine();
        if (int.TryParse(newQuantityInput, out int newQuantity)) product.SetQuantity(newQuantity);
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Попередньо створені продукти
        List<Product> products = new List<Product>
        {
            new Product("Молоко", "Виробник 1", 25.5, 7, 100, "Молочні продукти"),
            new Product("Хліб", "Виробник 2", 10, 2, 200, "Хлібобулочні вироби"),
            new Product("Йогурт", "Виробник 1", 18, 10, 50, "Молочні продукти")
        };

        // Меню для користувача
        while (true)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Вивести всі продукти");
            Console.WriteLine("2. Додати новий продукт");
            Console.WriteLine("3. Редагувати продукт");
            Console.WriteLine("4. Видалити продукт");
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
                products.Add(CreateProductFromUserInput());
                Console.WriteLine("Новий продукт додано.");
            }
            else if (choice == "3")
            {
                Console.Write("Введіть номер продукту для редагування: ");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < products.Count)
                {
                    EditProduct(products[index]);
                }
                else
                {
                    Console.WriteLine("Неправильний індекс.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введіть номер продукту для видалення: ");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < products.Count)
                {
                    products.RemoveAt(index);
                    Console.WriteLine("Продукт видалено.");
                }
                else
                {
                    Console.WriteLine("Неправильний індекс.");
                }
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
