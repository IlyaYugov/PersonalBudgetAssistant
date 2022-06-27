using PersonalBudgetAssistant.ViewModels;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.Views
{
    public partial class ExpenseCategoriesPage : ContentPage
    {
        ExpenseCategoriesViewModel _viewModel;

        public ExpenseCategoriesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ExpenseCategoriesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}