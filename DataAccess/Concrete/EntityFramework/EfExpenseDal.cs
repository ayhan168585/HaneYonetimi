using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using Entities.Concrete.Dtos.ExpenseItems;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.MarketItems;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfExpenseDal : EfEntityRepositoryBase<Expense, HaneYonetimiContext>, IExpenseDal
    {
        public void AddExpense(ExpenseCreateDto expenseCreateDto)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Yeni harcama oluştur
                var expense = new Expense
                {
                    Date = expenseCreateDto.Date,
                    Description = expenseCreateDto.Description,
                    FamilyPersonId = expenseCreateDto.UserId,
                    CategoryId=expenseCreateDto.CategoryId,
                    ExpenseItems = expenseCreateDto.ExpenseItems.Select(ei => new ExpenseItem
                    {
                        MarketItemId = ei.MarketItemId,
                        Quantity = ei.Quantity
                    }).ToList()
                };

                // Toplam ücret hesaplama
                var totalAmount = expense.ExpenseItems.Sum(ei =>
                {
                    var marketItem = context.MarketItems.SingleOrDefault(mi => mi.Id == ei.MarketItemId);
                    if (marketItem == null)
                    {
                        throw new Exception($"MarketItem with ID {ei.MarketItemId} not found.");
                    }
                    return marketItem.Price * ei.Quantity;
                });

                expense.TotalAmount = totalAmount;

                context.Expenses.Add(expense);
                context.SaveChanges();
            }
        }

        public object categoryWiseExpenses()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var categoryWiseExpenses = context.Expenses
                    .GroupBy(e => e.Category.Name)
                    .Select(g => new
                    {
                        CategoryName = g.Key,
                        ExpenseName=g.Select(e => e.Description).ToList(),
                        TotalAmount = g.Sum(e => e.TotalAmount),

                       
                    })
                    .ToList();
                return categoryWiseExpenses;

            }
        }

        public object CompareIncomeAndExpense()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var monthlyReports = context.Expenses
            .GroupBy(e => new { e.Date.Year, e.Date.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalExpenses = g.Sum(e => e.TotalAmount),
                TotalIncomes = context.Incomes
                    .Where(i => i.Date.Year == g.Key.Year && i.Date.Month == g.Key.Month)
                    .Sum(i => i.Amount),
                NetAmount = context.Incomes
                    .Where(i => i.Date.Year == g.Key.Year && i.Date.Month == g.Key.Month)
                    .Sum(i => i.Amount) - g.Sum(e => e.TotalAmount)
            })
            .ToList();
                return monthlyReports;
            }

        }

        public object DailyReports()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var dailyReports = context.Expenses
                .Where(e => e.Date >= e.StartDate && e.Date <= e.EndDate)
                .GroupBy(e => e.Date.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    TotalExpenses = g.Sum(e => e.TotalAmount),
                    TotalIncomes = context.Incomes
                        .Where(i => i.Date.Date == g.Key)
                        .Sum(i => i.Amount)
                })
                .ToList();
                return dailyReports;
            }
        }

        public void DeleteExpense(int expenseId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var expense = context.Expenses
            .Include(e => e.ExpenseItems)
            .SingleOrDefault(e => e.Id == expenseId);

                if (expense == null)
                {
                    throw new Exception($"Expense with ID {expenseId} not found.");
                }

                // Harcamayı sil
                context.Expenses.Remove(expense);
                context.SaveChanges();
            }
        }

        public ExpenseDetailDto ExpenseDetail(int expenseId)
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var expenseDetail = context.Expenses
    .Include(e => e.ExpenseItems)
    .ThenInclude(ei => ei.MarketItem)
    .Where(e => e.Id == expenseId)
    .Select(e => new ExpenseDetailDto
    {
        Id = e.Id,
        Date = e.Date,
        TotalAmount = e.TotalAmount,
        Description = e.Description,
        ExpenseItems = e.ExpenseItems.Select(ei => new ExpenseItemDto
        {
            MarketItemName = ei.MarketItem.Name,
            Price = ei.MarketItem.Price,
            Quantity = ei.Quantity,
            TotalPrice = ei.TotalPrice
        }).ToList()
    })
    .SingleOrDefault();

                return expenseDetail;

            }
        }

        public List<CategoryExpenseTotalDto> ExpenseForCategoryTotals()
        {
           using (var context = new HaneYonetimiContext())
    {
        var categoryExpenseTotals = context.Expenses
            .Include(e => e.Category) // Kategori ilişkisini dahil et
            .GroupBy(e => e.Category.Name) // Kategori adına göre gruplandırma
            .Select(g => new CategoryExpenseTotalDto
            {
                CategoryName = g.Key,
                ExpenseName = g.Select(e => e.Description).ToList(), // Harcama isimlerini listele
                TotalExpense = g.Sum(e => e.TotalAmount) // Toplam harcama miktarını hesapla
            })
            .ToList();
                return categoryExpenseTotals;

    }
        }

        public List<ExpenseDto> ExpenseListInUser(int userId)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Kullanıcıya ait harcamaları getir
                var expenses = context.Expenses
                    .Where(e => e.FamilyPersonId == userId) // Kullanıcı ID'sine göre filtreleme
                    .Select(e => new ExpenseDto
                    {
                        ExpenseId = e.Id,
                        Date = e.Date,
                        TotalAmount = e.TotalAmount,
                        Description = e.Description,
                        UserName=e.FamilyPerson.FullName
                    })
                    .ToList();

                return expenses;
            }
        }

        public decimal ExpenseTotalInUser(int userId)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Kullanıcıya ait toplam harcamayı hesapla
                var totalExpense = context.Expenses
                    .Where(e => e.FamilyPersonId == userId) // Kullanıcı ID'sine göre filtreleme
                    .Sum(e => e.TotalAmount); // Toplam harcama miktarını hesapla

                return totalExpense;
            }
        }

        public List<ExpenseDto> GetAllExpenses()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var expenses = context.Expenses
            .Include(e => e.ExpenseItems)
                .ThenInclude(ei => ei.MarketItem)
            .Select(e => new ExpenseDto
            {
                ExpenseId = e.Id,
                Date = e.Date,
                Description = e.Description,
                TotalAmount = e.TotalAmount,
                UserName=e.FamilyPerson.FullName,
                ExpenseItems = e.ExpenseItems.Select(ei => new ExpenseItemDto
                {
                    MarketItemName = ei.MarketItem.Name,
                    Quantity = ei.Quantity,
                    Price = ei.MarketItem.Price,
                    TotalPrice = ei.Quantity * ei.MarketItem.Price
                }).ToList()
            })
            .ToList();

                return expenses;
            }
        }

        public object TopExpenseMonthOfYear()
        {
            using (var context=new HaneYonetimiContext())
            {
                var topSpendingMonth = context.Expenses
                .GroupBy(e => new { e.Date.Year, e.Date.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalExpense = g.Sum(e => e.TotalAmount)
                })
                .OrderByDescending(x => x.TotalExpense).ToList()
                .FirstOrDefault();
                return topSpendingMonth;
                    
            }
        }

        public void UpdateExpense(ExpenseUpdateDto expenseUpdateDto)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Mevcut harcamayı bul
                var expense = context.Expenses
                    .Include(e => e.ExpenseItems)
                    .SingleOrDefault(e => e.Id == expenseUpdateDto.Id);

                if (expense == null)
                {
                    throw new Exception($"Expense with ID {expenseUpdateDto.Id} not found.");
                }

                // Harcama bilgilerini güncelle
                expense.Date = expenseUpdateDto.Date;
                expense.Description = expenseUpdateDto.Description;

                // Harcama kalemlerini güncelle
                foreach (var itemDto in expenseUpdateDto.ExpenseItems)
                {
                    var existingItem = expense.ExpenseItems
                        .SingleOrDefault(ei => ei.MarketItemId == itemDto.MarketItemId);

                    if (existingItem != null)
                    {
                        // Mevcut kalemi güncelle
                        existingItem.Quantity = itemDto.Quantity;
                    }
                    else
                    {
                        // Yeni kalem ekle
                        expense.ExpenseItems.Add(new ExpenseItem
                        {
                            MarketItemId = itemDto.MarketItemId,
                            Quantity = itemDto.Quantity
                        });
                    }
                }

                // Eski kalemleri kaldır
                var itemsToRemove = expense.ExpenseItems
                    .Where(ei => !expenseUpdateDto.ExpenseItems.Any(dto => dto.MarketItemId == ei.MarketItemId))
                    .ToList();

                foreach (var item in itemsToRemove)
                {
                    expense.ExpenseItems.Remove(item);
                }

                // Toplam ücreti yeniden hesapla
                var totalAmount = expense.ExpenseItems.Sum(ei =>
                {
                    var marketItem = context.MarketItems.SingleOrDefault(mi => mi.Id == ei.MarketItemId);
                    if (marketItem == null)
                    {
                        throw new Exception($"MarketItem with ID {ei.MarketItemId} not found.");
                    }
                    return marketItem.Price * ei.Quantity;
                });

                expense.TotalAmount = totalAmount;

                context.SaveChanges();
            }
        }

        public object YearlyFinancials()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var yearlyFinancials = context.Expenses
                    .GroupBy(e => e.Date.Year)
                    .Select(g => new
                    {
                        Year = g.Key,
                        TotalExpenses = g.Sum(e => e.TotalAmount),
                        TotalIncomes = context.Incomes
                            .Where(i => i.Date.Year == g.Key)
                            .Sum(i => i.Amount),
                        NetAmount = context.Incomes
                            .Where(i => i.Date.Year == g.Key)
                            .Sum(i => i.Amount) - g.Sum(e => e.TotalAmount)
                    })
                    .ToList();
                return yearlyFinancials;

            }
        }
    }
}
