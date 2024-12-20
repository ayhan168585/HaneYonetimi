using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.MarketItems
{
    public class ExpenseItemUpdateDto:IDto
    {
        public int MarketItemId { get; set; } // Ürünün ID'si
        public int Quantity { get; set; } // Güncellenmiş miktar
    }
}
