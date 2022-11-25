using OOP.Vehicles;
using OOP.Exceptions;

namespace NetCollections
{
    public class Collection
    {
        readonly List<PassengerCar> Cars = new List<PassengerCar>();
       
        readonly List<Truck> Trucks = new List<Truck>();
        
        readonly List<Bus> Buses = new List<Bus>();
        
        readonly List<Scooter> Scooters = new List<Scooter>();
            
        public void Add(Vehicle vehicle, int number = 1) 
        {

            for (int i = 0; i < number; i++)
            {
                if (vehicle is PassengerCar car)
                {
                    this.Cars.Add(car);
                }
                else if (vehicle is Truck truck)
                {
                    this.Trucks.Add(truck);
                }
                else if (vehicle is Bus bus)
                {
                    this.Buses.Add(bus);
                }
                else if (vehicle is Scooter scooter) 
                {
                    this.Scooters.Add(scooter);
                }
                else
                {
                    throw new AddException("Cannot add a car");
                }
            }
        }

        public Vehicle? GetAutoByParameter(string parameter, string value)
        {
            try
            {
                if (parameter.Trim().ToLower() == "brand")
                {
                    switch (value.Trim().ToLower())
                    {
                        case "bmw":
                            return FindCar(PassengerCar.CarBrand.BMW);
                        case "toyoto":
                            return FindCar(PassengerCar.CarBrand.Toyota);
                        case "tesla":
                            return FindCar(PassengerCar.CarBrand.Tesla);
                        case "chevrolet":
                            return FindCar(PassengerCar.CarBrand.Chevrolet);
                        case "mustang":
                            return FindCar(PassengerCar.CarBrand.Mustang);
                        case "freighliner":
                            return FindTruck(Truck.TruckBrand.Freighliner);
                        case "man":
                            return FindTruck(Truck.TruckBrand.MAN);
                        case "volvo":
                            return FindTruck(Truck.TruckBrand.Volvo);
                        case "isuzu":
                            return FindTruck(Truck.TruckBrand.Isuzu);
                        case "kamaz":
                            return FindBus(Bus.BusBrand.Kamaz);
                        case "volsvagen":
                            return FindBus(Bus.BusBrand.Volksvagen);
                        case "scania":
                            return FindBus(Bus.BusBrand.Scania);
                        case "kugoo":
                            return FindScooter(Scooter.ScooterBrand.Kugoo);
                        case "razor":
                            return FindScooter(Scooter.ScooterBrand.Razor);
                        case "evo":
                            return FindScooter(Scooter.ScooterBrand.Evo);
                        case "segway":
                            return FindScooter(Scooter.ScooterBrand.Segway);
                        case "apollo":
                            return FindScooter(Scooter.ScooterBrand.Apollo);
                        case "jetson":
                            return FindScooter(Scooter.ScooterBrand.Jetson);
                        case "gotrax":
                            return FindScooter(Scooter.ScooterBrand.GoTrax);
                        default:
                            throw new GetAutoByParameterException("Cannot add by parameter");
                    }
                }
                else if (parameter.Trim().ToLower() == "type")
                {
                    switch (value.Trim().ToLower())
                    {
                        case "passenger car":
                            return this.Cars[0];
                        case "truck":
                            return this.Trucks[0];
                        case "bus":
                            return this.Buses[0];
                        case "scooter":
                            return this.Scooters[0];
                        default:
                            throw new GetAutoByParameterException("Cannot add by parameter");

                    }
                }
                else
                {
                    throw new GetAutoByParameterException("Cannot add by parameter");
                }
            }
            catch
            {
                throw new GetAutoByParameterException("Cannot add by parameter");
            }
        }

        public void Update(Vehicle vehicle, int index)
        {
            try
            {
                if (vehicle is PassengerCar car)
                {
                    this.Cars[index] = car;
                }
                else if (vehicle is Truck truck)
                {
                    this.Trucks[index] = truck;
                }
                else if (vehicle is Bus bus)
                {
                    this.Buses[index] = bus;
                }
                else if (vehicle is Scooter scooter)
                {
                    this.Scooters[index] = scooter;
                }
            }
            catch
            {
                throw new UpdateException("Cannot update!");
            }
        }

        public void Remove(Vehicle vehicle)
        {
            if (vehicle is PassengerCar car)
            {
                this.Cars.Remove(car);
            }
            else if (vehicle is Truck truck)
            {
                this.Trucks.Remove(truck);
            }
            else if (vehicle is Bus bus)
            {
                this.Buses.Remove(bus);
            }
            else if (vehicle is Scooter scooter)
            {
                this.Scooters.Remove(scooter);
            }
            else
            {
                throw new UpdateException("Cannot update!");
            }
        }

        public void CreateEngineCapcityXml()
        {
            using (var writer = new StreamWriter("engineCapacity.xml"))
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
            using (var writer = new StreamWriter("engineCapacity.xml"))
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
            using (var writer = new StreamWriter("engineCapacity.xml"))
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

        private PassengerCar? FindCar(PassengerCar.CarBrand brand)
        {
            foreach (var car in this.Cars)
            {
                if (car.GetBrand() == brand)
                {
                    return car;
                }
            }

            return null;
        }

        private Truck? FindTruck(Truck.TruckBrand brand)
        {
            foreach (var truck in this.Trucks)
            {
                if (truck.GetBrand() == brand)
                {
                    return truck;
                }
            }

            return null;
        }

        private Bus? FindBus(Bus.BusBrand brand)
        {
            foreach (var bus in this.Buses)
            {
                if (bus.GetBrand() == brand)
                {
                    return bus;
                }
            }

            return null;
        }

        private Scooter? FindScooter(Scooter.ScooterBrand brand)
        {
            foreach (var scooter in this.Scooters)
            {
                if (scooter.GetBrand() == brand)
                {
                    return scooter;
                }
            }

            return null;
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