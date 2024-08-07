using System;
using System.Collections.Generic;

namespace DEApp.Models;

public partial class Applicant
{
    public int ApplicantId { get; set; }

    public int VendorId { get; set; }

    public string Applicant1 { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    public string? OccupationType { get; set; }

    public string? HouseNo { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? State { get; set; }

    public string? Landmark { get; set; }

    public int? Pincode { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Vendor Vendor { get; set; } = null!;
}
