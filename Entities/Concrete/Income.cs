using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Income:IEntity
    {
        public int Id { get; set; }
        public int FamilyPersonId { get; set; } // Foreign Key
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        // Navigation Properties
        public FamilyPerson FamilyPerson { get; set; }
    }
}
