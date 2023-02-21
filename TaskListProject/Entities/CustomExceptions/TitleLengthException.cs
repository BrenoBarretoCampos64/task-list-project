namespace TaskListProject.Entities.CustomExceptions
{
    internal class TitleLengthException : ApplicationException
    {
        public TitleLengthException(string message) : base(message)
        {
        }
    }
}