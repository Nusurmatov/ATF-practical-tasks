using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class Bus : Vehicle
    {
        public enum BusBrand { Kamaz, MAN, Volksvagen, Scania }
        private BusBrand Brand { get; }

        public Bus()
        {
            this.Type = "Bus";
            this.Engine = new Engine(power: 
                Program.Random.Next(1000, 3000), volume: 8);
            this.Chassis = new Chassis(wheelsNumber: 6, 
                loadLimit: Program.Random.Next(1000, 3000));
            this.Transmission = new Transmission();
            this.Brand = (BusBrand) Program.Random.Next(4);
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
