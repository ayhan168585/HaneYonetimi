using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.ExpenseItems
{
    public class ExpenseItemDto : IDto
    {
        public string MarketItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
