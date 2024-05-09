using asp_mvc_sample_with_course_udemi.Models;
using asp_mvc_sample_with_course_udemi.Services;
using asp_mvc_sample_with_course_udemi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_mvc_sample_with_course_udemi.Controllers
{
    public class BillsController : Controller
    {
        private readonly IItemService itemService;
        private readonly ICustomerService customerService;
        private readonly IBillService billService;

        public BillsController(IItemService itemService, ICustomerService customerService, IBillService billService)
        {
            this.itemService = itemService;
            this.customerService = customerService;
            this.billService = billService;
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

        public async Task<IActionResult> SaveItems(BillViewModel vm)
        {
            Customer customer = new Customer();
            customer.Name = vm.CustomerName;
            await customerService.AddCustomer(customer);

            var billDetails = new List<BillDetails>();
            foreach (var item in vm.Items)
            {
                billDetails.Add(new BillDetails
                {
                    CustomerId = customer.Id,
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Price = item.ItemPrice,
                    Discount = item.ItemDiscount,
                    Quantity = item.ItemQuantity,
                    Total = item.ItemTotal
                });
            }

            await billService.AddBillDetails(billDetails);

            var bill = new Bill();
            bill.CustomerId = customer.Id;
            bill.BillDate = DateTime.UtcNow;
            bill.TotalAmount = vm.GrandTotal;

            await billService.AddBill(bill);

            var billReceiptVm = new BillReceiptViewModel()
            {
                BillNumber = bill.Id,
                BillDetails = billDetails,
                CustomerName = vm.CustomerName,
                TotalAmount = vm.GrandTotal,
                FromAddress = "MyRestaurant",
            };

            return PartialView("_bill", billReceiptVm);
        }
    }
}