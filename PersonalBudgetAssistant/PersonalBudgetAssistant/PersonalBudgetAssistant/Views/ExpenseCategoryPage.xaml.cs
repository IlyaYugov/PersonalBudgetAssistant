using PersonalBudgetAssistant.DataAccess.Models;
using PersonalBudgetAssistant.ViewModels.ExpenseCategories;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.Views
{
    public partial class ExpenseCategoryPage : ContentPage
    {
        public ExpenseCategoryPage()
        {
            InitializeComponent();
            BindingContext = new ExpenseCategoryViewModel();
        }
    }
}