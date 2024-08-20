using DEApp.Interfaces;
using DEApp.Models.DTOs;
using DEApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileSettingController : ControllerBase
    {
        private readonly IProfilesettingService _profileSettingService;

        public ProfileSettingController(IProfilesettingService profileSettingService)
        {
            _profileSettingService = profileSettingService;
        }

        [HttpGet("GetAllUserProfiles")]
        public ActionResult<List<ProfileSettingDTO>> GetAllUserProfiles()
        {
            var profiles = _profileSettingService.GetAllUserProfiles();
            if (profiles == null || profiles.Count == 0)
            {
                return NoContent();
            }
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public ActionResult<ProfileSettingDTO> GetUserProfileById(int id)
        {
            var profile = _profileSettingService.GetUserProfileById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public ActionResult<ProfileSettingDTO> AddUserProfile([FromBody] ProfileSettingDTO profileSettingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProfile = _profileSettingService.AddUserProfile(profileSettingDTO);
            return CreatedAtAction(nameof(GetUserProfileById), new { id = createdProfile.UserId }, createdProfile);
        }

        [HttpPut("{id}")]
        public ActionResult<ProfileSettingDTO> UpdateUserProfile(int id, [FromBody] ProfileSettingDTO profileSettingDTO)
        {
            if (id != profileSettingDTO.UserId)
            {
                return BadRequest("ProfileSetting ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProfile = _profileSettingService.UpdateUserProfile(profileSettingDTO);
            if (updatedProfile == null)
            {
                return NotFound();
            }

            return Ok(updatedProfile);
        }

        [HttpDelete("{id}")]
        public ActionResult<ProfileSettingDTO> DeleteUserProfileById(int id)
        {
            var deletedProfile = _profileSettingService.DeleteUserProfileById(id);
            if (deletedProfile == null)
            {
                return NotFound();
            }

            return Ok(deletedProfile);
        }
    }
}
