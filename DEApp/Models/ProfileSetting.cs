using System;
using System.Collections.Generic;

namespace DEApp.Models;

public partial class ProfileSetting
{
    public int ProfileSettingId { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Role { get; set; } = null!;
}
