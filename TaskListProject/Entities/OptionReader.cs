using TaskListProject.Exceptions;
using TaskListProject.Entities.TaskRelated;
using TaskListProject.UI;

namespace TaskListProject.Entities
{
	internal class OptionReader
	{
		public void ReadOption(int option, TaskList taskList)
		{
			switch (option)
			{
				case 0:
					UIPrinter.PrintMenu(taskList);
					break;
				case 1:
					UIPrinter.PrintAskTaskNumberToViewWindow(taskList);
					break;
				case 2:
					UIPrinter.PrintAskTaskNumberToEditWindow(taskList);
					break;
				case 3:
					UIPrinter.PrintAskTaskNumberToFinishWindow(taskList);
					break;
				case 4:
					UIPrinter.PrintAddTaskWindow(taskList);
					break;
				case 5:
					UIPrinter.PrintAskTaskNumberToClearWindow(taskList);
					break;
				case 6:
					UIPrinter.PrintExitWindow();
					break;
				default:
					throw new InvalidOptionException("   [ INVALID OPTION ]");
			}
		}
	}
}
