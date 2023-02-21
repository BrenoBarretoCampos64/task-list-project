namespace TaskListProject.Entities.TaskRelated
{
    internal class Task
    {
        public int Number { get; set; }
        public static int TitleMaximumLength { get; set; } = 54;
        public static int DescriptionMaximumLength { get; set; } = 162;
        public bool IsFinished { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }

        public Task()
        {
        }

        public Task(int number, string? title, string? description)
        {
			TaskInputValidator.ValidateTaskTitle(title);
			TaskInputValidator.ValidateTaskDescription(description);

			Number = number;
            IsFinished = false;
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
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
