using PersonalBudgetAssistant.DataAccess.Models;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.ViewModels.ExpenseCategories
{
    public class NewExpenseCategoryViewModel : BaseViewModel
    {
        private string _name;

        public NewExpenseCategoryViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_name);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ExpenseCategory category = new ExpenseCategory()
            {
                Name = Name,
                //Description = Description
            };

            await DataStore.AddAsync(category);
            await UnitOfWork.SaveChangesAsync();

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
