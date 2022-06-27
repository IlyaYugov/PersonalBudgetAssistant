using PersonalBudgetAssistant.Views;
using System;
using Xamarin.Forms;

namespace PersonalBudgetAssistant
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExpenseCategoryDetailsPage), typeof(ExpenseCategoryDetailsPage));
            Routing.RegisterRoute(nameof(NewExpenseCategoryPage), typeof(NewExpenseCategoryPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
