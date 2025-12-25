using Microsoft.AspNetCore.Mvc;

namespace AdahiBackend.Controllers
{
    [ApiController]
    [Route("api/slaughter")]
    public class SlaughterController : ControllerBase
    {
        private static int _nextSummaryId = 1;
        private static int _nextDailyProgressId = 1;

        private static readonly List<SlaughterSummaryEntry> SlaughterSummaries = new();
        private static readonly List<DailyProgressEntry> DailyProgressEntries = new();

        [HttpGet("summary")]
        public ActionResult<IEnumerable<SlaughterSummaryEntry>> GetSummary()
        {
            return Ok(SlaughterSummaries);
        }

        [HttpPost("summary")]
        public ActionResult CreateSummary([FromBody] SlaughterSummaryRequest request)
        {
            var entry = new SlaughterSummaryEntry
            {
                Id = _nextSummaryId++,
                Type = request.Type,
                Count = request.Count,
                Fill = request.Fill,
                Month = request.Month,
                Week = request.Week
            };

            SlaughterSummaries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("summary/{id:int}")]
        public ActionResult UpdateSummary(int id, [FromBody] SlaughterSummaryRequest request)
        {
            var entry = SlaughterSummaries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Type = request.Type;
            entry.Count = request.Count;
            entry.Fill = request.Fill;
            entry.Month = request.Month;
            entry.Week = request.Week;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("summary/{id:int}")]
        public ActionResult DeleteSummary(int id)
        {
            var entry = SlaughterSummaries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            SlaughterSummaries.Remove(entry);
            return Ok(new { deleted = true });
        }

        [HttpGet("daily-progress")]
        public ActionResult<IEnumerable<DailyProgressEntry>> GetDailyProgress()
        {
            return Ok(DailyProgressEntries);
        }

        [HttpPost("daily-progress")]
        public ActionResult CreateDailyProgress([FromBody] DailyProgressRequest request)
        {
            var entry = new DailyProgressEntry
            {
                Id = _nextDailyProgressId++,
                Day = request.Day,
                Count = request.Count,
                Month = request.Month,
                Week = request.Week
            };

            DailyProgressEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("daily-progress/{id:int}")]
        public ActionResult UpdateDailyProgress(int id, [FromBody] DailyProgressRequest request)
        {
            var entry = DailyProgressEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Day = request.Day;
            entry.Count = request.Count;
            entry.Month = request.Month;
            entry.Week = request.Week;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("daily-progress/{id:int}")]
        public ActionResult DeleteDailyProgress(int id)
        {
            var entry = DailyProgressEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            DailyProgressEntries.Remove(entry);
            return Ok(new { deleted = true });
        }
    }

    public class SlaughterSummaryRequest
    {
        public string Type { get; set; } = string.Empty;
        public int Count { get; set; }
        public string Fill { get; set; } = string.Empty;
        public string Month { get; set; } = string.Empty;
        public string Week { get; set; } = string.Empty;
    }

    public class SlaughterSummaryEntry : SlaughterSummaryRequest
    {
        public int Id { get; set; }
    }

    public class DailyProgressRequest
    {
        public string Day { get; set; } = string.Empty;
        public int Count { get; set; }
        public string Month { get; set; } = string.Empty;
        public string Week { get; set; } = string.Empty;
    }

    public class DailyProgressEntry : DailyProgressRequest
    {
        public int Id { get; set; }
    }
}
