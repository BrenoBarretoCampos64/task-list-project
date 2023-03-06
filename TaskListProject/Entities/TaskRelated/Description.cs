namespace TaskListProject.Entities.TaskRelated
{
	internal class Description
	{
		public string? Content { get; set; }
		public static int DescriptionMaximumLength { get; set; } = 116;

		public Description()
		{
		}

		public Description(string content)
		{	
			int lineLimit = 54;

			if (content.Length > lineLimit)
			{
				int a = content.IndexOf(' ', lineLimit+1);
                content = content.Insert(a, "\n  ");
			}

			Content = content;
		}

		public override string? ToString()
		{
			return Content;
		}
	}
}
