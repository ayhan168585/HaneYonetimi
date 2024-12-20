using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Units;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpPost("add")]
        public IActionResult Add(Unit unit)
        {
            var result = _unitService.Add(unit);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Unit unit)
        {
            var result = _unitService.Update(unit);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Unit unit)
        {
            var result = _unitService.Delete(unit);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addunit")]
        public IActionResult AddUnit(UnitCreateDto unitCreateDto)
        {
            var result = _unitService.AddUnit(unitCreateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateunit")]
        public IActionResult UpdateUnit(UnitUpdateDto unitUpdateDto)
        {
            var result = _unitService.UpdateUnit(unitUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deleteunit")]
        public IActionResult DeleteUnit(int unitId)
        {
            var result = _unitService.DeleteUnit(unitId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _unitService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result= _unitService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getunitdetail")]
        public IActionResult GetUnitDetail(int unitId)
        {
            var result = _unitService.GetUnitDetail(unitId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallunits")]
        public IActionResult GetAllUnits()
        {
            var result = _unitService.GetAllUnits();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
