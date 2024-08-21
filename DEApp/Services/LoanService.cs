//using DEApp.Interfaces;
//using DEApp.Models;
//using DEApp.Models.DTOs;
//using DEApp.Repositories;
//using System;
//using System.Collections.Generic;

//namespace DEApp.Services
//{
//    public class LoanService : ILoanService
//    {
//        private readonly ILoanRepository<int, Loan> _loanRepository;

//        public LoanService(ILoanRepository<int, Loan> loanRepository)
//        {
//            _loanRepository = loanRepository;
//        }


//        public LoanResponseDTO DeleteLoanById(int loanId)
//        {
//            var loan = _loanRepository.Get(loanId);
//            if (loan == null)
//            {
//                return null;
//            }

//            _loanRepository.Delete(loanId);

//            return new LoanResponseDTO
//            {
//                LoanId = loan.LoanId,
//                ApplicantId = loan.ApplicantId,
//                LoanAmount = loan.LoanAmount,
//                LoanType = loan.LoanType,
//                LoanDescription = loan.LoanDescription,
//                MaxLoanAmount = loan.MaxLoanAmount, 
//                LoanTerm = loan.LoanTerm,
//                InterestRate = loan.InterestRate,
//                MonthlyPayment = loan.MonthlyPayment,
//                Status = loan.Status,
//                ApplicantDate = loan.ApplicantDate,
//                LastUpdate = loan.LastUpdate
//            };
//        }

//        public List<LoanResponseDTO> GetAllLoans()
//        {
//            var loans = _loanRepository.GetAll();

//            var loanDTOs = new List<LoanResponseDTO>();
//            foreach (var loan in loans)
//            {
//                loanDTOs.Add(new LoanResponseDTO
//                {
//                    LoanId = loan.LoanId,
//                    ApplicantId = loan.ApplicantId,
//                    LoanAmount = loan.LoanAmount,
//                    LoanType = loan.LoanType,
//                    LoanDescription = loan.LoanDescription,
//                    MaxLoanAmount = loan.MaxLoanAmount,
//                    LoanTerm = loan.LoanTerm,
//                    InterestRate = loan.InterestRate,
//                    MonthlyPayment = loan.MonthlyPayment,
//                    Status = loan.Status,
//                    ApplicantDate = loan.ApplicantDate,
//                    LastUpdate = loan.LastUpdate
//                });
//            }
//            return loanDTOs;
//        }

//        public LoanResponseDTO GetLoanById(int loanId)
//        {
//            var loan = _loanRepository.Get(loanId);
//            if (loan == null)
//            {
//                return null;
//            }

//            return new LoanResponseDTO
//            {
//                LoanId = loan.LoanId,
//                ApplicantId = loan.ApplicantId,
//                LoanAmount = loan.LoanAmount,
//                LoanType = loan.LoanType,
//                LoanDescription = loan.LoanDescription,
//                MaxLoanAmount = loan.MaxLoanAmount,
//                LoanTerm = loan.LoanTerm,
//                InterestRate = loan.InterestRate,
//                MonthlyPayment = loan.MonthlyPayment,
//                Status = loan.Status,
//                ApplicantDate = loan.ApplicantDate,
//                LastUpdate = loan.LastUpdate
//            };
//        }

//        public LoanResponseDTO UpdateLoan(int loanId, LoanRequestDTO loanRequestDTO)
//        {
//            var loan = _loanRepository.Get(loanId);
//            if (loan == null)
//            {
//                return null;
//            }

//            loan.LoanAmount = loanRequestDTO.LoanAmount;
//            loan.LoanType = loanRequestDTO.LoanType;
//            loan.LoanDescription = loanRequestDTO.LoanDescription;
//            loan.LoanTerm = loanRequestDTO.LoanTerm;
//            loan.InterestRate = loanRequestDTO.InterestRate;
//            loan.LastUpdate = DateTime.Now;

//            var updatedLoan = _loanRepository.Update(loan);

//            return new LoanResponseDTO
//            {
//                LoanId = updatedLoan.LoanId,
//                ApplicantId = updatedLoan.ApplicantId,
//                LoanAmount = updatedLoan.LoanAmount,
//                LoanType = updatedLoan.LoanType,
//                LoanDescription = updatedLoan.LoanDescription,
//                MaxLoanAmount = updatedLoan.MaxLoanAmount,
//                LoanTerm = updatedLoan.LoanTerm,
//                InterestRate = updatedLoan.InterestRate,
//                MonthlyPayment = updatedLoan.MonthlyPayment,
//                Status = updatedLoan.Status,
//                ApplicantDate = updatedLoan.ApplicantDate,
//                LastUpdate = updatedLoan.LastUpdate
//            };
//        }

