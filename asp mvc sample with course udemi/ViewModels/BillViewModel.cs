using asp_mvc_sample_with_course_udemi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace asp_mvc_sample_with_course_udemi.ViewModels
{
    public class BillViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public PaymentType PaymentType { get; set; }
        [Display(Name = "Items List")]
        public int ItemId { get; set; }
        //public List<SelectListItem> ItemList { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
    }
}