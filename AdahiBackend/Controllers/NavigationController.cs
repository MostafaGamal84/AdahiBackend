using Microsoft.AspNetCore.Mvc;

namespace AdahiBackend.Controllers
{
    [ApiController]
    [Route("api/navigation")]
    public class NavigationController : ControllerBase
    {
        private static int _nextMenuId = 1;
        private static readonly List<MenuItemEntry> MenuItems = new();

        [HttpGet("menu")]
        public ActionResult<IEnumerable<MenuItemEntry>> GetMenu()
        {
            return Ok(MenuItems);
        }

        [HttpPost("menu")]
        public ActionResult CreateMenuItem([FromBody] MenuItemRequest request)
        {
            var entry = new MenuItemEntry
            {
                Id = _nextMenuId++,
                Title = request.Title,
                Icon = request.Icon,
                Href = request.Href,
                Active = request.Active
            };

            MenuItems.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("menu/{id:int}")]
        public ActionResult UpdateMenuItem(int id, [FromBody] MenuItemRequest request)
        {
            var entry = MenuItems.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Title = request.Title;
            entry.Icon = request.Icon;
            entry.Href = request.Href;
            entry.Active = request.Active;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("menu/{id:int}")]
        public ActionResult DeleteMenuItem(int id)
        {
            var entry = MenuItems.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            MenuItems.Remove(entry);
            return Ok(new { deleted = true });
        }
    }

    public class MenuItemRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public bool Active { get; set; }
    }

    public class MenuItemEntry : MenuItemRequest
    {
        public int Id { get; set; }
    }
}
