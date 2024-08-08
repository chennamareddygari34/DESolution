﻿using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface IApplicantService
    {
        List<ApplicationGridDTO> GetApplicantsByVendorId(int vendorId);
        List<ApplicationGridDTO> GetAllApplicants();
        public List<ApplicantDTO> GetAllApplicantByCreatedPersonData();
        public ApplicantDTO GetApplicantById(int ApplicantId);
        public ApplicantDTO AddApplicant(ApplicantDTO applicantDTO);
        public ApplicantDTO UpdateApplicant(ApplicantDTO applicantDTO);
        public ApplicantDTO DeleteApplicantById(int ApplicantId);
    }
}
