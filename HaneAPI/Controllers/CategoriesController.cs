using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallcategories")]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("categorieswithmarketitems")]
        public IActionResult GetCategoriesWithMarketItems()
        {
            var result = _categoryService.GetCategoriesWithMarketItems();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcategoryexpenses")]
        public IActionResult GetCategoryExpenses()
        {
            var result = _categoryService.GetCategoryExpenses();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addcategory")]
        public IActionResult AddCategory(CategoryCreateDto categoryCreateDto)
        {
            var result = _categoryService.AddCategory(categoryCreateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updatecategory")]
        public IActionResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var result = _categoryService.UpdateCategory(categoryUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deletecategory")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("topategories")]
        public IActionResult TopCategories()
        {
            var result = _categoryService.TopCategories();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
