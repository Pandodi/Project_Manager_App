using Project_Manager_WPF.ViewModels;
using System.Windows;

namespace Project_Manager_WPF;
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}