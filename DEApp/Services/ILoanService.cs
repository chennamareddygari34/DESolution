using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface ILoanService
    {
        public List<LoanResponseDTO> GetAllLoans();
        public LoanResponseDTO GetLoanById(int loanId);
        public LoanResponseDTO AddLoan(LoanRequestDTO loanRequestDTO);
        public LoanResponseDTO UpdateLoan(int loanId, LoanRequestDTO loanRequestDTO);
        public LoanResponseDTO DeleteLoanById(int loanId);
    }
}
