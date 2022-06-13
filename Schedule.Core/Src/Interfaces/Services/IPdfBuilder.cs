using QuestPDF.Infrastructure;
using Schedule.Core.Data.Models;
using Schedule.Core.Data.Models.Pdf;

namespace Schedule.Core.Interfaces.Services;

public interface IPdfBuilder
{
    byte[] BuildPdf(IEnumerable<RouteItem> items);
    Metadata GetMetadata();
}