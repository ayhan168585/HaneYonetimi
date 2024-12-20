using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class ExpenseListDto:IDto
    {
        public int Id { get; set; }
        public string Description { get; set; } // Harcama açıklaması
        public decimal Amount { get; set; } // Tutar
        public DateTime Date { get; set; } // Tarih
        public string CategoryName { get; set; } // Kategori adı
    }
}
