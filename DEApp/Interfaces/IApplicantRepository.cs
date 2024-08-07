using DEApp.Models;
using System.Collections.Generic;

namespace DEApp.Repositories
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        IEnumerable<Applicant> GetApplicantsByVendorId(int vendorId);
    }
}
