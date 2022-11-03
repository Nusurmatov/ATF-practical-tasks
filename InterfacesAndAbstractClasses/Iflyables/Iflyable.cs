namespace InterfacesAndAbstractClasses
{
    public interface IFlyable
    {
        void FlyTo(Coordinate point);

        int GetFlyTime(Coordinate point);
    }
}
