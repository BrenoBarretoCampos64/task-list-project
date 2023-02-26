using TaskListProject.Exceptions;

namespace TaskListProject.Entities.TaskRelated
{
	internal class TaskList
	{
		public int NumberOfTasks { get; set; }

		private List<Task> _tasks = new List<Task>();

		public TaskList()
		{
			NumberOfTasks = 0;
		}

		public List<Task> GetTasks()
		{
			return _tasks;
		}

		public void AddTask(Title title, Description description, bool hasDeadline, DateTime deadline)
		{
			int Id = NumberOfTasks + 1;
			_tasks.Add(new Task(Id, title, description, hasDeadline, deadline));
			ReorganizeTaskNumbers();
			NumberOfTasks++;
		}

		public void ClearTask(int number)
		{
			Task task = SearchTaskByNumber(number);
			_tasks.Remove(task);
			ReorganizeTaskNumbers();
			NumberOfTasks--;
		}

		public void ReorganizeTaskNumbers()
		{
			NumberOfTasks = 0;

			foreach (Task task in _tasks)
			{
				NumberOfTasks++;
				task.Number = NumberOfTasks;
			}
		}

		public void FinishTaskByNumber(int number)
		{
			Task task = SearchTaskByNumber(number);

			if (task.IsFinished)
			{
				throw new TaskException("   [ THIS TASK IS ALREADY FINISHED ]");
			}

			task.FinishTask();
		}

		public Task SearchTaskByNumber(int number)
		{
			foreach (Task task in _tasks)
			{
				if (number == task.Number)
				{
					return task;
				}
			}
			throw new TaskException("   [ TASK NUMBER NOT FOUND IN TASK LIST ]");
		}

		public void LoadTaskList(List<Task> list)
		{
			_tasks.AddRange(list);
		}

		public void GenerateSampleTasks()
		{
			AddTask(new Title("Clean the house"), new Description("Use the vacuum cleaner on the carpets"), true, DateTime.Now.AddDays(1));
			AddTask(new Title("Finish essay"), new Description("The english essay must have at least 20 lines"), true, DateTime.Now.AddDays(2));
			AddTask(new Title("Medical appointment"), new Description("Annual medical checkup"), true, DateTime.Now.AddDays(7));
			AddTask(new Title("Visit friend"), new Description("Spare some time to visit your best friend"), false, DateTime.Now.AddMonths(1));
		}
	}
}
