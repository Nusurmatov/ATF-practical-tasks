namespace ObjectOrientedDesignPrinciples
{
    public sealed class Car
    {
        private static  Car? _instance;  

        private string _brand = "None";

        private string _model = "None";
        
        private int _quantity;

        private decimal _price = 0.0m;

        public Dictionary<string, List<string>>? CarData { get; private set; } = new Dictionary<string, List<string>>();

        public Dictionary<string, List<decimal>>? CarBrandPriceByBrand { get; private set; } = new Dictionary<string, List<decimal>>();

        public List<decimal> CarPrices { get; private set; } = new List<decimal>();

        public string Brand 
        {
            get => _brand;
            set 
            {
                if (String.IsNullOrEmpty(_brand))
                {
                    throw new ArgumentException("Brand name must not be blank!");
                }
                
                _brand = value.Trim().ToUpperInvariant();
            } 
        }

        public string Model 
        {
            get => _model;
            set 
            {
                if (String.IsNullOrEmpty(_model))
                {
                    throw new ArgumentException("Brand name must not be blank!");
                }
                
                _model = value.Trim().ToUpperInvariant();
            } 
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }

                _quantity = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price < 0.0m)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                _price = value;
            }
        }

        public int TotalNumberOfCars { get; private set; } = 0;

        private Car() { }

        public void SetBrand(string brand) => Brand = brand; 

        public void SetModel(string model) => Model = model;
        
        public void SetQuantity(int quantity)
        {
            TotalNumberOfCars += quantity;
            Quantity = quantity;
        }

        public void SetPrice(decimal price)
        {
            CarPrices.Add(price);
            Price = price;
        } 

        public string GetBrand() => Brand;

        public string GetModel() => Model;

        public int GetQuantity() => Quantity;

        public decimal GetPrice() => Price;

        public static Car GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Car();
            }

            return _instance;
        }
    }
}