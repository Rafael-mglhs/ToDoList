using ToDoList.Models;
using ToDoList.Services;
using ToDoList.Helpers;

namespace ToDoList;



internal class Program
{
    static void Main(string[] args)
    {
        // VARIABELS
        int option;
        List<TaskItem> tasks = new List<TaskItem>();
        string taskTitle;
        string taskDescription;
        int markComplete;
        int removeTask;
        int editTask;
        string editTitle;
        string editDescription;


       

        


            // MENU
            do
            {
                Console.Clear();
                string bar = "==============================";
                Console.WriteLine(bar);
                Console.WriteLine("To Do List\n1 - Add task\n2 - List tasks\n3 - Mark as complete\n4 - Remove task\n5 - Edit task\n6 - Search task\n0 - Exit");
                option = InputValidator.optionVerify("Choose an option: ");

                // OPTIONS
                switch (option)
                {
                    // OPTION 1
                    case 1:
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Add task");
                        taskTitle = InputValidator.stringVerify("type the task title\nType 0 to cancel: ");
                        if (taskTitle != "0")
                        {
                            taskDescription = InputValidator.stringVerify("type the task description: ");
                            
                            TaskService.AddTask(taskTitle, taskDescription, tasks);
                            
                            Console.WriteLine("Task added with success!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            
                            break;
                            
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    // OPTION 2
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        Console.WriteLine("Tasks");
                        TaskService.ListTask(tasks);
                        TaskService.Pause();
                        break;
                    }
                    //OPTION 3
                    case 3:
                    {
                        
                        Console.Clear();
                        Console.WriteLine(bar);
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("You have no registered tasks");
                            TaskService.Pause();
                            break;
                        }
                        Console.WriteLine("Mark as complete");
                        markComplete = InputValidator.intVerify("Type the number of the task you want to mark as complete\nPress 0 to cancel: ");
                        if (markComplete != 0)
                        {

                            TaskService.CompleteTask(markComplete, tasks);
                            Console.ReadKey();

                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    // OPTION 4
                    case 4:
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("You have no registered tasks");
                            TaskService.Pause();
                            break;
                        }
                        Console.WriteLine("Remove task");
                        removeTask = InputValidator.intVerify("Type the number of the task you want to remove \nPress 0 to cancel: ");

                        if (removeTask != 0)
                        {
                            if (removeTask > tasks.Count)
                            {
                                Console.WriteLine("Invalid task number");
                                TaskService.Pause();
                                break;
                             }
                            else
                            {
                                TaskService.RemoveTask(removeTask, tasks);
                                TaskService.Pause();
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    // OPTION 5
                    case 5:
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("You have no registered tasks");
                            TaskService.Pause();
                            break;
                        }
                        Console.WriteLine("Edit task");
                        editTask = InputValidator.intVerify("Type the number of the task you want to edit\nPress 0 to cancel: ");
                        if (editTask != 0)
                        {
                            if (editTask > tasks.Count)
                            {
                                Console.WriteLine("Invalid task number");
                                TaskService.Pause();
                                break;
                            }
                            else
                            {
                                editTitle = InputValidator.stringVerify("type the new title of the task: ");
                                editDescription = InputValidator.stringVerify("Type the new description of the task: ");

                                TaskService.EditTask(editTask, editTitle, editDescription, tasks);

                                TaskService.Pause();

                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    // OPTION 6
                    case 6:
                    {
                        Console.Clear();
                        Console.WriteLine(bar);
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("You have no registered tasks");
                            TaskService.Pause();
                            break;
                        }
                        Console.WriteLine("Search Task");
                        string search = InputValidator.stringVerify("Type the number or name of the task\nPress 0 to cancel: ");
                        if (search != "0")
                        {
                            
                            TaskService.SearchTask(search, tasks);

                            TaskService.Pause();

                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
            } while (option != 0);
        }
    }