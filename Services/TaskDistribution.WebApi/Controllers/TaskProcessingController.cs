using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.DtoLayer.Dtos.RoleDtos;
using TaskDistribution.DtoLayer.Dtos.TaskProcessingDtos;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskProcessingController : ControllerBase
    {

        private readonly ITaskProcessingService _taskProcessingService;

        public TaskProcessingController(ITaskProcessingService taskProcessingService)
        {
            _taskProcessingService = taskProcessingService;
        }

        [HttpGet]
        public async Task<IActionResult> TaskList()
        {
            var values = await _taskProcessingService.TGetAllWithIncludes(x => x.Issue);
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var values = await _taskProcessingService.TGetByIdWithIncludes(id, x => x.Issue);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskProcessingDto createTaskProcessingDto)
        {
            TaskProcessing Task = new TaskProcessing
            {
                EmployeeId = createTaskProcessingDto.EmployeeId,
                IssueId = createTaskProcessingDto.IssueId,
                Status = createTaskProcessingDto.Statu,
                Description = createTaskProcessingDto.Description

            };
            await _taskProcessingService.TInsert(Task);
            return Ok("Görev Başarıyla Oluşturuldu");
        }


        [HttpPost("AssignTask")]
        public async Task<IActionResult> AssignTaskToDeveloper(int id)
        {
            var result = await _taskProcessingService.AssignTask(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskProcessing(UpdateTaskProcessingDto updateTaskProcessingDto)
        {
            TaskProcessing Task = new TaskProcessing
            {
                Description = updateTaskProcessingDto.Description,
                Id = updateTaskProcessingDto.Id,
                Status = updateTaskProcessingDto.Statu,
                IssueId = updateTaskProcessingDto.IssueId,
                EmployeeId = updateTaskProcessingDto.EmployeeId
            };

            await _taskProcessingService.TUpdate(Task);
            return Ok("Görev Atama Başarıyla Güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveTaskProcessing(int id)
        {
            await _taskProcessingService.TDelete(id);
            return Ok("Görev Atama Başarıyla Silindi");
        }
    }
}