//        public LoanResponseDTO AddLoan(LoanRequestDTO loanRequestDTO)
//        {
//            var maxLoanAmount = GetApplicantMaxLoanAmount(loanRequestDTO.ApplicantId);

//            if (loanRequestDTO.LoanAmount > maxLoanAmount)
//            {
//                throw new InvalidOperationException("Requested loan amount exceeds the maximum allowable loan amount for this applicant.");
//            }

//            var interestRate = CalculateInterestRate(loanRequestDTO.LoanAmount, loanRequestDTO.LoanTerm);
//            var monthlyPayment = CalculateMonthlyPayment(
//            loanRequestDTO.LoanAmount, 
//            interestRate,
//            loanRequestDTO.LoanTerm    
//            );

//            var loan = new Loan
//            {
//                ApplicantId = loanRequestDTO.ApplicantId,
//                LoanAmount = loanRequestDTO.LoanAmount,
//                LoanType = loanRequestDTO.LoanType,
//                LoanDescription = loanRequestDTO.LoanDescription,
//                LoanTerm = loanRequestDTO.LoanTerm,
//                InterestRate = interestRate,
//                MonthlyPayment = monthlyPayment,
//                Status = "Pending",
//                ApplicantDate = DateTime.Now,
//                LastUpdate = DateTime.Now
//            };

//            var addedLoan = _loanRepository.Add(loan);

//            return new LoanResponseDTO
//            {
//                LoanId = addedLoan.LoanId,
//                ApplicantId = addedLoan.ApplicantId,
//                LoanAmount = addedLoan.LoanAmount,
//                LoanType = addedLoan.LoanType,
//                LoanDescription = addedLoan.LoanDescription,
//                LoanTerm = addedLoan.LoanTerm,
//                InterestRate = addedLoan.InterestRate,
//                MonthlyPayment = addedLoan.MonthlyPayment, 
//                MaxLoanAmount = maxLoanAmount, 
//                Status = addedLoan.Status,
//                ApplicantDate = addedLoan.ApplicantDate,
//                LastUpdate = addedLoan.LastUpdate
//            };
//        }

//        private decimal GetApplicantMaxLoanAmount(int? applicantId)
//        {
//            return 2000000m; 
//        }

//        private decimal CalculateInterestRate(decimal? loanAmount, int? loanTerm)
//        {
//            return 0.16m; 
//        }

//        private decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int loanTerm)
//        {
//            var monthlyRate = interestRate / 12;

//            var denominator = Math.Pow((1 + (double)monthlyRate), loanTerm) - 1;
//            var monthlyPayment = loanAmount * monthlyRate * (decimal)Math.Pow((1 + (double)monthlyRate), loanTerm) / (decimal)denominator;

//            return monthlyPayment;
//        }


//    }
//}

using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Models.DTOs;
using DEApp.Repositories;
using System;
using System.Collections.Generic;

