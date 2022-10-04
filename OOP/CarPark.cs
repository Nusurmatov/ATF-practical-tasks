﻿using OOP.Vehicles;

namespace CarPark
{
    public class Program
    {
        public static Random Random { get; } = new Random(); 
        
        protected Program()
        { }  // this class cannot be inherited

        public static void Main(string[] args)
        {
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

            SolveNetCollectionsTask();
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
                Thread.Sleep(1000);
            }
        }

        private static void SolveNetCollectionsTask()
        {
            var carPark = new NetCollections.Collection();
            carPark.Add(new PassengerCar(), Random.Next(1, 7));
            carPark.Add(new Truck(), Random.Next(1, 7));
            carPark.Add(new Bus(), Random.Next(1, 7));
            carPark.Add(new Scooter(), Random.Next(1, 7));

            carPark.CreateEngineCapcityXml();
            carPark.CreateEngineOfBusesAndTrucksXml();
            carPark.CreateTransmissionXml();
        }
    }
}