using Microsoft.AspNetCore.Mvc;

namespace AdahiBackend.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractsController : ControllerBase
    {
        private static int _nextContractId = 1;
        private static readonly List<ContractEntry> Contracts = new();

        [HttpGet]
        public ActionResult<IEnumerable<ContractEntry>> GetContracts()
        {
            return Ok(Contracts);
        }

        [HttpPost]
        public ActionResult CreateContract([FromBody] ContractRequest request)
        {
            var contract = new ContractEntry
            {
                Id = _nextContractId++,
                Type = request.Type,
                Dept = request.Dept,
                Name = request.Name,
                Company = request.Company,
                Status = request.Status,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Duration = request.Duration,
                Manager = request.Manager,
                Value = request.Value,
                Spent = request.Spent,
                Remaining = request.Remaining,
                Timeline = request.Timeline
            };

            Contracts.Add(contract);
            return Ok(new { id = contract.Id });
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateContract(int id, [FromBody] ContractRequest request)
        {
            var contract = Contracts.FirstOrDefault(item => item.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            contract.Type = request.Type;
            contract.Dept = request.Dept;
            contract.Name = request.Name;
            contract.Company = request.Company;
            contract.Status = request.Status;
            contract.StartDate = request.StartDate;
            contract.EndDate = request.EndDate;
            contract.Duration = request.Duration;
            contract.Manager = request.Manager;
            contract.Value = request.Value;
            contract.Spent = request.Spent;
            contract.Remaining = request.Remaining;
            contract.Timeline = request.Timeline;

            return Ok(new { id = contract.Id });
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteContract(int id)
        {
            var contract = Contracts.FirstOrDefault(item => item.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            Contracts.Remove(contract);
            return Ok(new { deleted = true });
        }
    }

    public class ContractRequest
    {
        public string Type { get; set; } = string.Empty;
        public string Dept { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Spent { get; set; } = string.Empty;
        public string Remaining { get; set; } = string.Empty;
        public string Timeline { get; set; } = string.Empty;
    }

    public class ContractEntry : ContractRequest
    {
        public int Id { get; set; }
    }
}
