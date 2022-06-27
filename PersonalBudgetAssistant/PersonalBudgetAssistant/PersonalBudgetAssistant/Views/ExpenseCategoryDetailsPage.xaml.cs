using PersonalBudgetAssistant.ViewModels;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.Views
{
    public partial class ExpenseCategoryDetailsPage : ContentPage
    {
        public ExpenseCategoryDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ExpenseCategoryDetailsViewModel();
        }
    }
}