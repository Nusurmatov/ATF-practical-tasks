public class Drone : IFlyable
{
    private Coordinate Currentposition { get; set; }
    public int Speed { get; private set; } = Program.Random.Next(3, 6);  // km per minute

    public void FlyTo(Coordinate point)
    {
        this.Currentposition = Coordinate.GenerateRandomPoint(1, 17);
        int distance = Coordinate.GetDistance(this.Currentposition, point);
        var message = new System.Text.StringBuilder();
 
        message.Append($"The speed of the drone {this.Speed} km/min and it needs to fly ");
        message.Append($"from point ({this.Currentposition.X}, {this.Currentposition.Y}, {this.Currentposition.Z}) ");
        message.AppendLine($"to point ({point.X}, {point.Y}, {point.Z}), which is roughly {distance} km.");
        message.Append("The drone rests 1 minute after every 10 minutes of flying:");
        Console.Write(message);     

        int S = distance;
        int flag = 1;  // this flag is for flying and resting mode.
        if (S < 1000)
        {
            while (true)
            {
                if (distance > 0)
                {                    
                    if (flag % 2 == 1)
                    {
                        distance -= this.Speed * 10;
                        System.Threading.Thread.Sleep(500);
                        Console.Write(" flying...");      
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(50);
                        Console.Write(" hovering...");      
                    }
                    flag++;
                }
                else
                {
                    Console.WriteLine("\nThe drone has arrived and it took roughly {0} minutes.", CalculateFlyTime(S, this.Speed));
                    break;
                }            
            }      
        }
        else
        {
            Console.WriteLine("\nThe drone cannot fly this point, because it is more than 1000 km.");
        }
    }   
    public int GetFlyTime(Coordinate point)
    {
        int distance = Coordinate.GetDistance(this.Currentposition, point);
        return CalculateFlyTime(distance, this.Speed);
    } 

    private static int CalculateFlyTime(int distance, int speed)
    {
        int time = distance / speed;
        time += time/10;  // this is because it hoveres for 1 minute after every 10 minutes.

        return (int) time;
    }
}