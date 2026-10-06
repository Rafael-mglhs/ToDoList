using System.Windows;
using ToDoList.Models;
using ToDoList.Services;


namespace ToDoWpf;

public partial class AddTaskWindow : Window
{
    public AddTaskWindow()
    {
        InitializeComponent();
    }
    
    public TaskItem? CreatedTask { get; private set; }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        CreatedTask = new TaskItem
        {
            Title = TitleTextBox.Text,
            Description = DescriptionTextBox.Text,
            Complete = false
        };

        DialogResult = true;

    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

}