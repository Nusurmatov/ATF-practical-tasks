namespace InterfacesAndAbstractClasses
{
    public struct Coordinate
    {
        private int _x;

        private int _y;

        private int _z;
            
        public int X 
        { 
            get => _x; 
            set
            {
                if (value < 0)
                    throw new ArgumentException("Cordinate is positive number");
                _x = value;
            }
        }
     
        public int Y 
        { 
            get => _y; 
            set
            {
                if (value< 0)
                    throw new ArgumentException("Cordinate is positive number");
               _y = value;
            }
        }
        
        public int Z 
        {
            get => _z;
            set
                    {
                if (value < 0)
                    throw new ArgumentException("Cordinate is positive number");
                _z = value;
            }
        }

        public Coordinate(int x = 0, int y = 0, int z = 0)
        {
            this._x = x; this._y = y; this._z = z;
        }

        public static int GetDistance(Coordinate point1, Coordinate point2)
        {
            // based on the Euclidean Distance Formula: https://en.wikipedia.org/wiki/Euclidean_distance
            double x = (point1.X - point2.X) * (point1.X - point2.X);
            double y = (point1.Y - point2.Y) * (point1.Y - point2.Y);
            double z = (point1.Z - point2.Z) * (point1.Z - point2.Z);

            return (int) Math.Sqrt(x + y + z);
        }

        public static Coordinate GenerateRandomPoint(int lowerBound, int upperBound)
        {
            var point = new Coordinate();
            point.X = Program.Random.Next(lowerBound, upperBound);
            point.Y = Program.Random.Next(lowerBound, upperBound);
            point.Z = Program.Random.Next(lowerBound, upperBound);

            return point;
        }
    }
}