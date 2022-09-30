public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; } 

    public Coordinate(int x = 0, int y = 0, int z = 0)
    {
        this.X = x; this.Y = y; this.Z = z;
    }

    public static int GetDistance(Coordinate point1, Coordinate point2)
    {
        // based on the Euclidean Distance Formula: https://en.wikipedia.org/wiki/Euclidean_distance
        double X = (point1.X - point2.X) * (point1.X - point2.X);
        double Y = (point1.Y - point2.Y) * (point1.Y - point2.Y);
        double Z = (point1.Z - point2.Z) * (point1.Z - point2.Z);
        
        return (int) Math.Sqrt(X + Y + Z);
    }

    public static Coordinate GenerateRandomPoint(int lowerBound, int upperBound)
    {
        var point = new Coordinate();
        point.X = Program.Random.Next(lowerBound, upperBound);
        point.Y = Program.Random.Next(lowerBound, upperBound);
        point.Z = Program.Random.Next(lowerBound, upperBound);
         
        return point;
    }
}

public interface IFlyable
{
    void FlyTo(Coordinate point);
    int GetFlyTime(Coordinate point);
}

public class Program
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

