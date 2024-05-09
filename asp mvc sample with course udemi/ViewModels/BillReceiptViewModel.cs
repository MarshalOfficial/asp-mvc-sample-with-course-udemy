using asp_mvc_sample_with_course_udemi.Models;

namespace asp_mvc_sample_with_course_udemi.ViewModels
{
    public class BillReceiptViewModel
    {
        public int BillNumber { get; set; }

        public string CustomerName { get; set; }

        public List<BillDetails> BillDetails { get; set; }

        public decimal TotalAmount { get; set; }

        public string FromAddress { get; set; }

    }
}
