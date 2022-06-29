using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PersonalBudgetAssistant.DataAccess.Models;
using PersonalBudgetAssistant.Views;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.ViewModels.ExpenseCategories
{
    public class ExpenseCategoriesViewModel : BaseViewModel
    {
        private ExpenseCategory _selectedCategory;

        public ObservableCollection<ExpenseCategory> Categories { get; }
        public Command LoadExpenseCategoriesCommand { get; }
        public Command AddExpenseCategoryCommand { get; }
        public Command<ExpenseCategory> CategoryTapped { get; }

        public ExpenseCategoriesViewModel()
        {
            Title = "Expense Categories";
            Categories = new ObservableCollection<ExpenseCategory>();
            LoadExpenseCategoriesCommand = new Command(async () => await ExecuteLoadItemsCommand());

            CategoryTapped = new Command<ExpenseCategory>(OnItemSelected);

            AddExpenseCategoryCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Categories.Clear();
                var items = await DataStore.GetAllAsync();
                foreach (var item in items)
                {
                    Categories.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ExpenseCategory SelectedItem
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ExpenseCategoryPage));
        }

        async void OnItemSelected(ExpenseCategory category)
        {
            if (category == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ExpenseCategoryPage)}?{nameof(ExpenseCategoryViewModel.Id)}={category.Id}");
        }
    }
}