using PersonalBudgetAssistant.Models;
using PersonalBudgetAssistant.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using PersonalBudgetAssistant.DataAccess.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalBudgetAssistant.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ExpenseCategory ExpenseCategory { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}