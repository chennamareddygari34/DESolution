using System;
using System.Collections.Generic;

namespace DEApp.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int ApplicantId { get; set; }

    public decimal? LoanAmount { get; set; }

    public DateTime? ApplicantDate { get; set; }

    public string? Status { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual Applicant? Applicant { get; set; }
}
