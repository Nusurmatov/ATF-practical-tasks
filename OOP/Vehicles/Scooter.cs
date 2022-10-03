using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class Scooter : Vehicle
    {
        public enum ScooterBrand { Kugoo, Razor, Evo, Segway, Apollo, Jetson, GoTrax }

        private ScooterBrand Brand { get; }

        public Scooter()
        {
            this.Type = "Scooter";
            this.Engine = new Engine(power: Program.Random.Next(30, 100));
            this.Chassis = new Chassis(wheelsNumber: 2, 
                loadLimit: Program.Random.Next(100, 200));
            this.Transmission = new Transmission();
            this.Brand = (ScooterBrand) Program.Random.Next(7);
        }

        public override string GetInfo()
        {
            return base.ToString() + $"Brand : {this.Brand}.\n";
        }

        public override string ToString()
        {
            return $"Type: {this.Type}, Brand: {this.Brand}.\n";
        }
    }
}
