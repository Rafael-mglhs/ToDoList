namespace ToDoList;

// CLASS
class Task
{
    public string Title;
    public string Description;
    public bool Complete;

    
}

class Program
{
    static void Main(string[] args)
    {
        // VARIABELS
        string option;
        List<Task> tasks = new List<Task>();
        string taskTitle;
        string taskDescription;
        int markComplete;
        int removeTask;
        int editTask;
        string editTitle;
        string editDescription;


        // FUNCTIONS

        //add function
        void AddTask(string taskTitle, string taskDescription)
        {
            tasks.Add(new Task
            {
                Title = taskTitle,
                Description = taskDescription
            });
            return;
        }

        //list tasks function
        void ListTask(List<Task> tasks)
        {
            Console.Clear();
            

            foreach (Task task in tasks)
            {
                string status = task.Complete ? "Done" : "Pending...";

                Console.WriteLine(
                    $"Task {tasks.IndexOf(task) + 1}: {task.Title}\n{task.Description}\n{status}\n==============\n");


            }

            return;
        }

        //Mark as complete function

        void CompleteTask(int markComplete, List<Task> tasks)
        {
            if (markComplete > tasks.Count)
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

        void RemoveTask(int removeTask, List<Task> tasks)
        {
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
        void EditTask(int editTask, string editTitle, string editDescription, List<Task> tasks)
        {
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
        void SearchTask(string searching, List<Task> tasks)
        {
            int searchNumber;
            string status;

            if (int.TryParse(searching, out searchNumber))
            {
                if ((searchNumber > -1) && (searchNumber <= tasks.Count))
                {
                    Console.WriteLine($"Task: {tasks[searchNumber - 1].Title}\nDescription: {tasks[searchNumber - 1].Description}\nStatus: {tasks[searchNumber - 1].Complete}");
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
                foreach (Task task in tasks)
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

        //Input Validation Functions

            //string verify

            static string stringVerify(string message)
            {
                while (true)
                {

                    Console.WriteLine(message);
                    string input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        return (input);
                    }

                    Console.WriteLine("Don't leave it blank");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            //int verify
            static int intVerify(string message)
            {
                int number;

                while (true)
                {
                    Console.WriteLine(message);

                    if (int.TryParse(Console.ReadLine(), out number))
                    {
                        return number;
                    }

                    Console.WriteLine("Invalid value!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }


            // MENU
            do
            {
                Console.Clear();
                string bar = "==============================";
                Console.WriteLine(bar);
                Console.WriteLine(
                    "To Do List\n1 - Add task\n2 - List tasks\n3 - Mark as complete\n4 - Remove task\n5 - Edit task\n6 - Search task\n0 - Exit");
                Console.Write("Choose an option: ");
                option = (Console.ReadLine());

                // OPTIONS
                switch (option)
                {
                    // OPTION 1
                    case "1":
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Add task");
                        taskTitle = stringVerify("type the task title: ");
                        taskDescription = stringVerify("type the task description: ");

                        AddTask(taskTitle, taskDescription);

                        Console.WriteLine("Task added with success!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        break;
                    }
                    // OPTION 2
                    case "2":
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Tasks");
                        ListTask(tasks);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    //OPTION 3
                    case "3":
                    {

                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Mark as complete");
                        markComplete = intVerify("Type the number of the task you want to mark as complete: ");

                        CompleteTask(markComplete, tasks);
                        Console.ReadKey();

                        break;
                    }
                    // OPTION 4
                    case "4":
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Remove task");
                        removeTask = intVerify("Type the number of the task you want to remove: ");

                        RemoveTask(removeTask, tasks);

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    // OPTION 5
                    case "5":
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Edit task");
                        editTask = intVerify("Type the number of the task you want to edit: ");
                        editTitle = stringVerify("type the new title of the task: ");
                        editDescription = stringVerify("Type the new description of the task: ");

                        EditTask(editTask, editTitle, editDescription, tasks);

                        Console.WriteLine("Type any key to continue...");
                        Console.ReadKey();

                        break;
                    }
                    // OPTION 6
                    case "6":
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Search Task");
                        string search = stringVerify("Type the number or name of the task: ");

                        SearchTask(search, tasks);

                        Console.WriteLine("Type any key to continue...");
                        Console.ReadKey();

                        break;
                    }

                }
            } while (option != "0");
        }
    }