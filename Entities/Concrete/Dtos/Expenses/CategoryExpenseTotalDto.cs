using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class CategoryExpenseTotalDto:IDto
    {
        public string CategoryName { get; set; } // Kategori adı
        public List<string> ExpenseName { get; set; }
        public decimal TotalExpense { get; set; } // Toplam harcama miktarı

    }
}
