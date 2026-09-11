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

namespace ToDoWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Dale");
    }
    
    private void Searchbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchtext = SearchBox.Text;
        
    }

    
}