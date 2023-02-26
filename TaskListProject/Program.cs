// TaskListProject v1.07
// Task list application for C# practice purposes
// Add, View, Edit, Finish and Clear daily tasks

using TaskListProject.Entities;
using TaskListProject.Entities.TaskRelated;
using TaskListProject.Exceptions;
using TaskListProject.UI;
using TaskListProject.Services;

TaskList taskList = new TaskList();
OptionReader optionReader = new OptionReader();
SaveManager saveManager = new SaveManager();

try
{
	taskList.LoadTaskList(saveManager.LoadData());
}
catch (Exception)
{
	UIPrinter.NoTaskDatabaseFoundWindow();
	taskList.GenerateSampleTasks();
}

int option;

do
{
	UIPrinter.PrintMenu(taskList);
	try
	{
		option = int.Parse(Console.ReadLine());
		optionReader.ReadOption(option, taskList);
	}
	catch (InvalidOptionException ex)
	{
		Console.WriteLine();
		Console.WriteLine(ex.Message);
		Console.ReadKey();
		option = 0;
	}
	catch (Exception)
	{
		option = 0;
	}
}
while (option != 6);

saveManager.SaveData(taskList);