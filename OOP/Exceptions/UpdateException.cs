namespace OOP.Exceptions
{
    public class UpdateException : Exception
    {
        public UpdateException() : base() { }

        public UpdateException(string message) : base(message) { }

        public UpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
