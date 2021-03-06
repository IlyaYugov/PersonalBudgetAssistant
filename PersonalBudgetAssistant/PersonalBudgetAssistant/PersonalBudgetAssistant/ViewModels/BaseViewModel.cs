using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PersonalBudgetAssistant.DataAccess;
using PersonalBudgetAssistant.DataAccess.Models;
using PersonalBudgetAssistant.DataAccess.Repositories.Common;
using PersonalBudgetAssistant.DataAccess.Repositories.Common.UnitOfWorks;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            var dbContext = DependencyService.Get<BudgetContext>();
            DataStore = new RepositoryBase<ExpenseCategory>(dbContext);
            UnitOfWork = new UnitOfWork(dbContext);
        }

        protected readonly IRepositoryBase<ExpenseCategory> DataStore;
        protected IUnitOfWork UnitOfWork;

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
