using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class Truck : Vehicle
    {
        public enum TruckBrand { Freighliner, MAN, Volvo, Isuzu }
      
        private TruckBrand Brand { get; }

        public Truck() : this((TruckBrand) Program.Random.Next(4)) { }

        public Truck(TruckBrand brand)
        {
            this.Type = "Truck";
            this.Engine = new Engine(capacity: Program.Random.NextDouble() * 10, 
                power: Program.Random.Next(1000, 7000), volume: 8);
            this.Chassis = new Chassis(wheelsNumber: 12, 
                loadLimit: Program.Random.Next(1000, 5000));
            this.Transmission = new Transmission();
            this.Brand = brand;
        }

        public Truck(TruckBrand brand, Chassis chassis, Engine engine, Transmission transmission)
        {
            this.Brand = brand;
            this.Chassis = chassis;
            this.Engine = engine;
            this.Transmission = transmission;
        }

        public override string GetInfo() => $"{base.ToString()}Manufacturer: {this.Brand}.\n";

        public override string ToString() => $"Type: {this.Type}, Manufacturer: {this.Brand}.\n";

        public TruckBrand GetBrand() => this.Brand;
    }
}
