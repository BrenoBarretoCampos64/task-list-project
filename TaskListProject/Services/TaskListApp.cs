using TaskListProject.Entities;
using TaskListProject.Entities.TaskRelated;
using TaskListProject.Exceptions;
using TaskListProject.UI;

namespace TaskListProject.Services
{
	internal class TaskListApp
	{
		private int _option;
		private TaskList _taskList = new TaskList();
		private OptionReader _optionReader = new OptionReader();
		private SaveManager _saveManager = new SaveManager();

		public void Run()
		{
			FindSaveFile();
			Start();
			End();
		}

		public void FindSaveFile()
		{
			try
			{
				_taskList.LoadTaskList(_saveManager.LoadData());
			}
			catch (FileNotFoundException)
			{
				UIPrinter.NoTaskDatabaseFoundWindow();
				_taskList.GenerateSampleTasks();
			}
		}

		public void Start()
		{
			do
			{
				UIPrinter.PrintMenu(_taskList);
				try
				{
					_option = int.Parse(Console.ReadLine());
					_optionReader.ReadOption(_option, _taskList);
				}
				catch (InvalidOptionException ex)
				{
					Console.WriteLine();
					Console.WriteLine(ex.Message);
					Console.ReadKey();
					_option = 0;
				}
				catch (Exception)
				{
					_option = 0;
				}
			}
			while (_option != 6);
		}

		public void End()
		{
			_saveManager.SaveData(_taskList);
		}
	}
}
