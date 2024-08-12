using DEApp.Models.DTOs;
using DEApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("GetAllLoans")]
        public ActionResult<List<LoanResponseDTO>> GetAllLoans()
        {
            var loans = _loanService.GetAllLoans();
            return Ok(loans);
        }

        [HttpGet("{loanId}")]
        public ActionResult<LoanResponseDTO> GetLoanById(int loanId)
        {
            var loan = _loanService.GetLoanById(loanId);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPost("NewApplication")]
        public ActionResult<LoanResponseDTO> AddLoan(LoanRequestDTO loanRequestDTO)
        {
            var loan = _loanService.AddLoan(loanRequestDTO);
            return CreatedAtAction(nameof(GetLoanById), new { loanId = loan.LoanId }, loan);
        }

        [HttpPut("{loanId}")]
        public ActionResult<LoanResponseDTO> UpdateLoan(int loanId, LoanRequestDTO loanRequestDTO)
        {
            var loan = _loanService.UpdateLoan(loanId, loanRequestDTO);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpDelete("{loanId}")]
        public ActionResult<LoanResponseDTO> DeleteLoanById(int loanId)
        {
            var loan = _loanService.DeleteLoanById(loanId);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }
    }
}
