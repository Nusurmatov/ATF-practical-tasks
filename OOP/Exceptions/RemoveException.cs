namespace OOP.Exceptions
{
    public class RemoveException : Exception
    {
        public RemoveException() : base() { }

        public RemoveException(string message) : base(message) { }

        public RemoveException (string message, Exception innerException) : base(message, innerException) { }
    }
}
