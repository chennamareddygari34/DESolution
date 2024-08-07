using System;
using System.Collections.Generic;

namespace DEApp.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int? Year { get; set; }

    public string? Model { get; set; }

    public string? Make { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();
}
