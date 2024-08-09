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

        //By using this code for all Applicant


        [HttpPost]
        public ActionResult<ApplicantDTO> AddApplicant([FromBody] ApplicantDTO applicantDTO)
        {
            if (applicantDTO == null)
            {
                return BadRequest("Applicant data is null.");
            }

            var createdApplicant = _applicantService.AddApplicant(applicantDTO);
            return CreatedAtAction(nameof(GetApplicantById), new { id = createdApplicant.ApplicantId }, createdApplicant);
        }

        [HttpDelete("{id}")]
        public ActionResult<ApplicantDTO> DeleteApplicantById(int id)
        {
            var applicantDTO = _applicantService.DeleteApplicantById(id);
            if (applicantDTO == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(applicantDTO);
        }

       
        [HttpGet("{id}")]
        public ActionResult<ApplicantDTO> GetApplicantById(int id)
        {
            var applicantDTO = _applicantService.GetApplicantById(id);
            if (applicantDTO == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(applicantDTO);
        }

        [HttpPut("{id}")]
        public ActionResult<ApplicantDTO> UpdateApplicant(int id, [FromBody] ApplicantDTO applicantDTO)
        {
            if (applicantDTO == null || applicantDTO.ApplicantId != id)
            {
                return BadRequest("Applicant data is null or ID mismatch.");
            }

            var updatedApplicant = _applicantService.UpdateApplicant(applicantDTO);
            if (updatedApplicant == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(updatedApplicant);
        }

        [HttpGet("GetAllApplicantByCreatedPersonData")]
        public ActionResult<List<ApplicantDTO>> GetAllApplicantByCreatedPersonData()
        {
            var applicants = _applicantService.GetAllApplicantByCreatedPersonData();
            return Ok(applicants);
        }
        [HttpPut("UpdateApplication/{applicantId}/{vendorId}")]
        public IActionResult UpdateApplicationByUsingVendorId(int applicantId, int vendorId)
        {
            try
            {
                var updatedApplication = _applicantService.UpdateApplicationByUsingVendorId(applicantId, vendorId);
                return Ok(updatedApplication);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }

}
