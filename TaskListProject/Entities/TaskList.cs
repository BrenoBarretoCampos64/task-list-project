namespace TaskListProject.Entities
{
	internal class TaskList
	{
		public int NumberOfTasks { get; set; }

		private List<Task> Tasks = new List<Task>();

		public TaskList()	
		{
			NumberOfTasks = 0;
		}

		public List<Task> GetTasks()
		{
			return Tasks;
		}

		public void AddTask(string title, string description)
		{

			if (title.Length > Task.TitleMaximumLength)
			{
				throw new Exception();
			}

			if (description.Length > Task.DescriptionMaximumLength)
			{
				throw new Exception();
			}

			int Id = NumberOfTasks + 1;
			Tasks.Add(new Task(Id, title, description));
			ReorganizeTaskNumbers();
			NumberOfTasks++;
		}

		public void ClearTask(int number)
		{
			Task task = ValidateAndGetTask(number);
			Tasks.Remove(task);
			ReorganizeTaskNumbers();
			NumberOfTasks--;
		}

		public void ReorganizeTaskNumbers()
		{
			NumberOfTasks = 0;

			foreach (Task task in Tasks)
			{
				NumberOfTasks++;
				task.Number = NumberOfTasks;
			}
		}

		public void FinishTaskByNumber(int number)
		{
			Task task = ValidateAndGetTask(number);
			task.FinishTask();
		}

		public Task ValidateAndGetTask(int number)
		{
			foreach (Task task in Tasks)
			{
				if (number == task.Number)
				{
					return task;
				}
			}
			throw new Exception();
		}
	}
}
