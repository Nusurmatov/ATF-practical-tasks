using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class PassengerCar : Vehicle
    {
        public enum CarBrand { BMW, Toyota, Tesla, Chevrolet, Mustang }
     
        private CarBrand Brand { get; }
        
        public PassengerCar() : this((CarBrand) Program.Random.Next(5)) { }

        public PassengerCar(CarBrand brand)
        {
            this.Type = "Passenger Car";
            this.Engine = new Engine(capacity: Program.Random.NextDouble() * 3,
                power: Program.Random.Next(100, 500));
            this.Chassis = new Chassis(loadLimit: Program.Random.Next(200, 1000));
            this.Transmission = new Transmission();
            this.Brand = brand;
        }

        public PassengerCar(CarBrand brand, Chassis chassis, Engine engine, Transmission transmission)
        {
            this.Brand = brand;
            this.Chassis = chassis;
            this.Engine = engine;
            this.Transmission = transmission;
        }

        public override string GetInfo() => $"{base.ToString()}Manufacturer: {this.Brand}.\n";

        public override string ToString() => $"Type: {this.Type}, Manufacturer: {this.Brand}.\n";

        public CarBrand GetBrand() => this.Brand;
    }
}