namespace DEApp.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository<int, Loan> _loanRepository;

        public LoanService(ILoanRepository<int, Loan> loanRepository)
        {
            _loanRepository = loanRepository;
        }


        public LoanResponseDTO DeleteLoanById(int loanId)
        {
            var loan = _loanRepository.Get(loanId);
            if (loan == null)
            {
                return null;
            }

            _loanRepository.Delete(loanId);

            return new LoanResponseDTO
            {
                LoanId = loan.LoanId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                LoanType = loan.LoanType,
                LoanDescription = loan.LoanDescription,
                MaxLoanAmount = loan.MaxLoanAmount,
                LoanTerm = loan.LoanTerm,
                InterestRate = loan.InterestRate,
                MonthlyPayment = loan.MonthlyPayment,
                Status = loan.Status,
                ApplicantDate = loan.ApplicantDate,
                LastUpdate = loan.LastUpdate
            };
        }

        public List<LoanResponseDTO> GetAllLoans()
        {
            var loans = _loanRepository.GetAll();
            var loanDTOs = new List<LoanResponseDTO>();

            foreach (var loan in loans)
            {
                var maxLoanAmount = GetApplicantMaxLoanAmount(loan.ApplicantId);

                loanDTOs.Add(new LoanResponseDTO
                {
                    LoanId = loan.LoanId,
                    ApplicantId = loan.ApplicantId,
                    LoanAmount = loan.LoanAmount,
                    LoanType = loan.LoanType,
                    LoanDescription = loan.LoanDescription,
                    MaxLoanAmount = maxLoanAmount,
                    LoanTerm = loan.LoanTerm,
                    InterestRate = loan.InterestRate,
                    MonthlyPayment = loan.MonthlyPayment,
                    Status = loan.Status,
                    ApplicantDate = loan.ApplicantDate,
                    LastUpdate = loan.LastUpdate
                });
            }

            return loanDTOs;
        }


        public LoanResponseDTO GetLoanById(int loanId)
        {
            var loan = _loanRepository.Get(loanId);
            if (loan == null)
            {
                return null;
            }

            var maxLoanAmount = GetApplicantMaxLoanAmount(loan.ApplicantId);

            return new LoanResponseDTO
            {
                LoanId = loan.LoanId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                LoanType = loan.LoanType,
                LoanDescription = loan.LoanDescription,
                MaxLoanAmount = maxLoanAmount,
                LoanTerm = loan.LoanTerm,
                InterestRate = loan.InterestRate,
                MonthlyPayment = loan.MonthlyPayment,
                Status = loan.Status,
                ApplicantDate = loan.ApplicantDate,
                LastUpdate = loan.LastUpdate
            };
        }


        public LoanResponseDTO UpdateLoan(int loanId, LoanRequestDTO loanRequestDTO)
        {
            var loan = _loanRepository.Get(loanId);
            if (loan == null)
            {
                return null;
            }

            loan.LoanAmount = loanRequestDTO.LoanAmount;
            loan.LoanType = loanRequestDTO.LoanType;
            loan.LoanDescription = loanRequestDTO.LoanDescription;
            loan.LoanTerm = loanRequestDTO.LoanTerm;
            loan.InterestRate = loanRequestDTO.InterestRate;
            loan.LastUpdate = DateTime.Now;

            var updatedLoan = _loanRepository.Update(loan);

            return new LoanResponseDTO
            {
                LoanId = updatedLoan.LoanId,
                ApplicantId = updatedLoan.ApplicantId,
                LoanAmount = updatedLoan.LoanAmount,
                LoanType = updatedLoan.LoanType,
                LoanDescription = updatedLoan.LoanDescription,
                MaxLoanAmount = updatedLoan.MaxLoanAmount,
                LoanTerm = updatedLoan.LoanTerm,
                InterestRate = updatedLoan.InterestRate,
                MonthlyPayment = updatedLoan.MonthlyPayment,
                Status = updatedLoan.Status,
                ApplicantDate = updatedLoan.ApplicantDate,
                LastUpdate = updatedLoan.LastUpdate
            };
        }

        public LoanResponseDTO AddLoan(LoanRequestDTO loanRequestDTO)
        {
            var maxLoanAmount = GetApplicantMaxLoanAmount(loanRequestDTO.ApplicantId);

            if (loanRequestDTO.LoanAmount > maxLoanAmount)
            {
                throw new InvalidOperationException("Requested loan amount exceeds the maximum allowable loan amount for this applicant.");
            }

            var interestRate = CalculateInterestRate(loanRequestDTO.LoanAmount, loanRequestDTO.LoanTerm);
            var monthlyPayment = CalculateMonthlyPayment(
            loanRequestDTO.LoanAmount,
            interestRate,
            loanRequestDTO.LoanTerm
            );

            var loan = new Loan
            {
                ApplicantId = loanRequestDTO.ApplicantId,
                LoanAmount = loanRequestDTO.LoanAmount,
                LoanType = loanRequestDTO.LoanType,
                LoanDescription = loanRequestDTO.LoanDescription,
                LoanTerm = loanRequestDTO.LoanTerm,
                InterestRate = interestRate,
                MonthlyPayment = monthlyPayment,
                Status = "Pending",
                ApplicantDate = DateTime.Now,
                LastUpdate = DateTime.Now
            };

            var addedLoan = _loanRepository.Add(loan);

            return new LoanResponseDTO
            {
                LoanId = addedLoan.LoanId,
                ApplicantId = addedLoan.ApplicantId,
                LoanAmount = addedLoan.LoanAmount,
                LoanType = addedLoan.LoanType,
                LoanDescription = addedLoan.LoanDescription,
                LoanTerm = addedLoan.LoanTerm,
                InterestRate = addedLoan.InterestRate,
                MonthlyPayment = addedLoan.MonthlyPayment,
                MaxLoanAmount = maxLoanAmount,
                Status = addedLoan.Status,
                ApplicantDate = addedLoan.ApplicantDate,
                LastUpdate = addedLoan.LastUpdate
            };
        }

        private decimal GetApplicantMaxLoanAmount(int? applicantId)
        {
            return 2000000m;
        }

        private decimal CalculateInterestRate(decimal? loanAmount, int? loanTerm)
        {
            return 0.16m;
        }

        private decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int loanTerm)
        {
            var monthlyRate = interestRate / 12;

            var denominator = Math.Pow((1 + (double)monthlyRate), loanTerm) - 1;
            var monthlyPayment = loanAmount * monthlyRate * (decimal)Math.Pow((1 + (double)monthlyRate), loanTerm) / (decimal)denominator;

            return monthlyPayment;
        }


    }
}