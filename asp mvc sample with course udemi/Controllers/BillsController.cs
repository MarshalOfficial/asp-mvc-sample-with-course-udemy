using asp_mvc_sample_with_course_udemi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_mvc_sample_with_course_udemi.Controllers
{
    public class BillsController : Controller
    {
        private readonly IItemService itemService;

        public BillsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        {
            var items = await itemService.GetAll();

            ViewBag.ItemsList = new SelectList(items, "Id", "Name");

            return View();
        }

        public async Task<IActionResult> GetPrice(int id)
        {
            var item = await itemService.GetById(id);

            return Json(item.Price);
        }
    }
}