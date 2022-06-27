using PersonalBudgetAssistant.ViewModels;
using PersonalBudgetAssistant.DataAccess.Models;
using PersonalBudgetAssistant.ViewModels.ExpenseCategories;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.Views
{
    public partial class NewExpenseCategoryPage : ContentPage
    {
        public ExpenseCategory ExpenseCategory { get; set; }

        public NewExpenseCategoryPage()
        {
            InitializeComponent();
            BindingContext = new NewExpenseCategoryViewModel();
        }
    }
}