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
            case "2":
            {
                Console.Clear();
                Console.WriteLine(bar);
                Console.WriteLine("Tasks");
                ;
                break;
            }
        }
        } while (option != "0");
    }
}