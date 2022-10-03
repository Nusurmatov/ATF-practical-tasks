using CarPark;

namespace OOP.VehicleParts
{
    public class Transmission
    {
        public enum TransmissionType { Manual, Automatic, SemiAuto };
        public enum TransmissionManufacturer { Aisin, Claas, Getrag, Hewland, LiuGong, Volvo }

        private TransmissionType Type { get; }
        private TransmissionManufacturer Manufacturer { get; }
        private int GearsNumber { get; }

        public Transmission()
        { 
            this.Type = (TransmissionType) Program.Random.Next(3);
            this.Manufacturer = (TransmissionManufacturer) Program.Random.Next(6);
            this.GearsNumber = Program.Random.Next(4, 9);
        }

        public string GetTransmissionsInfo()
        {
            return "Transmimssion Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Type: {this.Type}, Gears Number: " +
                $"{this.GearsNumber}, Manufacturer: {this.Manufacturer}.");

            return result.ToString();
        }
    }
}
