namespace DEApp.Models.DTOs
{
    public class LoanRequestDTO
    {
        public int? ApplicantId { get; set; } 

        public decimal LoanAmount { get; set; } 
        public string LoanType { get; set; } 
        public string LoanDescription { get; set; }
        public int LoanTerm { get; set; } 
        public decimal? InterestRate { get; set; } 

    }
}
