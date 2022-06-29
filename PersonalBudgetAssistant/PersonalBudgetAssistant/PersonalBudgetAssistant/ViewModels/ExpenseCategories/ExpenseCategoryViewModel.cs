using System;
using System.Diagnostics;
using PersonalBudgetAssistant.DataAccess.Models;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.ViewModels.ExpenseCategories
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ExpenseCategoryViewModel : BaseViewModel
    {
        private ExpenseCategory _expenseCategory;
        private int _id;
        private string _name;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public ExpenseCategoryViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                Load(value);
            }
        }

        public async void Load(int categoryId)
        {
            try
            {
                _expenseCategory = await DataStore.FindByIdAsync(categoryId);
                Name = _expenseCategory.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_name) && _expenseCategory?.Name != _name;
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (_expenseCategory == null)
            {
                ExpenseCategory category = new ExpenseCategory()
                {
                    Name = Name
                };

                await DataStore.AddAsync(category);
            }
            else
            {
                _expenseCategory.Name = Name;
            }

            
            await UnitOfWork.SaveChangesAsync();

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
