using Microsoft.AspNetCore.Mvc;

namespace AdahiBackend.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentsController : ControllerBase
    {
        private static int _nextDepartmentId = 1;
        private static readonly List<DepartmentDetail> Departments = new();

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDetail>> GetDepartments()
        {
            return Ok(Departments);
        }

        [HttpPost]
        public ActionResult CreateDepartment([FromBody] DepartmentDetailRequest request)
        {
            var department = new DepartmentDetail
            {
                Id = _nextDepartmentId++,
                Name = request.Name,
                Manager = request.Manager,
                ManagerTitle = request.ManagerTitle,
                Employees = request.Employees,
                Status = request.Status,
                Description = request.Description,
                LinkedDepts = request.LinkedDepts ?? new List<string>(),
                CreatedAt = request.CreatedAt,
                Tasks = request.Tasks ?? new List<string>(),
                Team = request.Team ?? new List<TeamMember>()
            };

            Departments.Add(department);
            return Ok(new { id = department.Id });
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateDepartment(int id, [FromBody] DepartmentDetailRequest request)
        {
            var department = Departments.FirstOrDefault(item => item.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            department.Name = request.Name;
            department.Manager = request.Manager;
            department.ManagerTitle = request.ManagerTitle;
            department.Employees = request.Employees;
            department.Status = request.Status;
            department.Description = request.Description;
            department.LinkedDepts = request.LinkedDepts ?? new List<string>();
            department.CreatedAt = request.CreatedAt;
            department.Tasks = request.Tasks ?? new List<string>();
            department.Team = request.Team ?? new List<TeamMember>();

            return Ok(new { id = department.Id });
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteDepartment(int id)
        {
            var department = Departments.FirstOrDefault(item => item.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            Departments.Remove(department);
            return Ok(new { deleted = true });
        }
    }

    public class DepartmentDetailRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public string ManagerTitle { get; set; } = string.Empty;
        public int Employees { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string>? LinkedDepts { get; set; }
        public string CreatedAt { get; set; } = string.Empty;
        public List<string>? Tasks { get; set; }
        public List<TeamMember>? Team { get; set; }
    }

    public class DepartmentDetail : DepartmentDetailRequest
    {
        public int Id { get; set; }
    }

    public class TeamMember
    {
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
