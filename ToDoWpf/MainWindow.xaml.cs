using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.Helpers;

namespace ToDoWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private List<TaskItem> _tasks;
    
    private readonly TaskService _taskService;
    public MainWindow()
    {
        InitializeComponent();

        _tasks = new List<TaskItem>();
        _taskService = new TaskService();
    }
    
    private void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddTaskWindow window = new AddTaskWindow();

        window.Owner = this;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

        bool? result = window.ShowDialog();

        if (result == true)
        {
            TaskItem task = window.CreatedTask!;
            
            _taskService.AddTask(
                task.Title,
                task.Description,
                _tasks
                );
            
            Console.Write(JsonService.pathJson);
            JsonService.SaveTasks(_tasks);
        }
        
    }
    
    private void Searchbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchtext = SearchBox.Text;
        
    }

    
}