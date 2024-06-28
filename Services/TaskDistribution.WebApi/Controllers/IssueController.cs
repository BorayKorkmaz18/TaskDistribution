using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.DtoLayer.Dtos.IssueDtos;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {

        private readonly IIssueService _ıssueService;

        public IssueController(IIssueService ıssueService)
        {
            _ıssueService = ıssueService;
        }

        [HttpGet]
        public async Task<IActionResult> IssueList()
        {
            var values = await _ıssueService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssueById(int id)
        {
            var values = await _ıssueService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue(CreateIssueDto createIssueDto)
        {
            Issue Issue = new Issue
            {
                Name = createIssueDto.Name,
                DifficultyLevel = createIssueDto.Severity,
                Description = createIssueDto.Description,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now

            };
            await _ıssueService.TInsert(Issue);
            return Ok("Task Başarıyla Oluşturuldu");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateIssue(UpdateIssueDto updateIssueDto)
        {
            Issue Issue = new Issue
            {
                Id = updateIssueDto.Id,
                Name = updateIssueDto.Name,
                DifficultyLevel = updateIssueDto.Severity,
                Description = updateIssueDto.Description,
                ModifiedDate = updateIssueDto.ModifiedDate
            };

            await _ıssueService.TUpdate(Issue);
            return Ok("Task Başarıyla Güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveIssue(int id)
        {
            await _ıssueService.TDelete(id);
            return Ok("Personel Başarıyla Silindi");
        }



    }
}
