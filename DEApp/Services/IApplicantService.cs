using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface IApplicantService
    {
        List<ApplicationGridDTO> GetApplicantsByVendorId(int vendorId);
    }
}
