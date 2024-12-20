using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entities.Concrete
{
    public class FamilyPerson:IEntity
    {
        public int Id { get; set; } // Kullanıcının benzersiz kimliği
        public string FullName { get; set; } // Kullanıcının tam adı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string Password { get; set; } // Şifre (hashlenmiş olarak tutulmalı)
        public string? ProfilePicture { get; set; } // Opsiyonel profil resmi
        public int RoleId { get; set; } // Kullanıcının rolü
        public Role Role { get; set; } // Rol ile olan ilişki
        public ICollection<Expense> Expenses { get; set; } // Kullanıcının harcamaları
        public ICollection<Income> Incomes { get; set; } // Kullanıcının gelirleri
    }
}
