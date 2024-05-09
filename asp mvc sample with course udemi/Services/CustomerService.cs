using asp_mvc_sample_with_course_udemi.Data;
using asp_mvc_sample_with_course_udemi.Models;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }
    }
}