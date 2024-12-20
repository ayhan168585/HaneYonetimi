using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Dtos
{
    public class FinancialOverviewDTO:IDto
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetBalance => TotalIncome - TotalExpense; // Net Bakiyeyi Hesaplar
    }
}
