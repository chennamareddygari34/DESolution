using System.Collections.Generic;
using System.Linq;
using DEApp.Models.DTOs;
using DEApp.Repositories;

namespace DEApp.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        //public List<ApplicationGridDTO> GetApplicantsByVendorId(int vendorId)
        //{
        //    var applicants = _applicantRepository.GetApplicantsByVendorId(vendorId);
        //    return applicants.Select(a => new ApplicationGridDTO
        //    {
        //        ApplicantId = a.ApplicantId,
        //        VendorId = a.VendorId,
        //        Applicant1 = a.Applicant1,
        //        //ApplicantDate = a.ApplicantDate,
        //        //Status = a.Status,
        //        //LastUpdate = a.LastUpdate,
        //        Year = a.Vendor.Year,
        //        Model = a.Vendor.Model,
        //        Make = a.Vendor.Make
        //    }).ToList();
        //}

        public List<ApplicationGridDTO> GetApplicantsByVendorId(int vendorId)
        {
            var applicants = _applicantRepository.GetApplicantsByVendorId(vendorId);
            return applicants.Select(a => new ApplicationGridDTO
            {
                ApplicantId = a.ApplicantId,
                VendorId = a.VendorId,
                Applicant1 = a.Applicant1,
                Year = a.Vendor.Year,
                Model = a.Vendor.Model,
                Make = a.Vendor.Make,
                ApplicantDate = a.Loans.FirstOrDefault()?.ApplicantDate,
                Status = a.Loans.FirstOrDefault()?.Status,
                LastUpdate = a.Loans.FirstOrDefault()?.LastUpdate
            }).ToList();
        }

    }
}
