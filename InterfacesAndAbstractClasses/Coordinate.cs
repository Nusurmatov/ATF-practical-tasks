namespace InterfacesAndAbstractClasses
{
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinate(int x = 0, int y = 0, int z = 0)
        {
            this.X = x; this.Y = y; this.Z = z;
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