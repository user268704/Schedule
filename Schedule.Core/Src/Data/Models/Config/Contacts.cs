namespace Schedule.Core.Data.Models.Config;

public class Contacts
{
    public const string SectionName = "Contacts";
    
    public string Mail { get; set; }
    public string GitHub { get; set; }
    public string Twitter { get; set; }
    public string Telegram { get; set; }
}