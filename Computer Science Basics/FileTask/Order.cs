struct Order 
{

    static Dictionary<string, decimal> Pizza = new Dictionary<string, decimal>()
    {
        { "paperoni", 7.5m },     
        { "4 seasons", 9.5m },     
        { "calsone", 6.5m }     
    };

    public static List<Order> OrderList = new List<Order>();

    string Name { get; set; }
    string Address { get; set; }
    string PizzaName { get; set; }
    int Quantity { get; set; }

    public decimal TotalCost { get; private set; }

    public static void AddToWaitingList()
    {
        var order = new Order();
        Console.Write("Enter the Name: ");
        order.Name = Console.ReadLine() ?? "Unknown";
        Console.Write("Enter the address: ");
        order.Address = Console.ReadLine() ?? "Unknown";
        Console.Write("Enter the pizza name (Paperoni, 4 Seasons or Calsone): ");
        order.PizzaName = Console.ReadLine() ?? "Unknown";
        Console.Write("Enter the Quantity: ");
        order.Quantity = Convert.ToInt32(Console.ReadLine());
        if (Pizza.ContainsKey(order.PizzaName.ToLower()))
        {
            order.TotalCost = Pizza[order.PizzaName] * order.Quantity;
        }

        OrderList.Add(order);
        WriteOrderToFile();
    } 

    public static void DeleteFromWaitingList()
    {
        if (OrderList.Count != 0)
        {
            OrderList.RemoveAt(0);
        }
        else 
        {
            Console.WriteLine("There are no orders in the waiting list!\n");
            System.IO.File.WriteAllText("waitingList.txt", "No orders yet.\n");
        }

        WriteOrderToFile();
    }

    public static void DisplayWaitingList()
    {
        try
        {
            using (var reader = new StreamReader("waitingList.txt"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void WriteOrderToFile()
    {
        using (var writer = new StreamWriter("waitingList.txt"))
        {
            writer.WriteLine("----- Waiting List -----");
            foreach (var order in OrderList)
            {
                writer.WriteLine($"Name: {order.Name}.");
                writer.WriteLine($"Address: {order.Address}.");
                writer.WriteLine($"Pizza Name: {order.PizzaName}.");
                writer.WriteLine($"Total Cost: {order.TotalCost:c2}.\n");    
            }
        }
    } 
}