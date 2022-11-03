using Ifyables;

namespace InterfacesAndAbstractClasses
{
    public static class Program
    {
        public static Random Random { get; } = new Random();
        
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor) Random.Next(1, 14);
            Bird bird = new Bird();
            bird.FlyTo(Coordinate.GenerateRandomPoint(50, 70));

            Console.ForegroundColor = (ConsoleColor) Random.Next(1, 14);
            Airplane airplane = new Airplane();
            airplane.FlyTo(Coordinate.GenerateRandomPoint(300, 5000));

            Console.ForegroundColor = (ConsoleColor) Random.Next(1, 14);
            Drone drone = new Drone();
            drone.FlyTo(Coordinate.GenerateRandomPoint(100, 1000));
        }
    }
}