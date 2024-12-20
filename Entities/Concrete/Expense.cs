using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Expense:IEntity
    {
        public int Id { get; set; } // Benzersiz ID
        public DateTime Date { get; set; } // Harcama tarihi
        public decimal TotalAmount { get; set; } // Toplam harcama tutarı
        public string Description { get; set; } // Harcama açıklaması
        public int FamilyPersonId { get; set; } // Harcamayı yapan kullanıcı ID'si
        public FamilyPerson FamilyPerson { get; set; } // Kullanıcı ile ilişki
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime? StartDate { get; set; } // Harcamanın başlangıç tarihi (opsiyonel)
        public DateTime? EndDate { get; set; } // Harcamanın bitiş tarihi (opsiyonel)
        public ICollection<ExpenseItem> ExpenseItems { get; set; } // Harcamaya ait ürünler
    }
}
