using System;
using System.Collections.Generic;

// Абстрактний клас StoreItem
abstract class StoreItem
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }

    public StoreItem(string name, string manufacturer)
    {
        Name = name;
        Manufacturer = manufacturer;
    }

    // Абстрактний метод для виведення інформації
    public abstract void ShowInfo();
}

// Клас Product, який наслідується від StoreItem
class Product : StoreItem
{
    public double Price { get; set; }
    public int ShelfLife { get; set; } // Термін зберігання
    public int Quantity { get; set; }

    public Product(string name, string manufacturer, double price, int shelfLife, int quantity)
        : base(name, manufacturer)
    {
        Price = price;
        ShelfLife = shelfLife;
        Quantity = quantity;
    }

    // Гетери та сетери
    public string GetName() => Name;
    public void SetName(string name) => Name = name;

    public string GetManufacturer() => Manufacturer;
    public void SetManufacturer(string manufacturer) => Manufacturer = manufacturer;

    public double GetPrice() => Price;
    public void SetPrice(double price) => Price = price;

    public int GetShelfLife() => ShelfLife;
    public void SetShelfLife(int shelfLife) => ShelfLife = shelfLife;

    public int GetQuantity() => Quantity;
    public void SetQuantity(int quantity) => Quantity = quantity;

    public override void ShowInfo()
    {
        Console.WriteLine($"Назва: {Name}, Виробник: {Manufacturer}, Ціна: {Price}, Термін зберігання: {ShelfLife} днів, Кількість: {Quantity}");
    }

    // Додаткові методи
    public bool IsPriceLessThan(double maxPrice) => Price <= maxPrice;
    public bool IsShelfLifeMoreThan(int minShelfLife) => ShelfLife > minShelfLife;
}

// Перший рівень спадкування: клас FoodProduct
class FoodProduct : Product
{
    public bool IsPerishable { get; set; }

    public FoodProduct(string name, string manufacturer, double price, int shelfLife, int quantity, bool isPerishable)
        : base(name, manufacturer, price, shelfLife, quantity)
    {
        IsPerishable = isPerishable;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Цей продукт псується: {(IsPerishable ? "Так" : "Ні")}");
    }
}

// Перший рівень спадкування: клас NonFoodProduct
class NonFoodProduct : Product
{
    public string Material { get; set; }

    public NonFoodProduct(string name, string manufacturer, double price, int shelfLife, int quantity, string material)
        : base(name, manufacturer, price, shelfLife, quantity)
    {
        Material = material;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Матеріал продукту: {Material}");
    }
}

// Другий рівень спадкування: клас DairyProduct
class DairyProduct : FoodProduct
{
    public double FatContent { get; set; }

    public DairyProduct(string name, string manufacturer, double price, int shelfLife, int quantity, bool isPerishable, double fatContent)
        : base(name, manufacturer, price, shelfLife, quantity, isPerishable)
    {
        FatContent = fatContent;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Вміст жиру: {FatContent}%");
    }
}

// Другий рівень спадкування: клас BakeryProduct
class BakeryProduct : FoodProduct
{
    public string FlourType { get; set; }

    public BakeryProduct(string name, string manufacturer, double price, int shelfLife, int quantity, bool isPerishable, string flourType)
        : base(name, manufacturer, price, shelfLife, quantity, isPerishable)
    {
        FlourType = flourType;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Тип борошна: {FlourType}");
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

        Console.Write("Чи псується продукт (Так/Ні): ");
        bool isPerishable = Console.ReadLine().ToLower() == "так";

        return new FoodProduct(name, manufacturer, price, shelfLife, quantity, isPerishable);
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
        List<StoreItem> storeItems = new List<StoreItem>();

        // Попередньо створені продукти
        storeItems.Add(new DairyProduct("Кефір", "Виробник 1", 20, 7, 80, true, 2.5));
        storeItems.Add(new BakeryProduct("Хліб", "Виробник 3", 10, 3, 200, true, "Пшеничне"));
        storeItems.Add(new NonFoodProduct("Мило", "Виробник 2", 15.99, 365, 50, "Гліцерин"));

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
                foreach (var product in storeItems)
                {
                    product.ShowInfo();
                    Console.WriteLine();
                }
            }
            else if (choice == "2")
            {
                storeItems.Add(CreateProductFromUserInput());
                Console.WriteLine("Новий продукт додано.");
            }
            else if (choice == "3")
            {
                Console.Write("Введіть номер продукту для редагування: ");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < storeItems.Count)
                {
                    EditProduct((Product)storeItems[index]);
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
                if (index >= 0 && index < storeItems.Count)
                {
                    storeItems.RemoveAt(index);
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
