using asp_mvc_sample_with_course_udemi.Data;
using asp_mvc_sample_with_course_udemi.Models;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public class BillService : IBillService
    {
        private readonly ApplicationDbContext context;

        public BillService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddBillDetails(List<BillDetails> details)
        {
            context.BillDetails.AddRange(details);
            await context.SaveChangesAsync();
        }

        async Task IBillService.AddBill(Bill bill)
        {
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
        }
    }
}