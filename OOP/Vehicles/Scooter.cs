﻿using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class Scooter : Vehicle
    {
        public enum ScooterBrand { Kugoo, Razor, Evo, Segway, Apollo, Jetson, GoTrax }

        private ScooterBrand Brand { get; }

        public Scooter() : this((ScooterBrand) Program.Random.Next(7)) { }

        public Scooter(ScooterBrand brand)
        {
            this.Type = "Scooter";
            this.Engine = new Engine(capacity: Program.Random.NextDouble() * 1.5,
                power: Program.Random.Next(30, 100));
            this.Chassis = new Chassis(wheelsNumber: 2, 
                loadLimit: Program.Random.Next(100, 200));
            this.Transmission = new Transmission();
            this.Brand = brand;
        }

        public Scooter(ScooterBrand brand, Chassis chassis, Engine engine, Transmission transmission)
        {
            this.Brand = brand;
            this.Chassis = chassis;
            this.Engine = engine;
            this.Transmission = transmission;
        }

        public override string GetInfo() => $"{base.ToString()}Manufacturer: {this.Brand}.\n";

        public override string ToString() => $"Type: {this.Type}, Manufacturer: {this.Brand}.\n";

        public ScooterBrand GetBrand() => this.Brand;
    }
}
