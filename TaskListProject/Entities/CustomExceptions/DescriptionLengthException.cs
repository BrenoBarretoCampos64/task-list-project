namespace TaskListProject.Entities.CustomExceptions
{
    internal class DescriptionLengthException : ApplicationException
    {
        public DescriptionLengthException(string message) : base(message)
        {
        }
    }
}
