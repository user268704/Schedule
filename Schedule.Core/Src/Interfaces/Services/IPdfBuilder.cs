using QuestPDF.Infrastructure;
using Schedule.Data.Models;
using Schedule.Data.Models.Pdf;

namespace Schedule.Core.Interfaces.Services;

public interface IPdfBuilder
{
    byte[] BuildPdf(IEnumerable<RouteItem> items);
    Metadata GetMetadata();
}