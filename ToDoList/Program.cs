namespace ToDoList;

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
        string bar = "==============================";
        Console.WriteLine(bar);
        Console.WriteLine("To Do List\n1 - Add task\n2 - List tasks\n3 - Mark as complete\n4 - Remove task\n5 - Save\n6 - Load\n0 - Exit");
        Console.Write("Choose an option: ");
        int option = int.Parse(Console.ReadLine());
        

    }
}