using InterfacesAndAbstractClasses;

namespace Ifyables
{
    public class Bird : IFlyable
    {
        private Coordinate Currentposition { get; set; } = new Coordinate();
        public int Speed { get; } = Program.Random.Next(1, 21);  // cannot be changed

        // A bird loses 10% Stamina in every 10 km. When its Stamina level is 30%, 
        // it should rest 7 hours. In other words, the bird rests to eat for 7 hours 
        // after every 70 km of flying.
        public byte Stamina { get; private set; } = 100;

        public void FlyTo(Coordinate point)
        {
            this.Currentposition = Coordinate.GenerateRandomPoint(1, 17);
            int distance = Coordinate.GetDistance(this.Currentposition, point);
            var message = new System.Text.StringBuilder();

            message.Append($"The bird started flying with a speed of {this.Speed}");
            message.Append($" km/h from point ({this.Currentposition.X}, ");
            message.Append($"{this.Currentposition.Y}, {this.Currentposition.Z})");
            message.AppendLine($" to point ({point.X}, {point.Y}, {point.Z}), ");
            message.Append($"which is roughly {distance} km.");
            message.Append("The bird is flying: ...");
            Console.Write(message);

            int S = distance;
            while (true)
            {
                if (distance > 0)
                {
                    distance -= 10;
                    this.Stamina -= 10;

                    if (this.Stamina == 30)
                    {
                        Console.WriteLine("\nThe bird reached 70 km and now it is tired " +
                            "and hungry. It should rest and eat for about 7 hours.");
                        Console.Write("The bird is resting: ...");
                        while (this.Stamina != 100)
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.Write(" ...");
                            this.Stamina += 10;
                        }
                        Console.Write("\nThe bird continues to fly: ...");
                    }
                }
                else
                {
                    // same logic used as in the GetFlyTime method
                    Console.WriteLine("\nThe bird has arrived and it took rougly {0} " +
                        "hours.\n", Math.Round(S / this.Speed + S / 70.0 * 7));  // S - distance
                    break;
                }

                System.Threading.Thread.Sleep(1000);
                Console.Write(" ...");
            }
        }

        public int GetFlyTime(Coordinate point)
        {
            int time = 0;
            int distance = Coordinate.GetDistance(this.Currentposition, point);
            time += distance / this.Speed;
            time += distance / 70 * 7;  // take bird's Stamina into account   

            return time;
        }
    }
}