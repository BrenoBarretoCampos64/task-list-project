using TaskListProject.Exceptions;
using TaskListProject.Entities.TaskRelated;

namespace TaskListProject.Services
{
	internal class TaskInputValidator
	{
		public static void ValidateTitleAndDescription(Title title, Description description)
		{
			ValidateTaskTitle(title);
			ValidateTaskDescription(description);
		}

		public static void ValidateTaskTitle(Title title)
		{
			if (title.Content.Length > Title.TitleMaximumLength)
			{
				throw new TitleLengthException("   [ TASK TITLE EXCEEDED MAXIMUM LENGTH ]");
			}
		}

		public static void ValidateTaskDescription(Description description)
		{
			if (description.Content.Length > Description.DescriptionMaximumLength)
			{
				throw new DescriptionLengthException("   [ TASK DESCRIPTION EXCEEDED MAXIMUM LENGTH ]");
			}
		}

		public static void ValidateTaskDeadline(DateTime deadline)
		{
			if (deadline < DateTime.Now)
			{
				throw new DeadlineException("   [ TASK DEADLINE ALREADY MISSED ]");
			}
		}
	}
}
