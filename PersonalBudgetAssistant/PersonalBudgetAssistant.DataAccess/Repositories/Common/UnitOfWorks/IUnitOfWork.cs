using System.Threading.Tasks;

namespace PersonalBudgetAssistant.DataAccess.Repositories.Common.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}