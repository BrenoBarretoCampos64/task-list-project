namespace TaskListProject.Exceptions
{
    internal class TitleLengthException : ApplicationException
    {
        public TitleLengthException(string message) : base(message)
        {
        }
    }
}