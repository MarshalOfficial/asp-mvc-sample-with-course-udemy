using System.ComponentModel.DataAnnotations;

namespace asp_mvc_sample_with_course_udemi.Models
{
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required decimal Price { get; set; }
    }
}
