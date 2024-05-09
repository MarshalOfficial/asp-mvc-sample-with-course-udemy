using asp_mvc_sample_with_course_udemi.Models;
using asp_mvc_sample_with_course_udemi.Services;
using asp_mvc_sample_with_course_udemi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace asp_mvc_sample_with_course_udemi.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            var list = new List<ItemViewModel>();
            var items = await itemService.GetAll();
            list.AddRange(items.Select(item => new ItemViewModel { Id = item.Id, Name = item.Name, Price = item.Price }));

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemViewModel vm)
        {
            var model = new Item
            {
                Name = vm.Name,
                Price = vm.Price,
            };
            await itemService.SaveItem(model);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await itemService.GetById(id);
            var vm = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel vm)
        {
            var model = new Item
            {
                Id = vm.Id,
                Name = vm.Name,
                Price = vm.Price,
            };
            await itemService.UpdateItem(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await itemService.DeleteItem(id);

            return RedirectToAction("Index");
        }
    }
}