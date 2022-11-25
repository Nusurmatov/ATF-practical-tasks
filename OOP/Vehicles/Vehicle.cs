using OOP.VehicleParts;

namespace OOP.Vehicles
{
    public abstract class Vehicle
    {
        public string Type { get; protected set; } = "Vehicle";  
    
        public Engine Engine { get; protected set; } = new Engine();
        
        public Chassis Chassis { get; protected set; } = new Chassis();
        
        public Transmission Transmission { get;  protected set; } 
            = new Transmission();

        public virtual string GetInfo() => this.ToString();

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine($"------- {this.Type} Info -------");
            result.Append(this.Engine.GetInfo());
            result.Append(this.Chassis.GetInfo());
            result.Append(this.Transmission.GetInfo());

            return result.ToString();
        }
    }
}