namespace TaskListProject.Entities.TaskRelated
{
	internal class Description
	{
		public string? Content { get; set; }
		public static int DescriptionMaximumLength { get; set; } = 162;

		public Description()
		{
		}

		public Description(string? content)
		{
			Content = content;
		}

		public override string? ToString()
		{
			return Content;
		}
	}
}
	