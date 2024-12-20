using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.ExpenseItems;
using Entities.Concrete.Dtos.MarketItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMarketItemDal : EfEntityRepositoryBase<MarketItem, HaneYonetimiContext>, IMarketItemDal
    {
        public void AddMarketItem(MarketItemCreateDto marketItemCreateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var marketItem = new MarketItem
                {
                    Name = marketItemCreateDto.Name,
                    Price = marketItemCreateDto.Price,
                    CategoryId = marketItemCreateDto.CategoryId,
                    Quantity=marketItemCreateDto.Quantity,
                    UnitId = marketItemCreateDto.UnitId,
                    
                    
                    
                };

                context.MarketItems.Add(marketItem);
                context.SaveChanges();
            }
        }

        public bool DeleteMarketItem(int marketItemId)
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                var marketItem = context.MarketItems.Find(marketItemId);

                if (marketItem == null) return false;

                context.MarketItems.Remove(marketItem);
                context.SaveChanges();
                return true;
            }
        }

        public object MarketItemExpenses()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var marketItemExpenses = context.ExpenseItems
                    .Include(ei => ei.MarketItem)
                    .GroupBy(ei => ei.MarketItem.Name)
                    .Select(g => new
                    {
                        MarketItemName = g.Key,
                        TotalExpense = g.Sum(ei => ei.MarketItem.Price * ei.Quantity) // Toplam harcamayı hesapla
                    })
                    .OrderByDescending(x => x.TotalExpense)
                    .ToList();
                return marketItemExpenses;
            }
        }

        public List<MarketItemListDto> MarketItemLists()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var marketItems = context.MarketItems
                    .Include(mi => mi.Category)
                    .Select(mi => new MarketItemListDto
                    {
                        Id = mi.Id,
                        Name = mi.Name,
                        Price = mi.Price,
                        Quantity = mi.Quantity,
                        UnitName=mi.Unit.Name,
                        CategoryName = mi.Category.Name
                    })
                    .ToList();
                return marketItems;

            }
        }

        public List<ExpenseItemDto> MarketItemListsByExpense(int expenseId)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var expenseItems = context.ExpenseItems
                 .Include(ei => ei.MarketItem)
                 .Where(ei => ei.ExpenseId == expenseId) // Harcama ID'sine göre filtreleme
                 .Select(ei => new ExpenseItemDto
                 {
                     MarketItemName = ei.MarketItem.Name,
                     Price = ei.MarketItem.Price,
                     Quantity = ei.Quantity
                 })
                 .ToList();
                return expenseItems;
            }
        }

        public void UpdateMarketItem(MarketItemUpdateDto marketItemUpdateDto)
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var marketItem = context.MarketItems
            .SingleOrDefault(mi => mi.Id == marketItemUpdateDto.MarketItemId);

                if (marketItem == null)
                {
                    throw new Exception("Market item bulunamadı.");
                }

                // MarketItem özelliklerini güncelle
                marketItem.Name = marketItemUpdateDto.Name;
                marketItem.Price = marketItemUpdateDto.Price;
                marketItem.Quantity = marketItemUpdateDto.Quantity;
                marketItem.CategoryId = marketItemUpdateDto.CategoryId;
                marketItem.UnitId = marketItemUpdateDto.UnitId;
               

                // Veritabanına kaydet
                context.SaveChanges();
            }
        }
    }
}
