using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalBudgetAssistant.DataAccess.Models
{
    public class ExpensePlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public ExpensePlanPeriod Period { get; set; }

        public int CategoryId { get; set; }

        public DateTime Date { get; set; }

        public ExpenseCategory Category { get; set; }
    }
}