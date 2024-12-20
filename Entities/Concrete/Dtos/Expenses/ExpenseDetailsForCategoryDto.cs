using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class ExpenseDetailsForCategoryDto:IDto
    {
        public string ExpenseDescription { get; set; } // Harcama adı veya açıklaması
        public string ExpenseName { get; set; }
        public decimal ExpenseAmount { get; set; }    // Harcama miktarı
    }
}
