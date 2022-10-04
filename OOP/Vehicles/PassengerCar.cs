﻿using OOP.VehicleParts;
using CarPark;

namespace OOP.Vehicles
{
    public class PassengerCar : Vehicle
    {
        public enum CarBrand { BMW, Toyota, Tesla, Chevrolet, Mustang }
        private CarBrand Brand { get; }
        public PassengerCar()
        {
            this.Type = "Passenger Car";
            this.Engine = new Engine(capacity: Program.Random.NextDouble() * 3,
                power: Program.Random.Next(100, 500));
            this.Chassis = new Chassis(loadLimit: Program.Random.Next(200, 1000));
            this.Transmission = new Transmission();
            this.Brand = (CarBrand) Program.Random.Next(5);
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