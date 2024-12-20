using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Expenses;
using Entities.Concrete.Dtos.MarketItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _expenseService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _expenseService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Expense expense)
        {
            var result = _expenseService.Add(expense);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addexpense")]
        public IActionResult AddExpense(ExpenseCreateDto expenseCreateDto)
        {
            var result = _expenseService.AddExpense(expenseCreateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Expense expense)
        {
            var result = _expenseService.Update(expense);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Expense expense)
        {
            var result = _expenseService.Delete(expense);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("expenselistinuser")]
        public IActionResult ExpenseListInUser(int userId)
        {
            var result = _expenseService.ExpenseListInUser(userId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("expensedetail")]
        public IActionResult ExpenseDetail(int expenseId)
        {
            var result = _expenseService.ExpenseDetail(expenseId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("expensetotalinuser")]
        public IActionResult ExpenseTotalInUser(int userId)
        {
            var result = _expenseService.ExpenseTotalInUser(userId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("expenseforcategorytotals")]
        public IActionResult ExpenseForCategoryTotals()
        {
            var result = _expenseService.ExpenseForCategoryTotals();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateexpense")]
        public IActionResult UpdateExpense(ExpenseUpdateDto expenseUpdateDto)
        {
            var result = _expenseService.UpdateExpense(expenseUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deleteexpense")]
        public IActionResult DeleteExpense(int id)
        {
            var result = _expenseService.DeleteExpense(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallexpenses")]
        public IActionResult GetAllExpenses()
        {
            var result = _expenseService.GetAllExpenses();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("compareincomeAndexpense")]
        public IActionResult CompareIncomeAndExpense()
        {
            var result = _expenseService.CompareIncomeAndExpense();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("categorywiseexpenses")]
        public IActionResult categoryWiseExpenses()
        {
            var result = _expenseService.categoryWiseExpenses();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("dailyreports")]
        public IActionResult DailyReports()
        {
            var result = _expenseService.DailyReports();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("yearlyfinancials")]
        public IActionResult YearlyFinancials()
        {
            var result = _expenseService.YearlyFinancials();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("topexpensemonthofyear")]
        public IActionResult TopExpenseMonthOfYear()
        {
            var result = _expenseService.TopExpenseMonthOfYear();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
