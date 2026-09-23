public class InventoryManager {
    public class Item
    {
        public string Name;
        public double Price;
        public int Quantity;
    }
    static List<Item> inventory = new List<Item>();
    public static void Main(string[] args) {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Inventory Manager ===");
            Console.WriteLine("1. View Items");
            Console.WriteLine("2. Add Item");
            Console.WriteLine("3. Update Item");
            Console.WriteLine("4. Delete Item");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewItems();
                    break;
                case "2":
                    AddItem();
                    break;
                case "3":
                    UpdateItem();
                    break;
                case "4":
                    DeleteItem();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
    public static void AddItem() {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        Console.Write("Enter price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        inventory.Add(new Item { Name = name, Price = price, Quantity = quantity });

        Console.WriteLine("Item added.");
    }
    public static void UpdateItem() {
        ViewItems();
        Console.Write("Enter index of item to update: ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index--;
            if (index >= 0 && index < inventory.Count)
            {
                Console.Write("Enter new name: ");
                inventory[index].Name = Console.ReadLine();

                Console.Write("Enter new price: ");
                inventory[index].Price = double.Parse(Console.ReadLine());

                Console.Write("Enter new quantity: ");
                inventory[index].Quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Item updated.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
    public static void DeleteItem() {
        ViewItems();
        Console.Write("Enter index of item to delete: ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index--;
            if (index >= 0 && index < inventory.Count)
            {
                inventory.RemoveAt(index);
                Console.WriteLine("Item deleted.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
    public static void ViewItems() {
        Console.WriteLine("Current Inventory:");

        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            Item item = inventory[i];
            Console.WriteLine($"{i + 1}: {item.Name} | Price: ${item.Price} | Qty: {item.Quantity}");
        }
    }
}