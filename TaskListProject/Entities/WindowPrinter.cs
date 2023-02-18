using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TaskListProject.Entities
{
	internal static class WindowPrinter
	{
		public static void PrintMenu(TaskList taskList)
		{
			Console.Clear();
			Console.WriteLine("O===========================================================O");
			Console.WriteLine("|                      | MY TASK LIST |                     |");
			Console.WriteLine("O===========================================================O");
			Console.WriteLine("O- TASKS ---------------------------------------------------O");
			Console.WriteLine("O===========================================================O");
			Console.WriteLine("|                                                           |");

			foreach (Task task in taskList.GetTasks())
			{
				Console.Write("|");

				if (task.IsFinished)
				{
					TextColorChanger.ChangeTextColorToCyan();
				}
				else
				{
					TextColorChanger.ChangeTextColorToRed();
				}

				Console.Write(task + PrintRemainingEmptySpaces(task));
				TextColorChanger.ChangeTextColorToWhite();
				Console.WriteLine(" |");
			}

			Console.WriteLine("|                                                           |");
			Console.WriteLine("O===========================================================O");
			Console.WriteLine("O- MENU ----------------------------------------------------O");
			Console.WriteLine("O===========================================================O");
			Console.WriteLine("|            [1] VIEW TASK         [4] ADD TASK             |");
			Console.WriteLine("|            [2] EDIT TASK         [5] CLEAR TASK           |");
			Console.WriteLine("|            [3] FINISH TASK       [6] EXIT                 |");
			Console.WriteLine("O===========================================================O");
			Console.WriteLine();
			Console.WriteLine("[ ENTER MENU OPTION ]");
			Console.Write("--> ");
		}

		public static string PrintRemainingEmptySpaces(Task task)
		{
			if (task.Title == null)
			{
				task.Title = "No title";
			}

			int remaningEmptySpaces = Task.TitleMaximumLength - task.Title.Length;
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
			Console.WriteLine("[ ENTER TASK NUMBER TO VIEW ]");
			Console.Write("--> ");

			try
			{
				int taskNumber = int.Parse(Console.ReadLine());
				Task task = taskList.ValidateAndGetTask(taskNumber);
				PrintViewTaskWindow(task);
			}
			catch (Exception)
			{
				PrintInvalidInput();
			}
		}

		public static void PrintViewTaskWindow(Task task)
		{
			Console.Clear();
			Console.WriteLine("O========================| VIEW TASK |======================O");
			Console.WriteLine();
			Console.WriteLine(task.Title);
			Console.WriteLine();
			Console.WriteLine(task.Description);
			Console.WriteLine();
			Console.WriteLine("DATE OF CREATION: " + task.CreationDate);
			Console.WriteLine();
			
			if (task.IsFinished)
			{
				Console.Write("THIS TASK IS ");
				TextColorChanger.ChangeTextColorToCyan();
				Console.WriteLine("FINISHED");
			}
			else
			{
				Console.Write("THIS TASK IS ");
				TextColorChanger.ChangeTextColorToRed();
				Console.WriteLine("UNFINISHED");
			}

			TextColorChanger.ChangeTextColorToWhite();
			Console.WriteLine();
			Console.WriteLine("O===========================================================O");
			Console.ReadKey();
		}

		public static void PrintAskTaskNumberToEditWindow(TaskList taskList)
		{
			Console.WriteLine();
			Console.WriteLine("[ ENTER TASK NUMBER TO EDIT ]");
			Console.Write("--> ");

			try
			{
				int taskNumber = int.Parse(Console.ReadLine());
				Task task = taskList.ValidateAndGetTask(taskNumber);
				PrintEditTaskWindow(task);
			}
			catch (Exception)
			{
				PrintInvalidInput();
			}
		}

		public static void PrintEditTaskWindow(Task task)
		{
			string? newTitle = "";
			string? newDescription = "";

			while (true)
			{
				Console.Clear();
				Console.WriteLine("O========================| EDIT TASK |======================O");
				Console.WriteLine();
				Console.WriteLine("[ TASK TO BE EDITED ]");
				Console.WriteLine("--> " + task.Title);
				Console.WriteLine();
				Console.WriteLine("[ CHANGE TITLE? (y/n) ]");
				Console.Write("--> ");

				try
				{
					char answerToChangeTitle = char.Parse(Console.ReadLine());

					if (answerToChangeTitle == 'y')
					{
						Console.WriteLine();
						Console.WriteLine("[ ENTER NEW TITLE ]");
						Console.Write("--> ");
						newTitle = Console.ReadLine();
						Console.WriteLine();
					}
					else if (answerToChangeTitle == 'n')
					{
						Console.WriteLine();
					}
					else
					{
						PrintInvalidInput();
						continue;
					}

					Console.WriteLine("[ CHANGE DESCRIPTION? (y/n) ]");
					Console.Write("--> ");
					char answerToChangeDescription = char.Parse(Console.ReadLine());

					if (answerToChangeDescription == 'y')
					{
						Console.WriteLine();
						Console.WriteLine("[ ENTER NEW DESCRIPTION ]");
						Console.Write("--> ");
						newDescription = Console.ReadLine();
						Console.WriteLine();
					}
					else if (answerToChangeDescription == 'n')
					{
						Console.WriteLine();
					}
					else
					{
						PrintInvalidInput();
						continue;
					}

					Console.WriteLine("[ APPLY CHANGES? (y/n) ]");
					Console.Write("--> ");
					char answerToApplyChanges = char.Parse(Console.ReadLine());

					if (answerToApplyChanges == 'y')
					{
						if (answerToChangeTitle == 'y')
						{
							if (newTitle != null && newTitle != "")
							{
								task.SetTitle(newTitle);
							}
							else
							{
								task.SetTitle("No title");
							}
						}

						if (answerToChangeDescription == 'y')
						{
							if (newDescription != null && newDescription != "")
							{
								task.SetDescription(newDescription);
							}
							else
							{
								task.SetDescription("No description");
							}
						}

						Console.WriteLine();
						Console.WriteLine("[ TASK CHANGES APPLIED ]");
						Console.ReadKey();
						Console.Clear();
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
				catch (Exception)
				{
					PrintInvalidInput();
					continue;
				}
			}
		}

		public static void PrintAskTaskNumberToFinishWindow(TaskList taskList)
		{
			Console.WriteLine();
			Console.WriteLine("[ ENTER TASK NUMBER ]");
			Console.Write("--> ");
			
			try
			{
				int taskNumber = int.Parse(Console.ReadLine());
				taskList.FinishTaskByNumber(taskNumber);
				Console.WriteLine();
				Console.WriteLine("[ FINISHED TASK " + taskNumber + " ]");
				Console.ReadKey();
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
				Console.Clear();
				Console.WriteLine("O========================| ADD TASK |=======================O");
				Console.WriteLine();
				Console.WriteLine("[ ENTER TASK TITLE ]");
				Console.Write("--> ");
				string? title = Console.ReadLine();
				Console.WriteLine();

				Console.WriteLine("[ ENTER TASK DESCRIPTION ]");
				Console.Write("--> ");
				string? description = Console.ReadLine();
				Console.WriteLine();

				Console.WriteLine("[ CONFIRM NEW TASK? (y/n) ]");
				Console.Write("--> ");
				char answerToConfirmNewTask = char.Parse(Console.ReadLine());

				if (answerToConfirmNewTask == 'y')
				{
					taskList.AddTask(title, description);
					Console.WriteLine();
					Console.WriteLine("[ TASK ADDED ]");
					Console.ReadKey();
					Console.Clear();
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
		}

		public static void PrintAskTaskNumberToClearWindow(TaskList taskList)
		{
			Console.WriteLine();
			Console.WriteLine("[ ENTER TASK NUMBER TO CLEAR ]");
			Console.Write("--> ");

			try
			{
				int taskNumber = int.Parse(Console.ReadLine());
				taskList.ClearTask(taskNumber);
				Console.WriteLine();
				Console.WriteLine("[ TASK " + taskNumber + " CLEARED ]");
				Console.ReadKey();
				Console.Clear();
			}
			catch (Exception)
			{
				PrintInvalidInput();
			}
		}

		public static void PrintExitWindow()
		{
			Console.WriteLine();
			Console.WriteLine("[ APPLICATION CLOSED ]");
		}

		public static void PrintInvalidInput()
		{
			Console.WriteLine();
			Console.WriteLine("[ INVALID INPUT ]");
			Console.ReadKey();
		}
	}
}
