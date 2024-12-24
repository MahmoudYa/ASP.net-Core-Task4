namespace REAL_Estate.Components.Mail;

public interface IMailClient
{
    Task SendAsync(String email, String subject, String body);
}
