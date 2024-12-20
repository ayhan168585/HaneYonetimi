using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Incomes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _incomeService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _incomeService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Income income)
        {
            var result = _incomeService.Add(income);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addincome")]
        public IActionResult AddIncome(IncomeCreateDto incomeCreateDto)
        {
            var result = _incomeService.AddIncome(incomeCreateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Income income)
        {
            var result = _incomeService.Update(income);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Income income)
        {
            var result = _incomeService.Delete(income);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getincomesinuser")]
        public IActionResult GetIncomesInUser(int userId)
        {
            var result = _incomeService.GetIncomesInUser(userId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getincomedetail")]
        public IActionResult GetIncomeDetail(int id)
        {
            var result=_incomeService.GetIncomeDetail(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("incometotalinuser")]
        public IActionResult IncomeTotalinUser(int userId)
        {
            var result = _incomeService.IncomeTotalinUser(userId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("incometotalalluser")]
        public IActionResult IncomeTotalAllUser()
        {
            var result = _incomeService.IncomeTotalAllUser();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateincome")]
        public IActionResult UpdateIncome(IncomeUpdateDto incomeUpdateDto)
        {
            var result = _incomeService.UpdateIncome(incomeUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("topincomesources")]
        public IActionResult TopIncomeSources()
        {
            var result = _incomeService.TopIncomeSources();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
