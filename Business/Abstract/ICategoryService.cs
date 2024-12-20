using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);

        IResult Add(Category category);

        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<List<CategoryDto>> GetAllCategories();
        IDataResult<List<CategoryWithMarketItemsDto>> GetCategoriesWithMarketItems();
        IDataResult<List<CategoryExpenseDto>> GetCategoryExpenses();
        IResult AddCategory(CategoryCreateDto categoryCreateDto);
        IResult UpdateCategory(CategoryUpdateDto categoryUpdateDto);
        IResult DeleteCategory(int categoryId);
        IDataResult<object> TopCategories();







    }
}
