using asp_mvc_sample_with_course_udemi.Models;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public interface IBillService
    {
        Task AddBillDetails(List<BillDetails> details);

        Task AddBill(Bill bill);
    }
}
