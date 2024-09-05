using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=todo.db");
                var dbPath = "Data Source=todo.db";
                optionsBuilder.UseSqlite(dbPath).LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                 .EnableSensitiveDataLogging();

                // Выведем путь к базе данных
                Console.WriteLine($"Путь базы: {dbPath}");
                 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Привязываем таблицу ToDoItems к модели
            modelBuilder.Entity<ToDoItem>().ToTable("ToDoItems");
        }
    }
}
