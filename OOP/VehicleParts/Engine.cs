using CarPark;
using OOP.Exceptions;

namespace OOP.VehicleParts
{
    public class Engine
    {
        private double _capacity;

        private int _power;
        
        private int _volume;
        
        public enum EngineType { Petrol, Diesel, Gas, Electric }
      
        public double Capacity  // in litres 
        {
            get => _capacity;
            set
            {
                if (value < 0)
                {
                    throw new InitializationException("Engine Capacity cannot be negative");
                }
                _capacity = value;
            }
        }

        public int Power  // horse power
        {
            get => _power;
            set
            {
                if (value < 0)
                {
                    throw new InitializationException("Engine Power cannot be negative");
                }
                _power = value;
            }
        }

        public int Volume
        {
            get => _volume;
            set
            {
                if (value == 4 || value == 6 || value == 8)
                {
                    _volume= value;
                }
                else
                {
                    throw new InitializationException("Volume should be 4, 6 or 8!");
                }
            }
        }

        // for brevity this properties randomly set in the constructor
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

        public string GetInfo() => $"Engine Info --- {this}";

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
