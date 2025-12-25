using Microsoft.AspNetCore.Mvc;

namespace AdahiBackend.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private static int _nextPerformanceId = 1;
        private static int _nextDepartmentId = 1;
        private static readonly List<PerformanceMetric> PerformanceMetrics = new();
        private static readonly List<DepartmentSummary> DepartmentSummaries = new();

        [HttpGet("performance")]
        public ActionResult<IEnumerable<PerformanceMetric>> GetPerformance()
        {
            return Ok(PerformanceMetrics);
        }

        [HttpPost("performance")]
        public ActionResult<PerformanceMetric> CreatePerformance([FromBody] PerformanceMetricRequest request)
        {
            var metric = new PerformanceMetric
            {
                Id = _nextPerformanceId++,
                Month = request.Month,
                Value = request.Value
            };

            PerformanceMetrics.Add(metric);
            return Ok(metric);
        }

        [HttpPut("performance/{id:int}")]
        public ActionResult<PerformanceMetric> UpdatePerformance(int id, [FromBody] PerformanceMetricRequest request)
        {
            var metric = PerformanceMetrics.FirstOrDefault(item => item.Id == id);
            if (metric == null)
            {
                return NotFound();
            }

            metric.Month = request.Month;
            metric.Value = request.Value;
            return Ok(metric);
        }

        [HttpDelete("performance/{id:int}")]
        public ActionResult DeletePerformance(int id)
        {
            var metric = PerformanceMetrics.FirstOrDefault(item => item.Id == id);
            if (metric == null)
            {
                return NotFound();
            }

            PerformanceMetrics.Remove(metric);
            return Ok(new { deleted = true });
        }

        [HttpGet("departments")]
        public ActionResult<IEnumerable<DepartmentSummary>> GetDepartments()
        {
            return Ok(DepartmentSummaries);
        }

        [HttpPost("departments")]
        public ActionResult<DepartmentSummary> CreateDepartment([FromBody] DepartmentSummaryRequest request)
        {
            var summary = new DepartmentSummary
            {
                Id = _nextDepartmentId++,
                Name = request.Name,
                Progress = request.Progress,
                Status = request.Status,
                Lead = request.Lead
            };

            DepartmentSummaries.Add(summary);
            return Ok(summary);
        }

        [HttpPut("departments/{id:int}")]
        public ActionResult<DepartmentSummary> UpdateDepartment(int id, [FromBody] DepartmentSummaryRequest request)
        {
            var summary = DepartmentSummaries.FirstOrDefault(item => item.Id == id);
            if (summary == null)
            {
                return NotFound();
            }

            summary.Name = request.Name;
            summary.Progress = request.Progress;
            summary.Status = request.Status;
            summary.Lead = request.Lead;
            return Ok(summary);
        }

        [HttpDelete("departments/{id:int}")]
        public ActionResult DeleteDepartment(int id)
        {
            var summary = DepartmentSummaries.FirstOrDefault(item => item.Id == id);
            if (summary == null)
            {
                return NotFound();
            }

            DepartmentSummaries.Remove(summary);
            return Ok(new { deleted = true });
        }
    }

    public class PerformanceMetricRequest
    {
        public string Month { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class PerformanceMetric : PerformanceMetricRequest
    {
        public int Id { get; set; }
    }

    public class DepartmentSummaryRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Progress { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Lead { get; set; } = string.Empty;
    }

    public class DepartmentSummary : DepartmentSummaryRequest
    {
        public int Id { get; set; }
    }
}
