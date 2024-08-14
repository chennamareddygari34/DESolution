using DEApp.Models;
using System.Collections.Generic;

namespace DEApp.Repositories
{
    public interface IApplicantRepository : IRepository<int, Applicant>
    {
        IEnumerable<Applicant> GetApplicantsByVendorId(int vendorId);
        List<Applicant> GetAllApplicants();
        public IEnumerable<Applicant> GetApplicantsByGridUsingIDandName(int applicantId, string applicant1);
    }
}
