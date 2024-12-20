using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonFinancialSummaryDTO : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance => TotalIncome - TotalExpense; // Net Bakiyeyi Hesaplar
    }
}
