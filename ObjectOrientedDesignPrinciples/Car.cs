namespace ObjectOrientedDesignPrinciples
{
    public sealed class Car
    {
        private static Car? _instance;  

        private static string _brand = "None";

        private static string _model = "None";
        
        private static int _quantity;

        private static decimal _price;
        
        public static string Brand 
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

        public static string Model 
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

        public static int Quantity
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

        public static decimal Price
        {
            get => _price;
            set
            {
                if (_price < 0.0m)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
            }
        }

        public static int TotalNumbreOfCars { get; private set; }

        public static decimal AverageCarPrice { get; private set; }

        private static decimal TotalCarPrice { get; set; }

        private Car() { }

        public void SetBrand(string brand) => Brand = brand; 

        public void SetModel(string model) => Model = model;
        
        public void SetQuantity(int quantity)
        {
            TotalNumbreOfCars += quantity;
            Quantity = quantity;
        }

        public void SetPrice(decimal price)
        {
            TotalCarPrice += price;
            AverageCarPrice = (TotalNumbreOfCars != 0) ? TotalCarPrice / TotalNumbreOfCars : price; 
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