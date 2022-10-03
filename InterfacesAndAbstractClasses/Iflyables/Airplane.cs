using InterfacesAndAbstractClasses;

namespace Ifyables
{
    public class Airplane : IFlyable
    {
        private Coordinate Currentposition { get; set; }
        public int Speed { get; private set; } = 200;

        public void FlyTo(Coordinate point)
        {
            this.Currentposition = Coordinate.GenerateRandomPoint(1, 17);
            int distance = Coordinate.GetDistance(this.Currentposition, point);
            var message = new System.Text.StringBuilder();

            message.Append($"The airplane started flying with a speed of {this.Speed}");
            message.Append($" km/h from point ({this.Currentposition.X}, ");
            message.Append($"{this.Currentposition.Y}, {this.Currentposition.Z}) ");
            message.Append($"to point ({point.X}, {point.Y}, {point.Z}), ");
            message.Append("which is roughly {distance} km.\nThe airplane is flying: ...");
            Console.Write(message);

            int S = distance;
            while (true)
            {
                if (distance > 0)
                {
                    distance -= 70;
                }
                else
                {
                    Console.Write("\nThe airplane has arrived and it took rougly {0} hours.", 
                        CalculateFlyTime(S, this.Speed));  // S - distance
                    Console.WriteLine(" Because the airplane speed increased 10 km/h after " +
                        "every 10 km.\n");
                    break;
                }

                System.Threading.Thread.Sleep(200);
                Console.Write(" ...");
            }
        }

        public int GetFlyTime(Coordinate point)
        {
            int distance = Coordinate.GetDistance(this.Currentposition, point);
            return CalculateFlyTime(distance, this.Speed);
        }

        private static int CalculateFlyTime(int distance, int speed)
        {
            double time = 0;

            while (distance > 0)
            {
                time += (distance > 10) ? (10.0 / speed) : (1.0 * distance / speed);
                distance -= 10;
                speed += 10;
            }

            return (int) time;
        }
    }
}