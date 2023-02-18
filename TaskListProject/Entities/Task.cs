namespace TaskListProject.Entities
{
	internal class Task	
	{
		public int Number { get; set; }	
		public static int TitleMaximumLength { get; set; } = 54;
		public static int DescriptionMaximumLength { get; set; } = 176;
		public bool IsFinished { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime CreationDate { get; set; }

		public Task()
		{
		}

		public Task(int number, string? title, string? description)
		{
			Number = number;
			IsFinished = false;
			Title = title;
			Description = description;
			CreationDate = DateTime.Now;	
		}

		public void SetTitle(string newTitle)
		{
			if (newTitle.Length > TitleMaximumLength)
			{
				throw new Exception();
			}

			Title = newTitle;
		}

		public void SetDescription(string newDescription)
		{
			if (newDescription.Length > DescriptionMaximumLength)
			{
				throw new Exception();	
			}

			Description = newDescription;
		}

		public void FinishTask()
		{
			IsFinished = true;
		}

		public override string? ToString()
		{
			return "(" + Number + ")" + " " + Title;
		}
	}
}
