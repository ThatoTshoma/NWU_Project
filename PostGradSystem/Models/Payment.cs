namespace PostGradSystem.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal OutstandingBalance{ get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }

    }
}
