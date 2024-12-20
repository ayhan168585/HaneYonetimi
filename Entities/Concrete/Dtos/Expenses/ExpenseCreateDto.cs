using Core.Entities.Abstract;
using Entities.Concrete.Dtos.MarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Expenses
{
    public class ExpenseCreateDto:IDto
    {
        public DateTime Date { get; set; } // Harcama tarihi
        public string Description { get; set; } // Harcama açıklaması
        public int UserId { get; set; } // Harcamayı yapan kullanıcı ID'si
        public int CategoryId { get; set; }
        public List<ExpenseItemCreateDto> ExpenseItems { get; set; } // Harcama kalemleri
    }
}

