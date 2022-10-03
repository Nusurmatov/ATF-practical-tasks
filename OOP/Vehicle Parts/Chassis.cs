using CarPark;

namespace OOP.VehicleParts
{
    public class Chassis
    {
        private int WheelsNumber { get; }
        private string Number { get; }
        private int LoadLimit { get; }

        public Chassis(int wheelsNumber = 4, int loadLimit = 300)  
        {
            this.WheelsNumber = wheelsNumber;
            this.Number = GenerateChassisNumber();
            this.LoadLimit = loadLimit;
        }

        private string GenerateChassisNumber()  
        {
            var result = new System.Text.StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                result.Append(Program.Random.Next(10));  
            }

            return result.ToString();
        }

        public string GetInfo()
        {
            return "Chassis Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Wheels Number: {this.WheelsNumber}, " +
                $"Number: {this.Number}, Permissible Load: {this.LoadLimit} kg.");

            return result.ToString();
        }
    }
}
