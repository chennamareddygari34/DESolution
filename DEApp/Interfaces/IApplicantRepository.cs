using DEApp.Models;
using System.Collections.Generic;

namespace DEApp.Repositories
{
    public interface IApplicantRepository : IUserRepository<Applicant>
    {
        IEnumerable<Applicant> GetApplicantsByVendorId(int vendorId);
        List<Applicant> GetAllApplicants();
    }
}
