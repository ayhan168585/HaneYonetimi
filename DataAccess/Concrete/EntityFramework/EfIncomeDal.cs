using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Incomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIncomeDal : EfEntityRepositoryBase<Income, HaneYonetimiContext>, IIncomeDal
    {
        public void AddIncome(IncomeCreateDto incomeCreateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var user = context.FamilyPersons.SingleOrDefault(u => u.Id == incomeCreateDto.UserId);
                if (user == null)
                {
                    throw new Exception("Kullanıcı bulunamadı.");
                }

                // Yeni gelir nesnesini oluştur
                var income = new Income
                {
                    Amount = incomeCreateDto.Amount,
                    Date = incomeCreateDto.Date,
                    Description = incomeCreateDto.Description,
                    FamilyPersonId = incomeCreateDto.UserId
                };

                // Geliri ekle ve veritabanını kaydet
                context.Incomes.Add(income);
                context.SaveChanges();
            }
        }

        public IncomeDetailDto GetIncomeDetail(int id)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var incomeDetail = context.Incomes
                    .Where(i => i.Id == id)
                    .Select(i => new IncomeDetailDto
                    {
                        Id = i.Id,
                        Description = i.Description,
                        Amount = i.Amount,
                        Date = i.Date,
                        UserId = i.FamilyPersonId,
                        UserName = i.FamilyPerson.FullName
                    })
                    .SingleOrDefault();
                return incomeDetail;
            }
        }

        public List<IncomeListDto> GetIncomesInUser(int userId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var incomeList = context.Incomes
                .Where(i =>i.FamilyPersonId==userId)
                .Select(i => new IncomeListDto
                {
                   Id = i.FamilyPersonId,
                   Amount = i.Amount,
                   Description=i.Description,
                   Date = i.Date               
                   
                })
                .ToList();
                return incomeList;

            }
        }

        public decimal IncomeTotalAllUser()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var monthlyIncomes = context.Incomes
            .GroupBy(i => new { i.Date.Year, i.Date.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalIncome = g.Sum(i => i.Amount)
            })
            .ToList();
                return monthlyIncomes.Sum(i=>i.TotalIncome);


            }
        }

        public decimal IncomeTotalinUser(int userId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var monthlyIncomeTotal = context.Incomes
                .Where(i => i.FamilyPersonId == userId && i.Date.Month == DateTime.Now.Month && i.Date.Year == DateTime.Now.Year)
                .Sum(i => i.Amount);
                return monthlyIncomeTotal;

            }
        }

        public object TopIncomeSources()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var topIncomeSources = context.Incomes
                    .GroupBy(i => i.Description)
                    .Select(g => new
                    {
                        IncomeSource = g.Key,
                        TotalAmount = g.Sum(i => i.Amount)
                    })
                    .OrderByDescending(x => x.TotalAmount)
                    .Take(5)
                    .ToList();
                return topIncomeSources;
            }
        }

        public void UpdateIncome(IncomeUpdateDto incomeUpdateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var income = context.Incomes.Find(incomeUpdateDto.Id);
                if (income != null)
                {
                    income.Description = incomeUpdateDto.Description;
                    income.Amount = incomeUpdateDto.Amount;
                    income.Date = incomeUpdateDto.Date;

                    context.Incomes.Update(income);
                    context.SaveChangesAsync();
                }

            }
        }
    }
}
