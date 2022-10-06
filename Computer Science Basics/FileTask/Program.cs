class PizzaDelivery
{
    static void Main()
    {
        System.IO.File.WriteAllText("waitingList.txt", "No orders yet.\n");

        Console.Clear();
        bool undone = true;
        var message = new System.Text.StringBuilder();
        int option = 0;

        while (undone)
        {
            message.AppendLine("1) Add an order to the queue.");
            message.AppendLine("2) Delete the order from the queue.");
            message.AppendLine("3) Number of orders.");
            message.AppendLine("4) Display order list.");
            message.AppendLine("0) Exit the program. (This is the default option)");
            message.Append("   Choose one of this options: ");
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Order.AddToWaitingList();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Order.DeleteFromWaitingList();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Number of clients waiting: {0}.\n", Order.OrderList.Count);
                        break;
                    case 4:
                        Console.Clear();
                        Order.DisplayWaitingList();
                        break;
                    default:
                        undone = false;
                        Console.WriteLine("\nThank you...!");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Try Again!\n");
            }
            
            message.Clear();
        }
    }
}