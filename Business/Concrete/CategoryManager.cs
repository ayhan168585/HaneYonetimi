using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult AddCategory(CategoryCreateDto categoryCreateDto)
        {
            _categoryDal.AddCategory(categoryCreateDto);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IResult DeleteCategory(int categoryId)
        {
            _categoryDal.DeleteCategory(categoryId);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        public IDataResult<List<CategoryDto>> GetAllCategories()
        {
            return new SuccessDataResult<List<CategoryDto>>(_categoryDal.GetAllCategories(), Messages.CategoriesListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p=>p.Id==id), Messages.CategoryDetailListed);
        }

        public IDataResult<List<CategoryWithMarketItemsDto>> GetCategoriesWithMarketItems()
        {
            return new SuccessDataResult<List<CategoryWithMarketItemsDto>>(_categoryDal.GetCategoriesWithMarketItems(), Messages.CategoriesWithMarketItemsListed);
        }

        public IDataResult<List<CategoryExpenseDto>> GetCategoryExpenses()
        {
            return new SuccessDataResult<List<CategoryExpenseDto>>(_categoryDal.GetCategoryExpenses());
        }

        public IDataResult<object> TopCategories()
        {
            return new SuccessDataResult<object>(_categoryDal.TopCategories(),Messages.TopCategoriesListed);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            _categoryDal.UpdateCategory(categoryUpdateDto);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
