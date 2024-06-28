using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskDistribution.EntityLayer.Concrete;
using TaskDistribution.UI.Models;

namespace TaskDistribution.UI.Controllers
{
	public class TaskController : Controller
	{
		private readonly HttpClient _httpClient;

		public TaskController(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://localhost:7052/");
		}
		public async Task<IActionResult> Index()
		{
			try
			{
				var response = await _httpClient.GetAsync("api/Issue");
				if (response.IsSuccessStatusCode)
				{
					var responseBody = await response.Content.ReadAsStringAsync();
					var issues = JsonSerializer.Deserialize<IEnumerable<Issue>>(responseBody, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});

					var taskProcessingsResponse = await _httpClient.GetAsync("api/TaskProcessing");
					if (taskProcessingsResponse.IsSuccessStatusCode)
					{
						var taskProcessingsBody = await taskProcessingsResponse.Content.ReadAsStringAsync();
						var taskProcessings = JsonSerializer.Deserialize<IEnumerable<TaskProcessing>>(taskProcessingsBody, new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true
						});

						var issueWithTasks = issues.Select(issue => new IssueWithTaskProcessing
						{
							Issue = issue,
							TaskProcessing = taskProcessings.FirstOrDefault(tp => tp.IssueId == issue.Id)
						}).OrderBy(x => x.Issue.Id);

						return View(issueWithTasks);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return View(new List<IssueWithTaskProcessing>());
		}


		[HttpPost]
		public async Task<IActionResult> AssignTask(int issueId)
		{
			try
			{
				var response = await _httpClient.PostAsync($"api/TaskProcessing/AssignTask/?id={issueId}", null);
				if (response.IsSuccessStatusCode)
				{
					TempData["Message"] = "Görev başarıyla atandı.";
				}
				else
				{
					TempData["Error"] = "Görev atanırken bir hata oluştu.";
				}
			}
			catch (Exception ex)
			{
				TempData["Error"] = $"Hata: {ex.Message}";
			}

			return RedirectToAction("Index");
		}
	}
}
