using TaskListProject.Entities;

int option;
TaskList taskList = new TaskList();
OptionReader optionReader = new OptionReader();

taskList.AddTask("Task 1", "Sample description for task 1");
taskList.AddTask("Task 2", "Sample description for task 2");
taskList.AddTask("Task 3", "Sample description for task 3");
taskList.AddTask("Task 4", "Sample description for task 4");
taskList.AddTask("Task 5", "Sample description for task 5");

do
{
	WindowPrinter.PrintMenu(taskList);

	try
	{
		option = int.Parse(Console.ReadLine());
	}
	catch (Exception)
	{
		Console.WriteLine();
		Console.WriteLine("[ INVALID OPTION ]");
		Console.ReadKey();
		option = 0;
	}

	optionReader.ReadOption(option, taskList);
}  
while (option != 6);