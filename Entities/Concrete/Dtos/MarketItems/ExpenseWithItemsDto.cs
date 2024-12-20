using Core.Entities.Abstract;
using Entities.Concrete.Dtos.ExpenseItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class ExpenseWithItemsDto:IDto
    {
        public int ExpenseId { get; set; } // Harcama kimliği
        public DateTime Date { get; set; } // Harcama tarihi
        public decimal TotalAmount { get; set; } // Toplam harcama tutarı
        public List<ExpenseItemDto> Items { get; set; } // Harcamaya dahil olan ürünler
    }
}
