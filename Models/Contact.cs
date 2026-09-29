using System.ComponentModel.DataAnnotations;

namespace AnonimzwxSite.Models;

public class ContactMessage
{
    public static readonly string[] Interests =
        ["Job offer", "Unity commission", "SNES commission", "Other"];

    [Required, StringLength(80)]
    public string Name { get; set; } = "";

    [Required, EmailAddress, StringLength(200)]
    public string Email { get; set; } = "";

    [StringLength(60)]
    public string? Discord { get; set; }

    [Required]
    public string Interest { get; set; } = Interests[1];

    [Required, StringLength(4000, MinimumLength = 10, ErrorMessage = "Please write at least a few words.")]
    public string Message { get; set; } = "";

    /// <summary>Honeypot: hidden field, bots fill it in.</summary>
    public string? Website { get; set; }
}

public class SmtpOptions
{
    public string Host { get; set; } = "";
    public int Port { get; set; } = 587;
    public bool UseStartTls { get; set; } = true;
    public string User { get; set; } = "";
    public string Password { get; set; } = "";
    /// <summary>Where contact emails are delivered.</summary>
    public string To { get; set; } = "";
    /// <summary>Optional. Defaults to User.</summary>
    public string? FromAddress { get; set; }
}
