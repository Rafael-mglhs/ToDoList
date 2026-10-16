using System.Windows;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoWpf;

public partial class Edit : Window
{
    public Edit(TaskItem task)
    {
        InitializeComponent();

        TitleTextBox.Text = task.Title;
        DescriptionTextBox.Text = task.Description;
    }

    public TaskItem? EditedTask { get; private set; }

    private void EditAdd_OnClick(object sender, RoutedEventArgs e)
    {
        
        
        EditedTask = new TaskItem
        {
            Title = TitleTextBox.Text,
            Description = DescriptionTextBox.Text,
            Complete = false
        };

        DialogResult = true;

    
    }

    private void EditCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;

    }
    
    
}