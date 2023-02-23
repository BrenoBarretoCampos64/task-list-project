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
                    WindowPrinter.PrintMenu(taskList);
                    break;
                case 1:
                    WindowPrinter.PrintAskTaskNumberToViewWindow(taskList);
                    break;
                case 2:
                    WindowPrinter.PrintAskTaskNumberToEditWindow(taskList);
                    break;
                case 3:
                    WindowPrinter.PrintAskTaskNumberToFinishWindow(taskList);
                    break;
                case 4:
                    WindowPrinter.PrintAddTaskWindow(taskList);
                    break;
                case 5:
                    WindowPrinter.PrintAskTaskNumberToClearWindow(taskList);
                    break;
                case 6:
                    WindowPrinter.PrintExitWindow();
                    break;
                default:
                    throw new InvalidOptionException("   [ INVALID OPTION ]");
            }
        }
    }
}
