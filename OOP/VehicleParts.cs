namespace VehicleParts
{
    public class Engine
    {
        public enum EngineType { Petrol, Diesel, Gas, Electric }
        private static Random generator = new Random();
        private int Power { get; } 
        private int Volume { get; } 
        private EngineType Type { get; }
        private string SerialNumber { get; }

        public Engine(int power = 170, int volume = 6)  // default horsepower and volume 
        {
            this.Power = power;
            this.Volume = volume;
            this.Type = (EngineType) generator.Next(4);
            this.SerialNumber = GenerateSerialNumber();  // Random serial number
        }

        private string GenerateSerialNumber()  // Generates random serial number
        {
            var result = new System.Text.StringBuilder();

            result.Append((char) generator.Next(65, 91));  // random capital-case letter (ASCII)
            result.Append(generator.Next(1, 13));  // random number for month.
            result.Append(generator.Next(1, 29));  // random number for day.
            for (int i = 0; i < 3; i++)
            {
                result.Append((char) generator.Next(65, 91));  // three more random capital-case letter (ASCII)
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
            result.AppendLine($"Power: {this.Power} hp, Volume: V{this.Volume}, Type: {this.Type}, Serial Number: {this.SerialNumber}.");
        
            return result.ToString();
        }
    }

    public class Chassis
    {
        private static Random generator = new Random();
        private int WheelsNumber { get; }
        private string Number { get; }
        private int LoadLimit { get; }
        
        public Chassis(int wheelsNumber = 4, int loadLimit = 300)  // default values
        {
            this.WheelsNumber = wheelsNumber;
            this.Number = GenerateChassisNumber();
            this.LoadLimit = loadLimit;
        }

        private string GenerateChassisNumber()  // generates random chassis number
        {
            var result = new System.Text.StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                result.Append(generator.Next(10));  // random six digits
            }

            return result.ToString();
        }

        public string GetChassisInfo()
        {
            return "Chassis Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Wheels Number: {this.WheelsNumber}, Number: {this.Number}, Permissible Load: {this.LoadLimit} kg.");
        
            return result.ToString();
        }
    }

    public class Transmission
    {
        public enum TransmissionType { Manual, Automatic, SemiAuto };
        public enum TransmissionManufacturer { Aisin, Claas, Getrag, Hewland, LiuGong, Volvo } 
        
        private Random generator = new Random();
        private TransmissionType Type { get; } 
        private TransmissionManufacturer Manufacturer { get; }
        private int GearsNumber { get;}

        public Transmission()
        {
            this.Type = (TransmissionType) generator.Next(3);
            this.Manufacturer = (TransmissionManufacturer) generator.Next(6);
            this.GearsNumber = generator.Next(4,9);
        }

        public string GetTransmissionsInfo()
        {
            return "Transmimssion Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Type: {this.Type}, Gears Number: {this.GearsNumber}, Manufacturer: {this.Manufacturer}.");
        
            return result.ToString();
        }
    }
}