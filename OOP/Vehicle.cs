namespace Vehicle
{
    public abstract class Vehicle
    {
        protected static Random generator = new Random();

        public string Type { get; protected set; } = "Vehicle";  // default type
        public VehicleParts.Engine Engine { get; protected set; } = new VehicleParts.Engine();
        public VehicleParts.Chassis Chassis { get; protected set; } = new VehicleParts.Chassis();
        public VehicleParts.Transmission Transmission { get;  protected set; } = new VehicleParts.Transmission();

        public virtual string GetInfo()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine($"------- {this.Type} Info -------");
            result.Append(this.Engine.GetEngineInfo());
            result.Append(this.Chassis.GetChassisInfo());
            result.Append(this.Transmission.GetTransmissionsInfo());

            return result.ToString();
        }
    }

    public class PassengerCar : Vehicle
    {
        public enum CarBrand { BMW, Toyota, Tesla, Chevrolet, Mustang }
        private CarBrand Brand { get; }
        public PassengerCar()
        {
            this.Type = "Passenger Car";
            this.Engine = new VehicleParts.Engine(power: generator.Next(100, 500));
            this.Chassis = new VehicleParts.Chassis(loadLimit: generator.Next(200, 1000));
            this.Transmission = new VehicleParts.Transmission();
            this.Brand = (CarBrand) generator.Next(5);
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

    public class Truck : Vehicle
    {
        public enum TruckBrand { Freighliner, MAN, Volvo, Isuzu}
        private TruckBrand Brand { get; }

        public Truck()
        {
            this.Type = "Truck";
            this.Engine = new VehicleParts.Engine(power: generator.Next(1000, 7000), volume: 8);
            this.Chassis = new VehicleParts.Chassis(wheelsNumber: 12, loadLimit: generator.Next(1000, 5000));
            this.Transmission = new VehicleParts.Transmission();
            this.Brand = (TruckBrand) generator.Next(4);
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

    public class Bus : Vehicle
    {
        public enum BusBrand { Kamaz, MAN, Volksvagen, Scania}
        private BusBrand Brand { get; }

        public Bus()
        {
            this.Type = "Bus";
            this.Engine = new VehicleParts.Engine(power: generator.Next(1000, 3000), volume: 8);
            this.Chassis = new VehicleParts.Chassis(wheelsNumber: 6, loadLimit: generator.Next(1000, 3000));
            this.Transmission = new VehicleParts.Transmission();
            this.Brand = (BusBrand) generator.Next(4);
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

    public class Scooter : Vehicle
    {
        public enum ScooterBrand { Kugoo, Razor, Evo, Segway, Apollo, Jetson, GoTrax }

        private ScooterBrand Brand { get; }

        public Scooter()
        {
            this.Type = "Scooter";
            this.Engine = new VehicleParts.Engine(power: generator.Next(30, 100));
            this.Chassis = new VehicleParts.Chassis(wheelsNumber: 2, loadLimit: generator.Next(100, 200));
            this.Transmission = new VehicleParts.Transmission();
            this.Brand = (ScooterBrand) generator.Next(7);
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