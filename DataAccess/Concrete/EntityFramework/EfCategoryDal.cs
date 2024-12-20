using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using Entities.Concrete.Dtos.MarketItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, HaneYonetimiContext>, ICategoryDal
    {
        public void AddCategory(CategoryCreateDto categoryCreateDto)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Kategori oluştur
                var category = new Category
                {
                    Name = categoryCreateDto.Name
                };

                // Veritabanına ekle
                context.Categories.Add(category);

                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Silinecek kategoriyi bul
                var category = context.Categories
                    .FirstOrDefault(c => c.Id == categoryId);

                if (category == null)
                {
                    throw new InvalidOperationException("Silinecek kategori bulunamadı.");
                }

                // Kategoriyi sil
                context.Categories.Remove(category);

                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public List<CategoryDto> GetAllCategories()
        {
            using (var context = new HaneYonetimiContext())
            {
                return context.Categories
                    .Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList();
            }
        }

        public List<CategoryWithMarketItemsDto> GetCategoriesWithMarketItems()
        {
            using (HaneYonetimiContext context = new HaneYonetimiContext())
            {
                return context.Categories
            .Include(c => c.MarketItems)
            .Select(c => new CategoryWithMarketItemsDto
            {
                Id = c.Id,
                Name = c.Name,
                MarketItems = c.MarketItems.Select(mi => new MarketItemDto
                {
                    Id = mi.Id,
                    Name = mi.Name,
                    Price = mi.Price,
                    UnitId = mi.UnitId
                }).ToList()
            })
            .ToList();
            }
        
        }

        public List<CategoryExpenseDto> GetCategoryExpenses()
        {
            using (var context = new HaneYonetimiContext())
            {
                return context.Expenses
                    .GroupBy(e => e.Category)
                    .Select(g => new CategoryExpenseDto
                    {
                        Id = g.Key.Id,
                        Name = g.Key.Name,
                        TotalExpense = g.Sum(e => e.TotalAmount)
                    })
                    .ToList();
            }
        }

        public object TopCategories()
        {
            using (HaneYonetimiContext context=new HaneYonetimiContext())
            {
                var topCategories = context.Expenses
                    .GroupBy(e => e.Category.Name)
                    .Select(g => new
                    {
                        CategoryName = g.Key,
                        TotalAmount = g.Sum(e => e.TotalAmount)
                    })
                    .OrderByDescending(x => x.TotalAmount)
                    .Take(3)
                    .ToList();
                return topCategories;
            }
        }

        public void UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            using (var context = new HaneYonetimiContext())
            {
                // Mevcut kategoriyi bul
                var category = context.Categories
                    .FirstOrDefault(c => c.Id == categoryUpdateDto.Id);

                if (category == null)
                {
                    throw new InvalidOperationException("Güncellenecek kategori bulunamadı.");
                }

                // Kategoriyi güncelle
                category.Name = categoryUpdateDto.Name;

                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }
    }
}
