namespace ObjectOrientedDesignPrinciples
{
    public interface ICommand
    {
        void Execute();
    }

    public class CountCarBrands : ICommand
    {
        private CarInformation? _carInfo;

        public CountCarBrands(CarInformation carInfo)
        {
            this._carInfo = carInfo;
        }

        public void Execute()
        {
            Console.WriteLine($"Total Car Brands: {this._carInfo?.GetBrandCount()}\n");
        }
    }   

    public class CountTotalCars : ICommand
    {
        private CarInformation? _carInfo;

        public CountTotalCars(CarInformation carInfo)
        {
            this._carInfo = carInfo;
        }

        public void Execute()
        {
            Console.WriteLine($"Total number of cars: {_carInfo?.GetTotalCarNumber()}\n");
        }
    } 

    public class AverageCarPrice : ICommand
    {
        private CarInformation? _carInfo;

        public AverageCarPrice(CarInformation carInfo)
        {
            this._carInfo = carInfo;
        }    

        public void Execute()
        {
            Console.WriteLine($"Average Car price: {_carInfo?.GetAveragePrice():C2}\n");
        }
    } 

    public class AverageCarPriceByBrand : ICommand
    {
        private CarInformation? _carInfo;

        private string brandName;

        public AverageCarPriceByBrand(CarInformation carInfo, string brandName)
        {
            this._carInfo = carInfo;
            this.brandName = brandName;
        }

        public void Execute()
        {
            decimal? averagePrice = _carInfo?.GetAveragePriceByBrand(brandName);
            if (averagePrice == -0.1m)
            {
                Console.WriteLine("There is no such brand as {0}.", brandName);
            }
            else
            {
                Console.WriteLine($"Average price of {brandName}: {averagePrice:C2}\n");
            }
        }
    } 

    public class Invoker
    {
        private ICommand? _command;

        public Invoker(ICommand command)
        {
            this._command = command;
        }        

        public void SetCarInfo(Car car)
        {

        }

        public void Invoke()
        {
            if (this._command is ICommand)
            {
                Console.Clear();
                Console.WriteLine();
                this._command.Execute();
            }
        }
    }

    public class CarInformation
    {
        private static Dictionary<string, List<string>>? CarData;

        private static Dictionary<string, decimal>? CarBrandTotalPrice;

        private static Car? _car;

        public CarInformation(Car car)
        {
            _car = car;
            
            for (int i = 0; i < _car.GetQuantity(); i++)
            {
                if (CarData != null && CarBrandTotalPrice != null && CarData.ContainsKey(_car.GetBrand()))
                {
                    CarData[_car.GetBrand()].Add(_car.GetModel());
                    CarBrandTotalPrice[_car.GetBrand()] += _car.GetPrice();
                }
                else
                {
                    CarData?.Add(_car.GetBrand(), new List<string> { _car.GetModel() } );
                    CarBrandTotalPrice?.Add(_car.GetBrand(), _car.GetPrice());
                }
            }
        }

        public int GetBrandCount()
        {
            if (CarData != null)
            {
                return CarData.Keys.Count;
            }

            return 0;
        }

        public int GetTotalCarNumber() => Car.TotalNumbreOfCars;

        public decimal GetAveragePrice() => Car.AverageCarPrice;

        public decimal GetAveragePriceByBrand(string brandName)
        { 
            if (CarData != null && CarBrandTotalPrice != null)
            {
                if (CarBrandTotalPrice.ContainsKey(brandName))
                {
                    foreach (var brand in CarBrandTotalPrice.Keys)
                    {
                        if (brandName.Trim().ToUpperInvariant() == brand)
                        {
                            return CarBrandTotalPrice[brand] / CarData[brand].Count;
                        }
                    }
                }
                else
                {
                    return -0.1m;
                }
            }

            return 0.0m;
        }
    }    
}