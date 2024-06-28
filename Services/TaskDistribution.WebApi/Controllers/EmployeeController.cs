using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.DtoLayer.Dtos.EmployeeDtos;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeService.TGetAllWithIncludes(x => x.Role);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var values = await _employeeService.TGetByIdWithIncludes(id, x => x.Role);
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            Employee employee = new Employee
            {
                Name = createEmployeeDto.Name,
                Surname = createEmployeeDto.Surname,
                RoleId = createEmployeeDto.RoleId,
                Level = createEmployeeDto.Level,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            await _employeeService.TInsert(employee);
            return Ok("Personel Başarıyla Oluşturuldu");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            Employee employee = new Employee
            {
                Id = updateEmployeeDto.Id,
                Name = updateEmployeeDto.Name,
                Surname = updateEmployeeDto.Surname,
                Level = updateEmployeeDto.Level,
                RoleId = updateEmployeeDto.RoleId,
                ModifiedDate = DateTime.Now
            };

            await _employeeService.TUpdate(employee);
            return Ok("Personel Başarıyla Güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _employeeService.TDelete(id);
            return Ok("Personel Başarıyla Silindi");
        }



    }
}
