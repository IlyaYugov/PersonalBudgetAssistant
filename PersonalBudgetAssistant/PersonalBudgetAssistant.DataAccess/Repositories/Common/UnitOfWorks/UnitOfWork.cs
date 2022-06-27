using System.Threading.Tasks;

namespace PersonalBudgetAssistant.DataAccess.Repositories.Common.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudgetContext _context;

        public UnitOfWork(BudgetContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}