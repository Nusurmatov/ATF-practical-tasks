using System.Collections.Generic;
using OOP.Vehicles;

namespace NetCollections
{
    public class Collection
    {
        List<PassengerCar> Cars = new List<PassengerCar>();
        List<Truck> Trucks = new List<Truck>();
        List<Bus> Buses = new List<Bus>();
        List<Scooter> Scooters = new List<Scooter>();
            
        public void Add(Vehicle vehicle, int number = 1) 
        {
            for (int i = 0; i < number; i++)
            {
                if (vehicle is PassengerCar)
                {
                    this.Cars.Add((PassengerCar)vehicle);
                }
                else if (vehicle is Truck)
                {
                    this.Trucks.Add((Truck)vehicle);
                }
                else if (vehicle is Bus)
                {
                    this.Buses.Add((Bus)vehicle);
                }
                else if (vehicle is Scooter) 
                {
                    this.Scooters.Add((Scooter)vehicle);
                }
            }
        }

        public void CreateEngineCapcityXml()
        {
            using (var writer = new StreamWriter("Net Collections task\\engineCapacity.xml"))
            {
                writer.WriteLine("<vehicles>");

                foreach (var car in this.Cars)
                {
                    if (car.Engine.Capacity > 1.5)
                    {
                        WriteAllEngineInfo(car, writer);
                    }                    
                }   

                foreach (var truck in Trucks)
                {
                    WriteAllEngineInfo(truck, writer);
                }

                foreach (var bus in Buses)
                {
                    WriteAllEngineInfo(bus, writer);
                }

                writer.WriteLine("<\\vehicles>");
            }
        }

        public void CreateEngineOfBusesAndTrucksXml()
        {
            using (var writer = new StreamWriter("Net Collections task\\engineOfBusesAndTrucks.xml"))
            {
                writer.WriteLine("<vehicles>");

                foreach (var truck in Trucks)
                {
                    WriteAllEngineInfo(truck, writer);
                }

                foreach (var bus in Buses)
                {
                    WriteAllEngineInfo(bus, writer);
                }

                writer.WriteLine("<\\vehicles>");
            }
        }

        public void CreateTransmissionXml()
        {
            using (var writer = new StreamWriter("Net Collections task\\transmission.xml"))
            {
                writer.WriteLine("<vehicles>");
                writer.WriteLine("\t<transmission>");

                foreach (var car in Cars)
                {
                    WriteAllTransmissionInfo(car, writer);
                }

                foreach (var truck in Trucks)
                {
                    WriteAllTransmissionInfo(truck, writer);
                }

                foreach (var bus in Buses)
                {
                    WriteAllTransmissionInfo(bus, writer);
                }

                foreach (var scooter in Scooters)
                {
                    WriteAllTransmissionInfo(scooter, writer);
                }

                writer.WriteLine("\t<transmission>");
                writer.WriteLine("<\\vehicles>");
            }    
        }
        
        private void WriteAllEngineInfo(Vehicle vehicle, StreamWriter writer)
        {
            writer.WriteLine($"\t<{vehicle.Type.ToLower()}>");
            writer.WriteLine("\t\t<engine>");
            writer.WriteLine($"\t\t\t<capacity>{vehicle.Engine.Capacity}<\\capacity>");
            writer.WriteLine($"\t\t\t<power>{vehicle.Engine.Power}<\\power>");
            writer.WriteLine($"\t\t\t<volume>{vehicle.Engine.Volume}<\\volume>");
            writer.WriteLine($"\t\t\t<type>{vehicle.Engine.Type}<\\type>");
            writer.WriteLine($"\t\t\t<serialNumber>{vehicle.Engine.SerialNumber}<\\serialNumber");
            writer.WriteLine("\t\t<engine>");
            writer.WriteLine($"\t<\\{vehicle.Type.ToLower()}");
        } 

        private void WriteAllTransmissionInfo(Vehicle vehicle, StreamWriter writer)
        {
            writer.WriteLine($"\t\t<{vehicle.Type.ToLower()}>");
            writer.WriteLine($"\t\t\t<type>{vehicle.Transmission.Type}<\\type>");
            writer.WriteLine($"\t\t\t<brand>{vehicle.Transmission.Brand}<\\brand>");
            writer.WriteLine($"\t\t\t<gearsNumber>{vehicle.Transmission.GearsNumber}<\\gearsNumber>");
            writer.WriteLine($"\t\t<\\{vehicle.Type.ToLower()}");
        }
    }
}