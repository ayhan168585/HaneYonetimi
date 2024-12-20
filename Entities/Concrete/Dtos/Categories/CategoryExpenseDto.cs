using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Categories
{
    public class CategoryExpenseDto:IDto
    {
        public int Id { get; set; } // Kategori ID
        public string Name { get; set; } // Kategori Adı
        public decimal TotalExpense { get; set; } // Kategoriye ait toplam harcama
    }
}
