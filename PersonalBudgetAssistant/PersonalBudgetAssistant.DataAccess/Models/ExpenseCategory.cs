using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalBudgetAssistant.DataAccess.Models
{
    public class ExpenseCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}