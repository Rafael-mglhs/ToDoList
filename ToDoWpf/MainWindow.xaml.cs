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

        _tasks = JsonService.LoadTasks();
        _taskService = new TaskService();
        
        LoadTasks();
        
        
    }
    //=========
    //Add task
    //=========
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
            
            Console.WriteLine(JsonService.pathJson);
            Console.Write(_tasks.Count);
            JsonService.SaveTasks(_tasks);
        }
        LoadTasks();
        
    } 
    //==============
    //Scroll viewer
    //==============
    private void LoadTasks()
    {
        TasksPanel.Children.Clear();

        for (int i = 0; i < _tasks.Count; i++)
        {
            TaskItem task = _tasks[i];
            
            //task borders
            Border taskBorder = new Border
            {
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 0, 0, 5)
            };

            Grid taskGrid = new Grid();

            taskGrid.ColumnDefinitions.Add(
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            );
            taskGrid.ColumnDefinitions.Add(
                new ColumnDefinition {Width = GridLength.Auto}
            );
            
            //task info
            StackPanel taskInfo = new StackPanel();

            TextBlock title = new TextBlock
            {
                Text = $"{i + 1}. {task.Title}",
                FontSize = 18
            };

            TextBlock description = new TextBlock
            {
                Text = task.Description,
                FontSize = 14,
                Margin = new Thickness(0, 5, 0, 0),
                TextWrapping = TextWrapping.Wrap
            };

            taskInfo.Children.Add(title);
            taskInfo.Children.Add(description);
            
            Grid.SetColumn(taskInfo,0);
            
            //buttons
            StackPanel buttons = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center
            };

            Button removeButton = new Button
            {
                Content = "Remove",
                Margin = new Thickness(5, 0, 5, 0),
                Tag = i,
            };

            removeButton.Click += RemoveButton_Click;
            

            Button editButton = new Button
            {
                Content = "Edit",
                Tag = i
            };

            buttons.Children.Add(removeButton);
            buttons.Children.Add(editButton);
            
            Grid.SetColumn(buttons, 1);

            taskGrid.Children.Add(taskInfo);
            taskGrid.Children.Add(buttons);
            
            taskBorder.Child = taskGrid;

            TasksPanel.Children.Add(taskBorder);

        }
        
    }
    //=======
    // Remove
    //=======
    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button)
        {
            Button button = (Button)sender;

            if (button.Tag is int index)
            {
                TaskService.RemoveTask(index + 1, _tasks);
                JsonService.SaveTasks(_tasks);
                LoadTasks();
            }
        }
        
        
    }
    
    
    private void Searchbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchtext = SearchBox.Text;
        
    }

    
}