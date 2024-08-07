using System.Collections.Generic;
using DEApp.Models.DTOs;
using DEApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet("vendor/{vendorId}")]
        public ActionResult<List<ApplicationGridDTO>> GetApplicantsByVendorId(int vendorId)
        {
            var applicants = _applicantService.GetApplicantsByVendorId(vendorId);
            if (applicants == null || applicants.Count == 0)
            {
                return NotFound();
            }

            return Ok(applicants);
        }
        [HttpGet("GetAll")]
        public ActionResult<List<ApplicationGridDTO>> GetAllApplicants()
        {
            var applicants = _applicantService.GetAllApplicants();
            if (applicants == null || applicants.Count == 0)
            {
                return NoContent(); 
            }
            return Ok(applicants); 
        }
    }
}
