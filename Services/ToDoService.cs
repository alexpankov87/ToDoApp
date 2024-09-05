using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Helpers;

namespace ToDoApp.Services
{
    public class ToDoService
    {
        private readonly ToDoContext _offlineContext;
        private readonly ToDoOnlineContext _onlineContext;

        public ToDoService()
        {
            _offlineContext = new ToDoContext();
            _onlineContext = new ToDoOnlineContext();

            _offlineContext.Database.EnsureCreated();
        }

        private DbContext GetCurrentContext()
        {
            return NetworkHelper.IsInternetAvailable() ? (DbContext)_onlineContext : _offlineContext;
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return GetCurrentContext().Set<ToDoItem>().ToList();
        }

        public void AddToDoItem(ToDoItem item)
        {
            var context = GetCurrentContext();
            context.Set<ToDoItem>().Add(item);
            context.SaveChanges();
        }

        public void UpdateToDoItem(ToDoItem item)
        {
            var context = GetCurrentContext();
            context.Set<ToDoItem>().Update(item);
            context.SaveChanges();
        }

        public void DeleteToDoItem(int id)
        {
            var context = GetCurrentContext();
            var item = context.Set<ToDoItem>().Find(id);
            if (item != null)
            {
                context.Set<ToDoItem>().Remove(item);
                context.SaveChanges();
            }
        }


    }
}