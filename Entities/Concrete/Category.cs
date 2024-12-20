using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; } // Kategori ID
        public string Name { get; set; } // Kategori Adı

        // Navigation Properties
        public ICollection<MarketItem> MarketItems { get; set; } // Kategoriye ait Market Ürünleri
        public ICollection<Expense> Expenses { get; set; } // Kategoriye ait Harcamalar
    }
}
