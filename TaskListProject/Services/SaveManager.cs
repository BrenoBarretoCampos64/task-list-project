using TaskListProject.Entities.TaskRelated;
using Task = TaskListProject.Entities.TaskRelated.Task;

namespace TaskListProject.Services
{
	internal class SaveManager
	{
		public void SaveData(TaskList taskList)
		{
			string path = GetCurrentDirectory();
			var tasksToBeSaved = taskList.GetTasks();
			var tasksFormattedToJson = Newtonsoft.Json.JsonConvert.SerializeObject(tasksToBeSaved);

			File.WriteAllText(path, tasksFormattedToJson);
		}

		public List<Task> LoadData()
		{
			string path = GetCurrentDirectory();
			string justText = File.ReadAllText(path);

			Task[]? loadedTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<Task[]>(justText);
			List<Task> tasks = loadedTasks.ToList();

			return tasks;
		}

		public string GetCurrentDirectory()
		{
			const string DatabaseName = "task-database.json";
			const string PointOfSplit = "bin";

			string fullCurrentProjectDirectory = Environment.CurrentDirectory;
			string[] splitCurrentProjectDirectory = fullCurrentProjectDirectory.Split(PointOfSplit);
			string projectCurrentDirectory = splitCurrentProjectDirectory[0];
			return projectCurrentDirectory + DatabaseName;
		}
	}
}
