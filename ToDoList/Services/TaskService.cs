namespace ToDoList.Services;
using ToDoList.Models;

public class TaskService
{
     // FUNCTIONS
        
        //Pause
        public static void Pause()
        {
            Console.WriteLine("Type any key to continue...");
            Console.ReadKey();
        }

        //add function
        public static void AddTask(string taskTitle, string taskDescription, List<TaskItem> tasks)
        {
            tasks.Add(new TaskItem
            {
                Title = taskTitle,
                Description = taskDescription
            });
            return;
        }

        //list tasks function
        public static void ListTask(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("You have no registered tasks");
                return;
            }
            
            Console.Clear();
            

            foreach (TaskItem task in tasks)
            {
                string status = task.Complete ? "Done" : "Pending...";

                Console.WriteLine(
                    $"Task {tasks.IndexOf(task) + 1}: {task.Title}\n{task.Description}\n{status}\n==============\n");


            }

            return;
        }

        //Mark as complete function

        public static void CompleteTask(int markComplete, List<TaskItem> tasks)
        {
            if ((markComplete > tasks.Count) || (markComplete < 1))
            {
                Console.WriteLine("Invalid task number!");
                return;
            }
            else
            {
                tasks[(markComplete - 1)].Complete = true;
                if (tasks[(markComplete - 1)].Complete)
                {
                    Console.WriteLine("Marked successful");
                }
                else
                {
                    Console.WriteLine("Error in searching the task");
                }

                return;

            }
        }

        // Remove task funciton

        public static void RemoveTask(int removeTask, List<TaskItem> tasks)
        {
            if ((removeTask > tasks.Count) || (removeTask < 1))
            {
                Console.WriteLine("Invalid task number!");
                return;
            }
            
            
            int parameter = tasks.Count;
            tasks.RemoveAt(removeTask - 1);
            if (tasks.Count < parameter)
            {
                Console.WriteLine("Task Removed with success!");
            }
            else
            {
                Console.Write("Error in removing the task!");
            }

            return;

        }

        //Edit task funciton
        public static void EditTask(int editTask, string editTitle, string editDescription, List<TaskItem> tasks)
        {
            if ((editTask > tasks.Count) || (editTask < 1))
            {
                Console.WriteLine("Invalid task number");
                return;
            }
            
            
            string titleParameter = tasks[editTask - 1].Title;
            string descriptionParameter = tasks[editTask - 1].Description;

            tasks[editTask - 1].Title = editTitle;
            tasks[editTask - 1].Description = editDescription;

            if ((tasks[editTask - 1].Title == titleParameter) &&
                (tasks[editTask - 1].Description == descriptionParameter))
            {
                Console.WriteLine("Task maintained original title and description!");
            }
            else
            {
                Console.WriteLine("Task edited with success!");
            }

            return;
        }

        //Search Task function
        public static void SearchTask(string searching, List<TaskItem> tasks)
        {
            int searchNumber;
            string status;

            if (int.TryParse(searching, out searchNumber))
            {
                if ((searchNumber >= 1) && (searchNumber <= tasks.Count))
                {
                    status = tasks[searchNumber - 1].Complete ? "Done" : "Pending...";
                    Console.WriteLine($"Task: {tasks[searchNumber - 1].Title}\nDescription: {tasks[searchNumber - 1].Description}\nStatus: {status}");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid task number!");
                    return;
                }
            }
            else
            {
                bool found = false;
                foreach (TaskItem task in tasks)
                {
                    status = task.Complete ? "Done" : "Pending...";
                    
                    if (task.Title.Equals(searching, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Task: {task.Title}\nDescription: {task.Description}\nStatus: {status}");
                        found = true;
                        return;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Invalid task name");
                    return;
                }
            }

        }
}