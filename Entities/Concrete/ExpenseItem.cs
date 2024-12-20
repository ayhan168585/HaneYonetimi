using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ExpenseItem : IEntity
    {
        public int Id { get; set; } // Benzersiz ID
        public int ExpenseId { get; set; } // Harcama ID
        public Expense Expense { get; set; } // Harcama ile ilişki
        public int MarketItemId { get; set; } // Market ürünü ID
        public MarketItem MarketItem { get; set; } // Market ürünü ile ilişki
        public int Quantity { get; set; } // Alınan miktar
        public decimal TotalPrice => MarketItem.Price * Quantity; // Toplam fiyat
    }
}
