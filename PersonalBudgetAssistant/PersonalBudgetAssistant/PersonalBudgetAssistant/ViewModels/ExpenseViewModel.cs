using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PersonalBudgetAssistant.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        public ExpenseViewModel()
        {
            Title = "Expense";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}