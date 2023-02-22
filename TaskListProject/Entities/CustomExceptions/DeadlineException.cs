namespace TaskListProject.Entities.CustomExceptions
{
	internal class DeadlineException : ApplicationException
	{
		public DeadlineException(string message) : base(message)
		{
		}
	}
}
