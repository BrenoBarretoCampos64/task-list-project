// TaskListProject v1.03
// Task list application for C# practice purposes
// Add, View, Edit, Finish and Clear daily tasks

using TaskListProject.Entities.CustomExceptions;
using TaskListProject.Entities.TaskRelated;
using TaskListProject.Entities.Utility;

TaskList taskList = new TaskList();
OptionReader optionReader = new OptionReader();

taskList.AddTask("Task 1", "Sample description for task 1", true, DateTime.Now.AddDays(1));
taskList.AddTask("Task 2", "Sample description for task 2", true, DateTime.Now.AddDays(2));
taskList.AddTask("Task 3", "Sample description for task 3", true, DateTime.Now.AddDays(7));
taskList.AddTask("Task 4", "Sample description for task 4", true, DateTime.Now.AddMonths(1));
taskList.AddTask("Task 5", "Sample description for task 5", true, DateTime.Now.AddYears(1));

int option;

do
{
	WindowPrinter.PrintMenu(taskList);
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