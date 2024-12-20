using Core.Entities.Abstract;
using Entities.Concrete.Dtos.ExpenseItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class ExpenseDto : IDto
    {
        public int ExpenseId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserName { get; set; }
        public List<ExpenseItemDto> ExpenseItems { get; set; }
    }
}
