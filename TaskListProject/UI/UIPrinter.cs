using System.Text;
using System.Threading.Tasks;
using TaskListProject.Entities.TaskRelated;
using TaskListProject.Exceptions;
using TaskListProject.Services;
using Task = TaskListProject.Entities.TaskRelated.Task;

namespace TaskListProject.UI    
{
    internal class UIPrinter
    {
        public static void PrintMenu(TaskList taskList)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   O===========================================================O");
            Console.WriteLine("   | TASKS |                                                   |");
            Console.WriteLine("   O===========================================================O");
            Console.WriteLine("   |                                                           |");

            foreach (Task task in taskList.GetTasks())
            {
                Console.Write("   |");
                PrintAlternateTextColorsIfFinishedTask(task);
                Console.Write(task + PrintRemainingEmptySpaces(task));
                TextColorChanger.ChangeTextColorToWhite();
                Console.WriteLine(" |");
            }

            Console.WriteLine("   |                                                           |");
            Console.WriteLine("   O===========================================================O");
            Console.WriteLine("   | MENU |                                                    |");
            Console.WriteLine("   O===========================================================O");
            Console.WriteLine("   |            [1] VIEW TASK         [4] ADD TASK             |");
            Console.WriteLine("   |            [2] EDIT TASK         [5] CLEAR TASK           |");
            Console.WriteLine("   |            [3] FINISH TASK       [6] EXIT                 |");
            Console.WriteLine("   O===========================================================O");
            Console.WriteLine("                               |   |                            ");
            Console.WriteLine("                               |   |                            ");
            Console.WriteLine("                               |   |                            ");
            Console.WriteLine("                             ---------                          ");
            Console.WriteLine("   [ ENTER MENU OPTION ]");
            Console.Write("   > ");
        }

        public static void PrintAlternateTextColorsIfFinishedTask(Task task)
        {
            if (task.IsFinished)
            {
                TextColorChanger.ChangeTextColorToCyan();
            }
            else
            {
                TextColorChanger.ChangeTextColorToYellow();
            }
        }

        public static string PrintRemainingEmptySpaces(Task task)
        {
            if (task == null)
            {
                return "                                                      ";
            }

            int taskNumberLength = task.Number.ToString().Length;
            int remaningEmptySpaces = (Title.TitleMaximumLength - taskNumberLength) - task.Title.Content.Length;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < remaningEmptySpaces; i++)
            {
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }

