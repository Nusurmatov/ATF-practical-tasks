﻿using OOP.Vehicles;
using OOP.VehicleParts;

namespace CarPark
{
    public class Program
    {
        public static Random Random { get; } = new Random(); 
        
        protected Program()
        { }  // this class cannot be inherited

        public static void Main(string[] args)
        {
            SolveNetCollectionsTask();

            SetShriftColor();
            var passengerCar = new PassengerCar();
            Console.Write(passengerCar.GetInfo());
            Wait();
            
            SetShriftColor();
            var truck = new Truck();
            Console.Write(truck.GetInfo());
            Wait();
            
            SetShriftColor();
            var bus = new Bus();
            Console.Write(bus.GetInfo());
            Wait();
            
            SetShriftColor();
            var scooter = new Scooter();
            Console.Write(scooter.GetInfo());
            Wait();

            SetShriftColor();
            Console.Write("The End...!");
        }

        private static void SetShriftColor()
        {
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor) Random.Next(1, 16);  // random shrift color
        }

        private static void Wait()
        {
            Console.Write("\n\n\nYou have 10 secunds to read the above content: ");

            for (int i = 1; i < 11; i++)
            {
                Console.Write($"{i} ");
               /// Thread.Sleep(1000);
            }
        }

        private static void SolveNetCollectionsTask()
        {
            var carPark = new NetCollections.Collection();
            int lowerBound = 1;
            int upperBound = 7;

            // InitializaionException
            var chassis = new Chassis(wheelsNumber: 0);
            var engine = new Engine();
            var transmission = new Transmission();
            carPark.Add(new Truck(Truck.TruckBrand.MAN, chassis, engine, transmission));

            // AddException 
            /// carPark.Add(null);

            // GetAutoByParameterException
            /// carPark.GetAutoByParameter(parameter: "brand", value: "mtz");

            // UpdateException
            /// var scooter = new Scooter();
            /// carPark.Add(scooter, Random.Next(lowerBound, upperBound));
            /// carPark.Update(vehicle: new Scooter(), index: 7);

            /// carPark.Remove(new Bus());

            carPark.Add(new PassengerCar(), Random.Next(lowerBound, upperBound));
            carPark.Add(new Truck(), Random.Next(lowerBound, upperBound));
            carPark.Add(new Bus(), Random.Next(lowerBound, upperBound));

            carPark.CreateEngineCapcityXml();
            carPark.CreateEngineOfBusesAndTrucksXml();
            carPark.CreateTransmissionXml();
        }
    }
}