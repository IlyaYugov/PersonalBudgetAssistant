using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.ViewModels
{
    [QueryProperty(nameof(ExpenseCategoryId), nameof(ExpenseCategoryId))]
    public class ExpenseCategoryDetailsViewModel : BaseViewModel
    {
        private int _expenseCategoryId;
        private string _name;
        public string Id { get; set; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int ExpenseCategoryId
        {
            get
            {
                return _expenseCategoryId;
            }
            set
            {
                _expenseCategoryId = value;
                Load(value);
            }
        }

        public async void Load(int categoryId)
        {
            try
            {
                var item = await DataStore.FindByIdAsync(categoryId);
                Id = item.Id.ToString();
                Name = item.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
