using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MarketItem:IEntity
    {
        public int Id { get; set; } // Market item ID'si
        public string Name { get; set; } // Market item adı
        public decimal Price { get; set; } // Fiyat
        public int Quantity { get; set; } // Miktar
        public int CategoryId { get; set; } // Kategori ID'si
        public Category Category { get; set; } // Kategori ilişkisi
        public int UnitId { get; set; } // Birim ID'si
        public Unit Unit { get; set; } // Birim ilişkisi
        public ICollection<MarketItemPhoto> Photos { get; set; } // Fotoğraf koleksiyonu
        public  ICollection<ExpenseItem> ExpenseItems { get; set; }

    }
}
