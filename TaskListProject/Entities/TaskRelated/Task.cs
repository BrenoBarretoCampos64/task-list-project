namespace TaskListProject.Entities.TaskRelated
{
    internal class Task
    {
        public int Number { get; set; }
        public static int TitleMaximumLength { get; set; } = 54;
        public static int DescriptionMaximumLength { get; set; } = 162;
        public bool IsFinished { get; set; }
        public bool HasDeadline { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }

        public Task()
        {
        }

        public Task(int number, string? title, string? description, bool hasDeadline, DateTime deadline)
        {
			CheckTitleAndDescription(title, description);
			CheckDeadline(hasDeadline, deadline);

			Number = number;
            IsFinished = false;
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
            HasDeadline = hasDeadline;
            Deadline = deadline;
        }

        public void CheckTitleAndDescription(string title, string description)
        {
            if (title != "" && description != "")
            {
				TaskInputValidator.ValidateTitleAndDescription(title, description);
			}
        }

        public void CheckDeadline(bool hasDeadline, DateTime deadline)
        {
			if (hasDeadline)
			{
				TaskInputValidator.ValidateTaskDeadline(deadline);
			}
		}

		public void SetTitle(string newTitle)
        {
            TaskInputValidator.ValidateTaskTitle(newTitle);
            Title = newTitle;
        }

        public void SetDescription(string newDescription)
        {
            TaskInputValidator.ValidateTaskDescription(newDescription);
            Description = newDescription;   
        }

        public string GetRemainingDaysToDeadline()
        {
            if (HasDeadline == false)
            {
                return "";
            }

            TimeSpan remainingTime = Deadline.Subtract(DateTime.Now.ToUniversalTime());
            int remainingDays = remainingTime.Days;

            if (remainingDays < 0)
            {
                return "DEADLINE MISSED!";
            }
            if (remainingDays == 1)
            {
				return "DEADLINE IN " + remainingDays + " DAY";
			}
			if (remainingDays == 0)
			{
				return "DEADLINE IN " + remainingDays + " DAYS";
			}
			return "DEADLINE IN " + remainingDays + " DAYS";
		}

		public void FinishTask()
        {
            IsFinished = true;
        }

        public override string? ToString()
        {
            return "(" + Number + ")" + " " + Title;
        }
    }
}
