using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class MainViewModel
    {
        private readonly ToDoService _service;

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public MainViewModel()
        {
            _service = new ToDoService();
            LoadData();
        }

        private void LoadData()
        {
            var items = _service.GetToDoItems();
            ToDoItems = new ObservableCollection<ToDoItem>(items);
        }

        public void AddTask(ToDoItem newTask)
        {
            _service.AddToDoItem(newTask);
            ToDoItems.Add(newTask);
        }

        public void DeleteTask(ToDoItem task)
        {
            _service.DeleteToDoItem(task.Id);
            ToDoItems.Remove(task);
        }
    }
}
