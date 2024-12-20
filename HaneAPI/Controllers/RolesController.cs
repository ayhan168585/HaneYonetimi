using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _roleService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _roleService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Role role)
        {
            var result = _roleService.Add(role);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addRole")]
        public IActionResult AddRole(RoleCreateDto roleCreateDto)
        {
            var result = _roleService.AddRole(roleCreateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Role role)
        {
            var result = _roleService.Update(role);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updaterole")]
        public IActionResult UpdateRole(RoleUpdateDto roleUpdateDto)
        {
            var result = _roleService.UpdateRole(roleUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Role role)
        {
            var result = _roleService.Delete(role);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallroles")]
        public IActionResult GetAllRoles()
        {
            var result = _roleService.GetAllRoles();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getroledetails")]
        public IActionResult GetRoleDetails(int id)
        {
            var result = _roleService.GetRoleDetails(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deleterole")]
        public IActionResult DeleteRole(int roleId)
        {
            var result= _roleService.DeleteRole(roleId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
