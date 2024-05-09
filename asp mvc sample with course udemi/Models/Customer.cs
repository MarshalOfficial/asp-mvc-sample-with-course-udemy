namespace asp_mvc_sample_with_course_udemi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}