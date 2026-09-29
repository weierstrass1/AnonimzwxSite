using AnonimzwxSite.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AnonimzwxSite.Services;

/// <summary>Sends the contact form to your inbox. Reply-To is the visitor's email, so "Reply" answers them.</summary>
public class ContactMailer(IOptions<SmtpOptions> options, ILogger<ContactMailer> logger)
{
    public async Task SendAsync(ContactMessage m, CancellationToken ct = default)
    {
        var o = options.Value;
        if (string.IsNullOrWhiteSpace(o.Host) || string.IsNullOrWhiteSpace(o.User) || string.IsNullOrWhiteSpace(o.Password))
            throw new InvalidOperationException("SMTP is not configured (Smtp:Host / User / Password).");

        var to = string.IsNullOrWhiteSpace(o.To) ? o.User : o.To;
        var from = string.IsNullOrWhiteSpace(o.FromAddress) ? o.User : o.FromAddress!;

        var msg = new MimeMessage();
        msg.From.Add(new MailboxAddress("anonimzwx website", from));
        msg.To.Add(MailboxAddress.Parse(to));
        msg.ReplyTo.Add(new MailboxAddress(m.Name, m.Email));
        msg.Subject = Clean($"[{m.Interest}] {m.Name}");
        msg.Body = new TextPart("plain")
        {
            Text =
                $"Name: {m.Name}\n" +
                $"Email: {m.Email}\n" +
                $"Discord: {(string.IsNullOrWhiteSpace(m.Discord) ? "-" : m.Discord)}\n" +
                $"Interest: {m.Interest}\n\n" +
                $"{m.Message}\n"
        };

        try
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(o.Host, o.Port,
                o.UseStartTls ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto, ct);
            await client.AuthenticateAsync(o.User, o.Password, ct);
            await client.SendAsync(msg, ct);
            await client.DisconnectAsync(true, ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to send contact email.");
            throw;
        }
    }

    private static string Clean(string s) => s.Replace('\r', ' ').Replace('\n', ' ');
}
