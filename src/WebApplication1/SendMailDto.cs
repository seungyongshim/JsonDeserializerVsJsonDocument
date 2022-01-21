namespace WebApplication1;

public record SendMailDto(MailAddress From,
                          IReadOnlyCollection<MailAddress>? To,
                          IReadOnlyCollection<MailAddress>? Cc,
                          string Body,
                          IReadOnlyCollection<Attachment?>? Attachments);

public record MailAddress(string Name, string Address);

public record Attachment(string Id, byte[] Data);

public partial class Program { }
