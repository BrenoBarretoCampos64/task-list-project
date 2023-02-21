namespace TaskListProject.Entities.CustomExceptions
{
    internal class TaskException : ApplicationException
    {
        public TaskException(string message) : base(message)
        {
        }
    }
}
