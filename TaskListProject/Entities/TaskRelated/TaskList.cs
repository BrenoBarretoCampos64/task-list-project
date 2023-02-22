using TaskListProject.Entities.CustomExceptions;

namespace TaskListProject.Entities.TaskRelated
{
    internal class TaskList
    {
        public int NumberOfTasks { get; set; }

        private List<Task> Tasks = new List<Task>();

        public TaskList()
        {
            NumberOfTasks = 0;
        }

        public List<Task> GetTasks()
        {
            return Tasks;
        }

        public void AddTask(Title title, Description description, bool hasDeadline, DateTime deadline)
        {
            int Id = NumberOfTasks + 1;
            Tasks.Add(new Task(Id, title, description, hasDeadline, deadline));
            ReorganizeTaskNumbers();
            NumberOfTasks++;
        }

        public void ClearTask(int number)
        {
            Task task = SearchTaskByNumber(number);
            Tasks.Remove(task);
            ReorganizeTaskNumbers();
            NumberOfTasks--;
        }

        public void ReorganizeTaskNumbers()
        {
            NumberOfTasks = 0;

            foreach (Task task in Tasks)
            {
                NumberOfTasks++;
                task.Number = NumberOfTasks;
            }
        }

        public void FinishTaskByNumber(int number)
        {
            Task task = SearchTaskByNumber(number);
            task.FinishTask();
        }

        public Task SearchTaskByNumber(int number)
        {
            foreach (Task task in Tasks)
            {
                if (number == task.Number)
                {
                    return task;
                }
            }
            throw new TaskException("[ TASK NUMBER NOT FOUND IN TASK LIST ]");
        }
    }
}
