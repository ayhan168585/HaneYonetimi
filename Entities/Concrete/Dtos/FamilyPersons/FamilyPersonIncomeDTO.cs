using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonIncomeDTO : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
