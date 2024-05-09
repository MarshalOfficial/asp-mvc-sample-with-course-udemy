using asp_mvc_sample_with_course_udemi.Models;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAll();

        Task<Item> GetById(int id);

        Task SaveItem(Item item);

        Task DeleteItem(int id);

        Task UpdateItem(Item item);
    }
}