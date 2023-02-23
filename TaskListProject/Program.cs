// TaskListProject v1.06
// Task list application for C# practice purposes
// Add, View, Edit, Finish and Clear daily tasks

using TaskListProject.Entities;
using TaskListProject.Entities.TaskRelated;
using TaskListProject.Exceptions;
using TaskListProject.UI;

TaskList taskList = new TaskList();
OptionReader optionReader = new OptionReader();

taskList.AddTask(new Title("Task 1"), new Description("Sample description for task 1"), true, DateTime.Now.AddDays(1));
taskList.AddTask(new Title("Task 2"), new Description("Sample description for task 2"), true, DateTime.Now.AddDays(2));
taskList.AddTask(new Title("Task 3"), new Description("Sample description for task 3"), true, DateTime.Now.AddDays(7));
taskList.AddTask(new Title("Task 4"), new Description("Sample description for task 4"), true, DateTime.Now.AddMonths(1));
taskList.AddTask(new Title("Task 5"), new Description("Sample description for task 5"), true, DateTime.Now.AddYears(1));

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