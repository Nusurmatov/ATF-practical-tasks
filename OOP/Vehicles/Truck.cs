using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class Truck : Vehicle
    {
        public enum TruckBrand { Freighliner, MAN, Volvo, Isuzu }
      
        private TruckBrand Brand { get; }

        public Truck()
        {
            this.Type = "Truck";
            this.Engine = new Engine(capacity: Program.Random.NextDouble() * 10, 
                power: Program.Random.Next(1000, 7000), volume: 8);
            this.Chassis = new Chassis(wheelsNumber: 12, 
                loadLimit: Program.Random.Next(1000, 5000));
            this.Transmission = new Transmission();
            this.Brand = (TruckBrand) Program.Random.Next(4);
        }

        public override string GetInfo()
        {
            return base.ToString() + $"Manufacturer: {this.Brand}.\n";
        }

        public override string ToString()
        {
            return $"Type: {this.Type}, Manufacturer: {this.Brand}.\n";
        }
    }
}
