using Core.Entities.Abstract;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Users
{
    public class FamilyPersonDetailDto : IDto
    {
        public int Id { get; set; } // Kullanıcının kimliği
        public string FullName { get; set; } // Kullanıcının tam adı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string? ProfilePicture { get; set; } // Kullanıcının opsiyonel profil resmi
        public string RoleName { get; set; } // Kullanıcının rol adı
        public ICollection<ExpenseDto> Expenses { get; set; } // Kullanıcının harcamalarının listesi
        public ICollection<IncomeDto> Incomes { get; set; } // Kullanıcının gelirlerinin listesi
    }

}
