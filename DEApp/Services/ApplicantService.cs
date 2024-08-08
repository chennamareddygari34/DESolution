﻿using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using DEApp.Models;
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


        public List<ApplicationGridDTO> GetApplicantsByVendorId(int vendorId)
        {
            var applicants = _applicantRepository.GetApplicantsByVendorId(vendorId);
            return applicants.Select(a => new ApplicationGridDTO
            {
                ApplicantId = a.ApplicantId,
                VendorId = a.VendorId,
                VendorName = a.Vendor.VendorName,
                Applicant1 = a.Applicant1,
                Year = a.Vendor.Year,
                Model = a.Vendor.Model,
                Make = a.Vendor.Make,
                ApplicantDate = a.Loans.FirstOrDefault()?.ApplicantDate,
                Status = a.Loans.FirstOrDefault()?.Status,
                LastUpdate = a.Loans.FirstOrDefault()?.LastUpdate
            }).ToList();
        }

      
        public List<ApplicationGridDTO> GetAllApplicants()
        {
            var applicants = _applicantRepository.GetAllApplicants();
            return applicants.Select(a => new ApplicationGridDTO
            {
                ApplicantId = a.ApplicantId,
                VendorId = a.VendorId,
                VendorName = a.Vendor.VendorName,
                Applicant1 = a.Applicant1,
                Year = a.Vendor.Year,
                Model = a.Vendor.Model,
                Make = a.Vendor.Make,
                ApplicantDate = a.Loans.FirstOrDefault()?.ApplicantDate,
                Status = a.Loans.FirstOrDefault()?.Status,
                LastUpdate = a.Loans.FirstOrDefault()?.LastUpdate
            }).ToList();
        }

        public ApplicantDTO AddApplicant(ApplicantDTO applicantDTO)
        {
            var applicant = new Applicant
            {
                ApplicantId = applicantDTO.ApplicantId,
                Applicant1 = applicantDTO.Applicant1,
                Email = applicantDTO.Email,
                Phone = applicantDTO.Phone,
                DateOfBirth = applicantDTO.DateOfBirth,
                Gender = applicantDTO.Gender,
                MaritalStatus = applicantDTO.MaritalStatus,
                OccupationType= applicantDTO.OccupationType,
                HouseNo = applicantDTO.HouseNo,
                City = applicantDTO.City,
                District = applicantDTO.District,
                State = applicantDTO.State,
                Landmark = applicantDTO.Landmark,
                Pincode = applicantDTO.Pincode,
                Country = applicantDTO.Country

            };
            _applicantRepository.Add(applicant);
            return new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                Applicant1 = applicant.Applicant1,
                Email = applicant.Email,
                Phone = applicant.Phone,
                DateOfBirth = applicant.DateOfBirth,
                Gender = applicant.Gender,
                MaritalStatus = applicant.MaritalStatus,
                OccupationType = applicant.OccupationType,
                HouseNo = applicant.HouseNo,
                City = applicant.City,
                District = applicant.District,
                State = applicant.State,
                Landmark = applicant.Landmark,
                Pincode = applicant.Pincode,
                Country = applicant.Country
            };
        }

        public ApplicantDTO DeleteApplicantById(int applicantId)
        {
            var applicant = _applicantRepository.Get(applicantId);

            if (applicant == null)
            {
                
                return null; 
            }

            _applicantRepository.Delete(applicantId);
            var applicantDTO = new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                Applicant1 = applicant.Applicant1,
                Email = applicant.Email,
                Phone = applicant.Phone,
                DateOfBirth = applicant.DateOfBirth,
                Gender = applicant.Gender,
                MaritalStatus = applicant.MaritalStatus,
                OccupationType = applicant.OccupationType,
                HouseNo = applicant.HouseNo,
                City = applicant.City,
                District = applicant.District,
                State = applicant.State,
                Landmark = applicant.Landmark,
                Pincode = applicant.Pincode,
                Country = applicant.Country
            };

            return applicantDTO;
        }


      


        public ApplicantDTO GetApplicantById(int applicantId)
        {
            var applicant = _applicantRepository.Get(applicantId);

            if (applicant == null)
            {
                return null;
            }

            var applicantDTO = new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                Applicant1 = applicant.Applicant1,
                Email = applicant.Email,
                Phone = applicant.Phone,
                DateOfBirth = applicant.DateOfBirth,
                Gender = applicant.Gender,
                MaritalStatus = applicant.MaritalStatus,
                OccupationType = applicant.OccupationType,
                HouseNo = applicant.HouseNo,
                City = applicant.City,
                District = applicant.District,
                State = applicant.State,
                Landmark = applicant.Landmark,
                Pincode = applicant.Pincode,
                Country = applicant.Country
            };

            return applicantDTO;
        }


        public ApplicantDTO UpdateApplicant(ApplicantDTO applicantDTO)
        {
            var applicant = _applicantRepository.Get(applicantDTO.ApplicantId);

            if (applicant == null)
            {
                return null;
            }

            applicant.Applicant1 = applicantDTO.Applicant1;
            applicant.Email = applicantDTO.Email;
            applicant.Phone = applicantDTO.Phone;
            applicant.DateOfBirth = applicantDTO.DateOfBirth;
            applicant.Gender = applicantDTO.Gender;
            applicant.MaritalStatus = applicantDTO.MaritalStatus;
            applicant.OccupationType = applicantDTO.OccupationType;
            applicant.HouseNo = applicantDTO.HouseNo;
            applicant.City = applicantDTO.City;
            applicant.District = applicantDTO.District;
            applicant.State = applicantDTO.State;
            applicant.Landmark = applicantDTO.Landmark;
            applicant.Pincode = applicantDTO.Pincode;
            applicant.Country = applicantDTO.Country;

            _applicantRepository.Update(applicant);

            return new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                Applicant1 = applicant.Applicant1,
                Email = applicant.Email,
                Phone = applicant.Phone,
                DateOfBirth = applicant.DateOfBirth,
                Gender = applicant.Gender,
                MaritalStatus = applicant.MaritalStatus,
                OccupationType = applicant.OccupationType,
                HouseNo = applicant.HouseNo,
                City = applicant.City,
                District = applicant.District,
                State = applicant.State,
                Landmark = applicant.Landmark,
                Pincode = applicant.Pincode,
                Country = applicant.Country
            };
        }

        public List<ApplicantDTO> GetAllApplicantByCreatedPersonData()
        {
            var applicants = _applicantRepository.GetAll()
                                                 .Select(applicant => new ApplicantDTO
                                                 {
                                                     ApplicantId = applicant.ApplicantId,
                                                     Applicant1 = applicant.Applicant1,
                                                     Email = applicant.Email,
                                                     Phone = applicant.Phone,
                                                     DateOfBirth = applicant.DateOfBirth,
                                                     Gender = applicant.Gender,
                                                     MaritalStatus = applicant.MaritalStatus,
                                                     OccupationType = applicant.OccupationType,
                                                     HouseNo = applicant.HouseNo,
                                                     City = applicant.City,
                                                     District = applicant.District,
                                                     State = applicant.State,
                                                     Landmark = applicant.Landmark,
                                                     Pincode = applicant.Pincode,
                                                     Country = applicant.Country
                                                 }).ToList();

            return applicants;
        }
    }
}
