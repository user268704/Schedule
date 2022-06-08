using System.Net.Mail;
using System.Text;

namespace Schedule.Services.Mail;

public class MailBuilder
{
    private string _mailTo;
    private string _mailFrom;
    private string _userName;

    private string _message;
    
    public MailBuilder(string mailTo)
    {
        _mailTo = mailTo;
    }

    public MailBuilder SetUserName(string name)
    {
        _userName = name;

        return this;
    }

    public MailBuilder SetMessage(string message)
    {
        _message = message;

        return this;
    }

    public MailBuilder From(string mail)
    {
        _mailFrom = mail;

        return this;
    }

    public MailMessage Build()
    {
        if (string.IsNullOrEmpty(_message) ||
            string.IsNullOrEmpty(_mailTo) ||
            string.IsNullOrEmpty(_userName) ||
            string.IsNullOrEmpty(_mailFrom))
        {
            throw new InvalidDataException("Введенные данные не валидны");
        }
        
        string messageHtml =
            "<h1 style='text-align: center'>Внимание, новая жалоба на сайт!</h1>\n<p>Он просил себя называть <h4>${_userName}</h4></p>\n<p>А вот это он сказал передать</p> \n<p style='font-size: 20px; color: #314544'>\n    ${_message}\n</p>\n<p>Если надо жестко ответить, пиши сюда <a href='mailto:${_mailFrom}'></a></p>";
        
        MailMessage result = new()
        {
            Body = messageHtml,
            IsBodyHtml = true,
            From = new MailAddress(_mailFrom),
            To = { new MailAddress(_mailTo) },
        };

        return result;
    }
}