using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        public List<CategoryDto> GetAllCategories();
        public List<CategoryWithMarketItemsDto> GetCategoriesWithMarketItems();
        public List<CategoryExpenseDto> GetCategoryExpenses();
        public void AddCategory(CategoryCreateDto categoryCreateDto);
        public void UpdateCategory(CategoryUpdateDto categoryUpdateDto);
        public void DeleteCategory(int categoryId);
        public object TopCategories();




    }
}
