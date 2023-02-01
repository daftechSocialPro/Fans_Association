namespace tmretApi.Services
{
    public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}
}