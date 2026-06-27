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
        
        // FUCNTIONS
        
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
            string status;
            
            foreach (Task task in tasks)
            {

                if (task.Complete)
                    status = "Done";
                else
                    status = "Pending...";
                
                Console.WriteLine($"Task {tasks.IndexOf(task)+1}: {task.Title}\n{task.Description}\n{status}\n==============\n");
                

            }
            return;
        }
        
        //Mark as complete function

        void CompleteTask(int markComplete, List <Task> tasks)
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
        
        
        
        
        // MENU
        do
        {
        Console.Clear();
        string bar = "==============================";
        Console.WriteLine(bar);
        Console.WriteLine("To Do List\n1 - Add task\n2 - List tasks\n3 - Mark as complete\n4 - Remove task\n5 - Save\n6 - Load\n0 - Exit");
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
                Console.Write("Type the task title: ");
                taskTitle = Console.ReadLine();
                Console.Write("\nType the task description: ");
                taskDescription = Console.ReadLine();
                
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
                Console.WriteLine("Type the number of the task you want to mark as complete: ");
                markComplete = int.Parse(Console.ReadLine());
                
                CompleteTask(markComplete, tasks);
                Console.ReadKey();
                
                break;
            }
        }
        } while (option != "0");
    }
}