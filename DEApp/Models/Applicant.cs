using System;
using System.Collections.Generic;

namespace DEApp.Models;

public partial class Applicant
{
    public int ApplicantId { get; set; }

    public int VendorId { get; set; }

    public string? Applicant1 { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Vendor? Vendor { get; set; }
}
