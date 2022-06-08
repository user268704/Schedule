using System.Net;
using System.Net.Mail;

namespace Schedule.Services.Mail;

public class MailClient
{
    private readonly SmtpClient _client;
    
    public MailClient()
    {
        _client = new SmtpClient("smtp.gmail.com", 587);
        _client.EnableSsl = true;
        _client.Credentials = new NetworkCredential("bkschedule61@gmail.com", "sTF-MZa-nGr-3s4");
    }
    
    public void SendMessage(MailMessage message)
    {
        _client.Send(message);
    }
}