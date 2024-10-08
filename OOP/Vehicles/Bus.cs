﻿using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class Bus : Vehicle
    {
        public enum BusBrand { Kamaz, MAN, Volksvagen, Scania }
        
        private BusBrand Brand { get; }

        public Bus() : this((BusBrand) Program.Random.Next(4)) {  }

        public Bus(BusBrand brand)
        {
            this.Type = "Bus";
            this.Engine = new Engine(capacity: Program.Random.NextDouble() * 4, 
                power: Program.Random.Next(1000, 3000), volume: 8);
            this.Chassis = new Chassis(wheelsNumber: 6, 
                loadLimit: Program.Random.Next(1000, 3000));
            this.Transmission = new Transmission();
            this.Brand = brand;
        }

        public Bus(BusBrand brand, Chassis chassis, Engine engine, Transmission transmission)
        {
            this.Brand = brand;
            this.Chassis = chassis;
            this.Engine = engine;
            this.Transmission = transmission;
        }

        public override string GetInfo() => $"{base.ToString()}Manufacturer: {this.Brand}.\n";

        public override string ToString() => $"Type: {this.Type}, Manufacturer: {this.Brand}.\n";

        public BusBrand GetBrand() => this.Brand;
    }
}
