﻿namespace asp_mvc_sample_with_course_udemi.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime BillDate { get; set; }

        public PaymentType PaymentType { get; set; }
    }

    public enum PaymentType
    {
        Cash,
        Card
    }
}
