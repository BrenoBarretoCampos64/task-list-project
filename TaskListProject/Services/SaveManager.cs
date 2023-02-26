using System.Text;
using TaskListProject.Entities.TaskRelated;
using Task = TaskListProject.Entities.TaskRelated.Task;

namespace TaskListProject.Services
{
	internal class SaveManager	
	{
		public void SaveData(TaskList taskList)
		{
			string path = GetCurrentDirectory();

			File.WriteAllText(path, string.Empty);

            using (StreamWriter streamWriter = File.AppendText(path))
			{
				StringBuilder stringBuilder = new StringBuilder();

				foreach (Task task in taskList.GetTasks())
				{
					stringBuilder.Append(task.Number + ",");
					stringBuilder.Append(task.Title.Content + ",");
					stringBuilder.Append(task.Description.Content + ",");
					stringBuilder.Append(task.IsFinished.ToString() + ",");
					stringBuilder.Append(task.HasDeadline.ToString() + ",");
					stringBuilder.Append(task.CreationDate.ToString() + ",");
					stringBuilder.Append(task.Deadline.ToString() + ",");
					streamWriter.WriteLine(stringBuilder.ToString());
					stringBuilder.Clear();
				}
			}
		}

		public List<Task> LoadData()
		{
			string path = GetCurrentDirectory();
			List<Task> loadedTasks = new List<Task>();

			using (StreamReader streamReader = File.OpenText(path))
			{
				while (streamReader.EndOfStream == false)
				{
					string[] taskProperties = streamReader.ReadLine().Split(',');

					int id = int.Parse(taskProperties[0]);
					Title title = new Title(taskProperties[1]);
					Description description = new Description(taskProperties[2]);
					bool isFinished = bool.Parse(taskProperties[3]);
					bool hasDeadline = bool.Parse(taskProperties[4]);
					DateTime creationDate = DateTime.Parse(taskProperties[5]);
					DateTime deadline = DateTime.Parse(taskProperties[6]);

					Task task = new Task(id, title, description, isFinished, hasDeadline, deadline, creationDate);
					loadedTasks.Add(task);
				}
			}
			return loadedTasks;
		}

		public string GetCurrentDirectory()
		{
			const string DatabaseName = "task-database.csv";
			const string PointOfSplit = "bin";

			string fullCurrentProjectDirectory = Environment.CurrentDirectory;
			string[] splitCurrentProjectDirectory = fullCurrentProjectDirectory.Split(PointOfSplit);
			string projectCurrentDirectory = splitCurrentProjectDirectory[0];
			return projectCurrentDirectory + DatabaseName;
        }
	}
}
