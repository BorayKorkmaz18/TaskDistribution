using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.UI.Models
{
	public class IssueWithTaskProcessing
	{
		public Issue Issue { get; set; }
		public TaskProcessing TaskProcessing { get; set; }
	}
}
