using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.DtoLayer.Dtos.IssueDtos;
using TaskDistribution.DtoLayer.Dtos.RoleDtos;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpGet]
        public async Task<IActionResult> RoleList()
        {
            var values = await _roleService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var values = await _roleService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            Role role = new Role
            {
                Name = createRoleDto.Name
            };
            await _roleService.TInsert(role);
            return Ok("Rol Başarıyla Oluşturuldu");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            Role role = new Role
            {
                Id = updateRoleDto.Id,
                Name = updateRoleDto.Name
            };

            await _roleService.TUpdate(role);
            return Ok("Rol Başarıyla Güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveRole(int id)
        {
            await _roleService.TDelete(id);
            return Ok("Rol Başarıyla Silindi");
        }
    }
}
