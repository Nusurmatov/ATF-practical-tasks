namespace ObjectOrientedDesignPrinciples
{
    public interface ICommand
    {
        void Execute();
    }

    public class CountCarBrands : ICommand
    {
        private readonly CarInformation? _carInfo;

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
        private readonly CarInformation? _carInfo;

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
        private readonly CarInformation? _carInfo;

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
        private readonly CarInformation? _carInfo;

        private readonly string brandName;

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
        private readonly ICommand? _command;

        public Invoker(ICommand command)
        {
            this._command = command;
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
        private readonly Car _car;

        public CarInformation(Car car)
        {
            _car = car;
            
            for (int i = 0; i < _car.GetQuantity(); i++)
            {
                if (_car.CarData != null && _car.CarBrandPriceByBrand != null && _car.CarData.ContainsKey(_car.GetBrand()))
                {
                    _car.CarData[_car.GetBrand()].Add(_car.GetModel());
                    _car.CarBrandPriceByBrand[_car.GetBrand()].Add(_car.GetPrice());
                }
                else
                {
                    _car.CarData?.Add(_car.GetBrand(), new List<string> { _car.GetModel() } );
                    _car.CarBrandPriceByBrand?.Add(_car.GetBrand(), new List<decimal> { _car.GetPrice() } );
                }
            }
        }

        public int GetBrandCount()
        {
            if (_car.CarData != null)
            {
                return _car.CarData.Keys.Count;
            }

            return 0;
        }

        public int GetTotalCarNumber() => _car.TotalNumberOfCars;

        public decimal GetAveragePrice()
        {
            _car.CarPrices.Sort();

            return _car.CarPrices[_car.CarPrices.Count / 2];
        }

        public decimal GetAveragePriceByBrand(string brandName)
        {
            brandName = brandName.Trim().ToUpperInvariant();

            if (_car.CarData != null && _car.CarBrandPriceByBrand != null)
            {
                if (_car.CarBrandPriceByBrand.ContainsKey(brandName))
                {
                    foreach (var brand in _car.CarBrandPriceByBrand.Keys)
                    {
                        if (brandName == brand)
                        {
                            _car.CarBrandPriceByBrand[brandName].Sort();

                            return _car.CarBrandPriceByBrand[brandName][_car.CarBrandPriceByBrand.Count / 2];
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