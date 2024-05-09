using asp_mvc_sample_with_course_udemi.Models;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public interface ICustomerService
    {
        Task AddCustomer(Customer customer);
    }
}
