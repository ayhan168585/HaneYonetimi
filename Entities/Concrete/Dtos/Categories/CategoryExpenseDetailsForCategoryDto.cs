using Core.Entities.Abstract;
using Entities.Concrete.Dtos.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Categories
{
    public class CategoryExpenseDetailsForCategoryDto:IDto
    {
        public string CategoryName { get; set; }                // Kategori adı
        public List<ExpenseDetailsForCategoryDto> ExpenseDetails { get; set; } // Harcama detayları
        public decimal TotalExpense { get; set; }               // Toplam harcama
    }
}
