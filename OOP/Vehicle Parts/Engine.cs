using CarPark;

namespace OOP.VehicleParts
{
    public class Engine
    {
        public enum EngineType { Petrol, Diesel, Gas, Electric }
        private int Power { get; }
        private int Volume { get; }
        private EngineType Type { get; }
        private string SerialNumber { get; }

        public Engine(int power = 170, int volume = 6)  // default horsepower and volume 
        {
            this.Power = power;
            this.Volume = volume;
            this.Type = (EngineType) Program.Random.Next(4);
            this.SerialNumber = GenerateSerialNumber();  // Random serial number
        }

        private string GenerateSerialNumber()  // Generates random serial number
        {
            var result = new System.Text.StringBuilder();

            result.Append((char) Program.Random.Next(65, 91));  // random capital-case letter (ASCII)
            result.Append(Program.Random.Next(1, 13));  // random number for month.
            result.Append(Program.Random.Next(1, 29));  // random number for day.
            for (int i = 0; i < 3; i++)
            {
                result.Append((char) Program.Random.Next(65, 91));  // three more random capital-case letter (ASCII)
            }

            return result.ToString();
        }

        public string GetEngineInfo()
        {
            return "Engine Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Power: {this.Power} hp, Volume: V{this.Volume}," +
                $" Type: {this.Type}, Serial Number: {this.SerialNumber}.");

            return result.ToString();
        }
    }
}
