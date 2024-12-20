using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Incomes
{
    public class IncomeListDto:IDto
    {
        public int Id { get; set; }
        public string Description { get; set; } // Gelir açıklaması
        public decimal Amount { get; set; } // Miktar
        public DateTime Date { get; set; } // Tarih
    }
}
