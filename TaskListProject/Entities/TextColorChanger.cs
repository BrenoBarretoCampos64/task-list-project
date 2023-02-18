namespace TaskListProject.Entities
{
	internal static class TextColorChanger
	{
		public static void ChangeTextColorToWhite()
		{
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void ChangeTextColorToCyan()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
		}

		public static void ChangeTextColorToRed()
		{
			Console.ForegroundColor = ConsoleColor.Red;
		}
	}
}
