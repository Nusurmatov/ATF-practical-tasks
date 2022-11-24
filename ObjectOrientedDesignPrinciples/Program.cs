namespace ObjectOrientedDesignPrinciples
{
    public class ConsoleCarCollection
    {
        private static bool _undone = true;
        private static byte _option;
        
        private static CarInformation _carInfo = new CarInformation(Car.GetInstance());

        private static void Main()
        {
            Console.Clear();
            ReceiveCarInformation();

            while (_undone)
            {
                PrintMessage();    
                ReceiveCommand();
                PerformCommand();
            }
        }

        static void PrintMessage()
        {
            Console.WriteLine("To add a car to the collection, enter 1;");
            Console.WriteLine("To see the number of car brands, enter 2;");
            Console.WriteLine("To see the total number of cars, enter 3;");
            Console.WriteLine("To see the average cost of the cars, enter 4;");
            Console.WriteLine("To see the average cost of the cars by brand, enter 5;");
            Console.WriteLine("To exit the program, enter 6.");
            Console.Write("And your option is : ");
        }

        static void ReceiveCommand()
        {
            if (byte.TryParse(Console.ReadLine(), out _option) == false)
            {
                Console.Clear();
                Console.WriteLine("Invalid option, please try again!");
            }
        }

        static void PerformCommand()
        {
            Invoker invoker;

            switch (_option)
            {
                case 1:
                    ReceiveCarInformation();
                    break;
                case 2:
                    invoker = new Invoker(new CountCarBrands(_carInfo));
                    invoker.Invoke();
                    break;
                case 3:   
                    invoker = new Invoker(new CountTotalCars(_carInfo));
                    invoker.Invoke();
                    break;
                case 4:   
                    invoker = new Invoker(new AverageCarPrice(_carInfo));
                    invoker.Invoke();
                    break;
                case 5:
                    string brandName = ReceiveStringFromConsole("Enter a brand: ");   
                    invoker = new Invoker(new AverageCarPriceByBrand(_carInfo, brandName));
                    invoker.Invoke();
                    break;
                case 6:   
                    _undone = false;
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        static void ReceiveCarInformation()
        {
            Car car = Car.GetInstance();

            car.SetBrand(ReceiveStringFromConsole("Enter a car brand: "));
            car.SetModel(ReceiveStringFromConsole("Enter a model: "));            
            car.SetQuantity(ReceiveIntFromConsole("Enter a quantity: "));
            car.SetPrice(ReceiveDecimalFromConsole("Enter a price per unit: "));

            _carInfo = new CarInformation(car);
            Console.Clear();
        }

        private static string ReceiveStringFromConsole(string message)
        {
            string input;
            
            while (true)
            {
                Console.Write(message);
                input = Console.ReadLine() ?? String.Empty;

                if (input.Trim() != String.Empty)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again!");
                }
            }
        }

        private static int ReceiveIntFromConsole(string message)
        {

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    return input;                    
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again!");
                }
            }
        }

        private static decimal ReceiveDecimalFromConsole(string message)
        {
            while (true)
            {
                Console.Write(message);
                
                if (decimal.TryParse(Console.ReadLine(), out decimal input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again!");
                }
            }
        }
    }
}
