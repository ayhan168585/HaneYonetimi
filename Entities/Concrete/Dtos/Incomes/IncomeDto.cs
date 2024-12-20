using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Incomes
{
    public class IncomeDto : IDto
    {
        public int IncomeId { get; set; } // Gelir kimliği
        public DateTime Date { get; set; } // Gelirin tarihi
        public decimal Amount { get; set; } // Gelir tutarı
    }
}
