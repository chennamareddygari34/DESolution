namespace DEApp.Models.DTOs
{
    public class LoanResponseDTO
    {
        public int LoanId { get; set; } 

        public int? ApplicantId { get; set; } 

        public decimal? LoanAmount { get; set; } 

        public DateTime? ApplicantDate { get; set; } 

        public string Status { get; set; } 

        public DateTime? LastUpdate { get; set; } 

        public string LoanType { get; set; } 

        public string LoanDescription { get; set; } 

        public decimal? MaxLoanAmount { get; set; } 

        public int? LoanTerm { get; set; } 

        public decimal? InterestRate { get; set; } 

        public decimal? MonthlyPayment { get; set; }
    }
}
