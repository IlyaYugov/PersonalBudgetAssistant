using System;
using Microsoft.EntityFrameworkCore;
using PersonalBudgetAssistant.DataAccess.Models;

namespace PersonalBudgetAssistant.DataAccess
{
    public class BudgetContext : DbContext
    {
        private static volatile bool _isInitialized;
        private static readonly object Mutex = new object();

        public BudgetContext()
        {
            if (_isInitialized)
            {
                return;
            }

            lock (Mutex)
            {
                if (_isInitialized)
                {
                    return;
                }

                Database.Migrate();

                _isInitialized = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            optionsBuilder.UseSqlite($"Data Source={path}/BudgetContext.db;");
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}

