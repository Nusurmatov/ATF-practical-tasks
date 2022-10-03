﻿using CarPark;

namespace OOP.VehicleParts
{
    public class Transmission
    {
        public enum TransmissionType { Manual, Automatic, SemiAuto };
        public enum TransmissionBrand { Aisin, Claas, Getrag, Hewland, LiuGong, Volvo }

        public TransmissionType Type { get; }
        public TransmissionBrand Brand { get; }
        public int GearsNumber { get; }

        public Transmission()
        { 
            this.Type = (TransmissionType) Program.Random.Next(3);
            this.Brand = (TransmissionBrand) Program.Random.Next(6);
            this.GearsNumber = Program.Random.Next(4, 9);
        }

        public string GetInfo()
        {
            return "Transmimssion Info --- " + this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Type: {this.Type}, Gears Number: " +
                $"{this.GearsNumber}, Brand: {this.Brand}.");

            return result.ToString();
        }
    }
}
