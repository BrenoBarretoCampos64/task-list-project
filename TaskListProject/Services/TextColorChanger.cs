namespace TaskListProject.Services
{
	internal class TextColorChanger
	{
		public static void ChangeTextColorToWhite()
		{
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void ChangeTextColorToCyan()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
		}

		public static void ChangeTextColorToYellow()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}
	}
}
