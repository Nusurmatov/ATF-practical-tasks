using CarPark;

namespace OOP.VehicleParts
{
    public class Engine
    {
        public enum EngineType { Petrol, Diesel, Gas, Electric }
        public double Capacity { get; }  // in litres
        public int Power { get; }  // horse power
        public int Volume { get; }
        public EngineType Type { get; }
        public string SerialNumber { get; }

        public Engine(double capacity = 1.5, int power = 170, int volume = 6) 
        {
            this.Capacity = Math.Round(capacity, 2);
            this.Power = power;
            this.Volume = volume;
            this.Type = (EngineType) Program.Random.Next(4);
            this.SerialNumber = GenerateSerialNumber();  
        }

        // Generates random serial number
        private string GenerateSerialNumber()  
        {
            var result = new System.Text.StringBuilder();

            // random capital-case letter (ASCII)
            result.Append((char) Program.Random.Next(65, 91));  
            // random number for month
            result.Append(Program.Random.Next(1, 13));  
            // random number for day
            result.Append(Program.Random.Next(1, 29));  

            // three more random capital-case letter (ASCII)
            for (int i = 0; i < 3; i++)
            {
                result.Append((char) Program.Random.Next(65, 91));  
            }

            return result.ToString();
        }

        public string GetInfo()
        {
            return "Engine Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            result.Append($"Capacity: {this.Capacity} litres, ");
            result.AppendLine($"Power: {this.Power} hp, Volume: V{this.Volume}," +
                $" Type: {this.Type}, Serial Number: {this.SerialNumber}.");

            return result.ToString();
        }
    }
}
