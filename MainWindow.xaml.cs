using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var newTask = new ToDoItem {

                Title = "Новая задача",
                Description = "Описание",
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };

            _viewModel.AddTask(newTask);

        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if(ToDoDataGrid.SelectedItem is ToDoItem selectedTask)
            {
                _viewModel.DeleteTask(selectedTask);
            }
        }
    }
}
