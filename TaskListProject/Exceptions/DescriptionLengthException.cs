namespace TaskListProject.Exceptions
{
    internal class DescriptionLengthException : ApplicationException
    {
        public DescriptionLengthException(string message) : base(message)
        {
        }
    }
}
