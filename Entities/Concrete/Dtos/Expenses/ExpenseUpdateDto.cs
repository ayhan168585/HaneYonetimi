using Core.Entities.Abstract;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class ExpenseUpdateDto:IDto
    {
        public int Id { get; set; } // Güncellenecek harcamanın ID'si
        public DateTime Date { get; set; } // Yeni tarih
        public string Description { get; set; } // Yeni açıklama
        public List<ExpenseItemUpdateDto> ExpenseItems { get; set; } // Güncellenecek harcama kalemleri
    }
}
