using ToDoList.Models;
using System.Text.Json;
using System.IO;

namespace ToDoList.Services;

public class JsonService
{
    private static readonly string pathJson = "Data/tasks.json";
    //Save tasks in JSON file function
    public static void SaveTasks(List<TaskItem> tasks)
    {
        var optionJson = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tasks, optionJson);
        File.WriteAllText(pathJson, json);
        return;
    }
    
    //Load tasks from JSON file function
    public static List<TaskItem> LoadTasks()
    {
        if (File.Exists(pathJson))
        {
            
            string readJson = File.ReadAllText(pathJson);
            if (!string.IsNullOrWhiteSpace(readJson))
            {
                List<TaskItem> loadedTasks = JsonSerializer.Deserialize<List<TaskItem>>(readJson);
                if (loadedTasks == null)
                {
                    return [];
                }
                else
                    return (loadedTasks);
            }
            else
            {
                return [];
            }
            
            
        }
        else
        {
            return [];
        }
        
    }
    
}