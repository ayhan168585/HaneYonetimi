using Core.Entities.Abstract;
using Entities.Concrete.Dtos.ExpenseItems;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class ExpenseDetailDto:IDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public List<ExpenseItemDto> ExpenseItems { get; set; }
    }
}
