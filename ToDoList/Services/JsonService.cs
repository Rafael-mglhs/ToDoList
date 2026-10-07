using ToDoList.Models;
using System.Text.Json;
using System.IO;

namespace ToDoList.Services;

public class JsonService
{
    //directory
    private static readonly string dataDirectory =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ToDoWpf"
        );
    
    
    public static readonly string pathJson =
        Path.Combine(dataDirectory,"tasks.json");
    
    
    //Save tasks in JSON file
    public static void SaveTasks(List<TaskItem> tasks)
    {
        var optionJson = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tasks, optionJson);
        Directory.CreateDirectory(dataDirectory);
        File.WriteAllText(pathJson, json);
        
        
    }
    
    //Load tasks from JSON file function
    public static List<TaskItem> LoadTasks()
    {
        if (File.Exists(pathJson))
        {
            
            string readJson = File.ReadAllText(pathJson);
            if (!string.IsNullOrWhiteSpace(readJson))
            {
                try
                {
                    List<TaskItem> loadedTasks = JsonSerializer.Deserialize<List<TaskItem>>(readJson);
                    if (loadedTasks == null)
                    {
                        return [];
                    }
                        return (loadedTasks);
                }
                catch(JsonException)
                {
                    return [];
                }
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