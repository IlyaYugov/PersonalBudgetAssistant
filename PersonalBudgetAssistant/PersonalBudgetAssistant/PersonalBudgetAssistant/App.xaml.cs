using PersonalBudgetAssistant.DataAccess;
using PersonalBudgetAssistant.DataAccess.Models;
using PersonalBudgetAssistant.DataAccess.Repositories.Common;
using PersonalBudgetAssistant.DataAccess.Repositories.Common.UnitOfWorks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalBudgetAssistant
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<BudgetContext>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
