using TaskListProject.Entities.CustomExceptions;

namespace TaskListProject.Entities.TaskRelated
{
    internal static class TaskInputValidator
    {
        public static void ValidateTitleAndDescription(string title, string description)
        {
            ValidateTaskTitle(title);
            ValidateTaskDescription(description);
        }

        public static void ValidateTaskTitle(string title)
        {
            if (title.Length > Task.TitleMaximumLength)
            {
                throw new TitleLengthException("[ TASK TITLE EXCEEDED MAXIMUM LENGTH ]");
            }
        }

        public static void ValidateTaskDescription(string description)
        {
            if (description.Length > Task.TitleMaximumLength)
            {
                throw new DescriptionLengthException("[ TASK DESCRIPTION EXCEEDED MAXIMUM LENGTH ]");
            }
        }

        public static void ValidateTaskDeadline(DateTime deadline)
        {
            if (deadline < DateTime.Now)
            {
				throw new DeadlineException("[ TASK DEADLINE ALREADY MISSED ]");
			}
        }
    }
}