        public static void PrintAskTaskNumberToViewWindow(TaskList taskList)
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK NUMBER TO VIEW ]");
            Console.Write("   > ");

            try
            {
                int taskNumber = int.Parse(Console.ReadLine());
                Task task = taskList.SearchTaskByNumber(taskNumber);
                PrintViewTaskWindow(task);
            }
            catch (TaskException ex)
            {
                PrintExceptionMessage(ex);
            }
            catch (Exception)
            {
                PrintInvalidInput();
            }
        }

        public static void PrintViewTaskWindow(Task task)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   { VIEWING TASK " + task.Number + " }");
            Console.WriteLine();

            ChangeColorsBasedIfFinished(task.IsFinished);

            Console.WriteLine("   " + task.Title);
            Console.WriteLine();

            Console.WriteLine("   " + task.Description);
            Console.WriteLine();

            Console.WriteLine("   [ DATE OF CREATION: " + task.CreationDate + " ]");
            Console.WriteLine();

            PrintFinishedOrUnfinished(task.IsFinished);
            Console.WriteLine();

            PrintIfHasDeadline(task, task.IsFinished, task.HasDeadline);
            Console.ReadKey();

            TextColorChanger.ChangeTextColorToWhite();
		}

		public static void ChangeColorsBasedIfFinished(bool IsFinished)
        {
            if (IsFinished)
            {
                TextColorChanger.ChangeTextColorToCyan();
            }
            else
            {
                TextColorChanger.ChangeTextColorToYellow();
            }
        }


		public static void PrintFinishedOrUnfinished(bool isTaskFinished)
        {
            if (isTaskFinished)
            {
                Console.Write("   [ THIS TASK IS ");
                Console.WriteLine("FINISHED ]");
            }
            else
            {
                Console.Write("   [ THIS TASK IS ");
                Console.WriteLine("UNFINISHED ]");
            }
        }

        public static void PrintIfHasDeadline(Task task, bool isFinished, bool hasDeadline)
        {
            if (hasDeadline)
            {
                if (isFinished)
                {
                    Console.WriteLine(task.GetRemainingDaysToDeadline());
                }
                else
                {
                    Console.WriteLine(task.GetRemainingDaysToDeadline());
                }
                Console.WriteLine();
            }
        }

        public static void PrintAskTaskNumberToEditWindow(TaskList taskList)
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK NUMBER TO EDIT ]");
            Console.Write("   > ");

            try
            {
                int taskNumber = int.Parse(Console.ReadLine());
                Task task = taskList.SearchTaskByNumber(taskNumber);
                PrintEditTaskWindow(task);
            }
            catch (TaskException ex)
            {
                PrintExceptionMessage(ex);
            }
            catch (Exception)
            {
                PrintInvalidInput();
            }
        }

        public static void PrintEditTaskWindow(Task task)
        {
            Title newTitle = new Title();
            Description newDescription = new Description();
            string? oldTitleContent = task.Title.Content;
            string? oldDescriptionContent = task.Description.Content;

            while (true)
            {
                PrintEditHeaderWindow(task);

                try
                {
                    char answerToChangeTitle = PrintAskToChangeTitleWindow();

                    if (answerToChangeTitle == 'y')
                    {
                        newTitle = PrintGetTitleWindow();
                    }
                    else if (answerToChangeTitle == 'n')
                    {
                        // Nothing happens
                    }
                    else
                    {
                        PrintInvalidInput();
                        continue;
                    }

                    char answerToChangeDescription = PrintAskToChangeDescriptionWindow();

                    if (answerToChangeDescription == 'y')
                    {
                        newDescription = PrintGetDescriptionWindow();
                    }
                    else if (answerToChangeDescription == 'n')
                    {
                        // Nothing happens
                    }
                    else
                    {
                        PrintInvalidInput();
                        continue;
                    }

                    char answerToApplyChanges = PrintAskToApplyChangesWindow();

                    if (answerToApplyChanges == 'y')
                    {
                        bool theAnswerAreNo = AreTheAnswersNo(answerToChangeTitle, answerToChangeDescription);

                        bool titleAndDescriptionChanged = TitleAndDescriptionNotChanged(
                            newTitle, newDescription, oldTitleContent, oldDescriptionContent);

                        task.ChangeTaskTitleBasedOnChoices(answerToChangeTitle, newTitle);
                        task.ChangeTaskDescriptionBasedOnChoices(answerToChangeDescription, newDescription);
                        PrintIfWereThereChanges(theAnswerAreNo, titleAndDescriptionChanged);
                        break;
                    }
                    else if (answerToApplyChanges == 'n')
                    {
                        continue;
                    }
                    else
                    {
                        PrintInvalidInput();
                    }
                }
                catch (DescriptionLengthException ex)
                {
                    PrintExceptionMessage(ex);
                    continue;
                }
                catch (TitleLengthException ex)
                {
                    PrintExceptionMessage(ex);
                    continue;
                }
                catch (Exception)
                {
                    PrintInvalidInput();
                    continue;
                }
            }
        }

        public static void PrintEditHeaderWindow(Task task)
        {
            Console.Clear();
			Console.WriteLine();
			Console.WriteLine("   { EDITING TASK " + task.Number + " }");
            Console.WriteLine();
            Console.WriteLine("   [ TASK TO BE EDITED ]");
            Console.WriteLine("   > " + task.Title.Content);
        }

        public static char PrintAskToChangeTitleWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ CHANGE TITLE? (y/n) ]");
            Console.Write("   > ");
            char answerToChangeTitle = char.Parse(Console.ReadLine());
            return answerToChangeTitle;
        }

        public static char PrintAskToChangeDescriptionWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ CHANGE DESCRIPTION? (y/n) ]");
            Console.Write("   > ");
            char answerToChangeDescription = char.Parse(Console.ReadLine());
            return answerToChangeDescription;
        }

        public static char PrintAskToApplyChangesWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ APPLY CHANGES? (y/n) ]");
            Console.Write("   > ");
            char answerToApplyChanges = char.Parse(Console.ReadLine());
            return answerToApplyChanges;
        }

        public static bool AreTheAnswersNo(char answerToChangeTitle, char answerToChangeDescription)
        {
            if (answerToChangeTitle == 'n' && answerToChangeDescription == 'n')
            {
                return true;
            }
            return false;
        }

        public static bool TitleAndDescriptionNotChanged(
            Title newTitle, Description newDescription, string oldTitleContent, string oldDescriptionContent)
        {
            if (newTitle.Content == oldTitleContent)
            {
                if (newDescription.Content == oldDescriptionContent)
                {
                    return true;
                }
            }
            return false;
        }

        public static void PrintIfWereThereChanges(bool theAnswerAreNo, bool titleAndDescriptionNotChanged)
        {
            if (theAnswerAreNo)
            {
                PrintNoChangesWereMadeWindow();
                return;
            }

            if (titleAndDescriptionNotChanged)
            {
                PrintNoChangesWereMadeWindow();
                return;
            }
            PrintTaskChangesAppliedWindow();
        }

        public static void PrintNoChangesWereMadeWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ NO CHANGES WERE MADE ]");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintTaskChangesAppliedWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ TASK CHANGES APPLIED ]");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintAskTaskNumberToFinishWindow(TaskList taskList)
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK NUMBER ]");
            Console.Write("   > ");

            try
            {
                int taskNumber = int.Parse(Console.ReadLine());
                taskList.FinishTaskByNumber(taskNumber);
                Console.WriteLine();
                Console.WriteLine("   [ FINISHED TASK " + taskNumber + " ]");
                Console.ReadKey();
            }
            catch (TaskException ex)
            {
                PrintExceptionMessage(ex);
            }
            catch (Exception)
            {
                PrintInvalidInput();
            }
        }

        public static void PrintAddTaskWindow(TaskList taskList)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
					Console.WriteLine();
					Console.WriteLine("   { ADD TASK }");
                    Title title = PrintGetTitleWindow();
                    Description description = PrintGetDescriptionWindow();
                    bool hasDeadline = false;
                    DateTime deadline;

                    Console.WriteLine();
                    Console.WriteLine("   [ IS THERE A DEADLINE? (y/n) ]");
                    Console.Write("   > ");
                    char answerToTaskUrgency = char.Parse(Console.ReadLine());

                    if (answerToTaskUrgency == 'y')
                    {
                        deadline = PrintGetDeadlineWindow();
                        hasDeadline = true;
                    }
                    else if (answerToTaskUrgency == 'n')
                    {
                        deadline = DateTime.MaxValue;
                    }
                    else
                    {
                        PrintInvalidInput();
                        continue;
                    }

                    Console.WriteLine();
                    Console.WriteLine("   [ CONFIRM NEW TASK? (y/n) ]");
                    Console.Write("   > ");
                    char answerToConfirmNewTask = char.Parse(Console.ReadLine());

                    if (answerToConfirmNewTask == 'y')
                    {
                        ConfirmAddNewTask(taskList, title, description, hasDeadline, deadline);
                        break;

                    }
                    else if (answerToConfirmNewTask == 'n')
                    {
                        continue;
                    }
                    else
                    {
                        PrintInvalidInput();
                    }
                }
                catch (TitleLengthException ex)
                {
                    PrintExceptionMessage(ex);
                }
                catch (DescriptionLengthException ex)
                {
                    PrintExceptionMessage(ex);
                }
                catch (DeadlineException ex)
                {
                    PrintExceptionMessage(ex);
                }
                catch (Exception)
                {
                    PrintInvalidInput();
                }
            }
        }

        public static Title PrintGetTitleWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK TITLE ]");
            Console.Write("   > ");
            string titleContent = Console.ReadLine();
            return new Title(titleContent);
        }

        public static Description PrintGetDescriptionWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK DESCRIPTION ]");
            Console.Write("   > ");
            string descriptionContent = Console.ReadLine();
            return new Description(descriptionContent);
        }

        public static DateTime PrintGetDeadlineWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK DEADLINE DATE (dd/mm/yyyy) ]");
            Console.Write("   > ");
            DateTime deadline = DateTime.Parse(Console.ReadLine());
            return deadline;
        }

        public static void ConfirmAddNewTask(
            TaskList taskList, Title title, Description description, bool hasDeadline, DateTime deadline)
        {
            taskList.AddTask(title, description, hasDeadline, deadline);
            Console.WriteLine();
            Console.WriteLine("   [ TASK ADDED ]");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintExceptionMessage(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }

        public static void PrintAskTaskNumberToClearWindow(TaskList taskList)
        {
            Console.WriteLine();
            Console.WriteLine("   [ ENTER TASK NUMBER TO CLEAR ]");
            Console.Write("   > ");

            try
            {
                int taskNumber = int.Parse(Console.ReadLine());
                taskList.ClearTask(taskNumber);
                Console.WriteLine();
                Console.WriteLine("   [ TASK " + taskNumber + " CLEARED ]");
                Console.ReadKey();
                Console.Clear();
            }
            catch (TaskException ex)
            {
                PrintExceptionMessage(ex);
            }
            catch (Exception)
            {
                PrintInvalidInput();
            }
        }

		public static void NoTaskDatabaseFoundWindow()
        {
			Console.WriteLine();
			Console.WriteLine("   [ NO TASK DATABASE FOUND ]");
            Console.WriteLine("   [ GENERATING SAMPLE TASKS... ]");
            Console.ReadLine();
        }

		public static void PrintInvalidDate()
        {
            Console.WriteLine();
            Console.WriteLine("   [ INVALID DATE ]");
            Console.ReadLine();
        }

        public static void PrintExitWindow()
        {
            Console.WriteLine();
            Console.WriteLine("   [ APPLICATION CLOSED ]");
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("   [ INVALID INPUT ]");
            Console.ReadKey();
        }
    }
}
