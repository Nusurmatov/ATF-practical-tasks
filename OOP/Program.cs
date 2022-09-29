using System.Threading;

namespace CarPark
{
    public class Program
    {
        private static Random generator = new Random(); 
        
        public static void Main(string[] args)
        {
            SetShriftColor();
            var passengerCar = new Vehicle.PassengerCar();
            Console.Write(passengerCar.GetInfo());
            MakeHimOrHerWait();
            
            SetShriftColor();
            var truck = new Vehicle.Truck();
            Console.Write(truck.GetInfo());
            MakeHimOrHerWait();
            
            SetShriftColor();
            var bus = new Vehicle.Bus();
            Console.Write(bus.GetInfo());
            MakeHimOrHerWait();
            
            SetShriftColor();
            var scooter = new Vehicle.Scooter();
            Console.Write(scooter.GetInfo());
            MakeHimOrHerWait();

            SetShriftColor();
            Console.Write("The End...!");
        }

        private static void SetShriftColor()
        {
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor) generator.Next(1, 16);  // random shrift color
        }

        private static void MakeHimOrHerWait()
        {
            while (true)
            {
                string input = String.Empty;

                Console.Write("\n\n\nYou have 10 secunds to read the above content: ");

                for (int i = 1; i < 11; i++)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(1000);
                }

                break;
            }
        }
    }
}