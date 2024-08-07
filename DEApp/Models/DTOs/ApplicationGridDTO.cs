namespace DEApp.Models.DTOs
{
    public class ApplicationGridDTO
    {
        public int ApplicantId { get; set; }

        public int VendorId { get; set; }

        public string Applicant1 { get; set; }
        public DateTime? ApplicantDate { get; set; }

        public string? Status { get; set; }

        public DateTime? LastUpdate { get; set; }
        public int? Year { get; set; }

        public string? Model { get; set; }

        public string? Make { get; set; }
    }
}
