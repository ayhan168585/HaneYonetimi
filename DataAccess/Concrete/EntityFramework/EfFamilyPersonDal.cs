using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.Incomes;
using Entities.Concrete.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFamilyPersonDal : EfEntityRepositoryBase<FamilyPerson, HaneYonetimiContext>, IFamilyPersonDal
    {
        public void AddFamilyPerson(FamilyPersonCreateDto userCreateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var familyPerson = new FamilyPerson
                {
                    FullName = userCreateDto.FullName,
                    Email = userCreateDto.Email,
                    Password = userCreateDto.Password, // Şifre burada hashlenmeli
                    ProfilePicture = userCreateDto.ProfilePicture,
                    RoleId = userCreateDto.RoleId
                };

                context.FamilyPersons.Add(familyPerson);
                context.SaveChanges();
            }
        }

        public object AverageFamilyPersonExpense()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var averageFamilyPersonExpense = context.FamilyPersons
                    .Select(u => new
                    {
                        userName = u.FullName,
                        AverageExpense = u.Expenses.Average(i => i.TotalAmount)
                    })
                    .ToList();
                return averageFamilyPersonExpense;

            }
        }

        public bool DeleteFamilyPerson(int userId)
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {

                
                    var familyPerson = context.FamilyPersons.Find(userId);

                    if (familyPerson == null) return false;

                    context.FamilyPersons.Remove(familyPerson);
                    context.SaveChanges();
                    return true;
                
            }
        }

        public List<FamilyPersonListDto> GetAllFamilyPersons()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var familyPersons = context.FamilyPersons
                    .Include(u => u.Role) // Kullanıcının rolünü çek
                    .Select(u => new FamilyPersonListDto
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email,
                        RoleName = u.Role.Name
                    })
                    .ToList();

                return familyPersons;

            }
        }

        public FamilyPersonDetailDto GetFamilyPersonDetails(int userId)
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var familyPersonDetail = context.FamilyPersons
            .Include(u => u.Role)
            .Include(u => u.Expenses)
            .Include(u => u.Incomes)
            .Where(u => u.Id == userId)
            .Select(u => new FamilyPersonDetailDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                ProfilePicture = u.ProfilePicture,
                RoleName = u.Role.Name,
                Expenses = u.Expenses.Select(e => new ExpenseDto
                {
                    Date = e.Date,
                    ExpenseId = e.Id,
                    TotalAmount = e.TotalAmount
                }).ToList(),
                Incomes = u.Incomes.Select(i => new IncomeDto
                {
                    IncomeId = i.Id,
                    Amount = i.Amount,
                    Date = i.Date
                }).ToList()
            })
            .SingleOrDefault();

                return familyPersonDetail;
            }
        }

        public List<FamilyPersonListDto> GetFamilyPersonsWithRoles()
        {
            using (var context = new HaneYonetimiContext())
            {
                var familyPersons = context.FamilyPersons
                    .Include(u => u.Role)
                    .Select(u => new FamilyPersonListDto
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email,
                        RoleName = u.Role.Name
                    })
                    .ToList();

                return familyPersons;
            }
        }

        public bool UpdateFamilyPerson(FamilyPersonUpdateDto userUpdateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var familyPerson = context.FamilyPersons.Find(userUpdateDto.Id);

                if (familyPerson == null) return false;

                familyPerson.FullName = userUpdateDto.FullName;
                familyPerson.Email = userUpdateDto.Email;
                familyPerson.ProfilePicture = userUpdateDto.ProfilePicture;
                familyPerson.RoleId = userUpdateDto.RoleId;

                context.SaveChanges();
                return true;

            }
        }

    

        public List<FamilyPersonDto> FamilyPersonsInRoles(int roleId)
        {
            using (var context=new HaneYonetimiContext())
            {
                var familyInRole = context.FamilyPersons
                    .Where(u => u.RoleId == roleId)
                    .Select(u => new FamilyPersonDto
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email
                    })
                    .ToList();
                return familyInRole;

            }
        }

        public object FamilyPersonWiseFinancials()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var familyPersonWiseFinancials = context.FamilyPersons
                .Select(u => new
                {
                    UserName = u.FullName,
                    TotalExpenses = u.Expenses.Sum(e => e.TotalAmount),
                    TotalIncomes = u.Incomes.Sum(i => i.Amount),
                    Balance = u.Incomes.Sum(i => i.Amount) - u.Expenses.Sum(e => e.TotalAmount)
                })
                .ToList();
                return familyPersonWiseFinancials;
            }
        }
    }
}
