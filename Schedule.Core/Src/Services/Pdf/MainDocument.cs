using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Schedule.Core.Data.Models;
using Schedule.Core.Data.Models.Pdf;
using Schedule.Core.Interfaces.Services;

namespace Schedule.Core.Services.Pdf;

public class MainDocument : IDocument, IPdfBuilder
{
    private IEnumerable<RouteItem> _routes;
    private const string AccentColor = "#2E8C81";

    public DocumentMetadata GetMetadata()
    {
        return new DocumentMetadata
        {
            Author = "Ivan Gagarin",
            Creator = "Ivan Gagarin",
            CreationDate = DateTime.Now,
            Title = $"Расписание общественного транспорта в городе Белая Калитва по маршруту №{_routes.First().RouteName}"
        };
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(20);
            
            page.Header().Element(HeaderElement);
            page.Content().Element(ContentElement);
        });
    }

    private void ContentElement(IContainer obj)
    {
        obj.Column(descriptor =>
        {
            descriptor.Item().Text(text =>
            {
                text.AlignCenter();
                text.DefaultTextStyle(TextStyle.Default.FontSize(32));
                text.Span("Будни");
            });
            
            descriptor.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    TextStyle style = TextStyle.Default.FontSize(20);

                    header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Откуда").Style(style);
                    header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Куда").Style(style);
                    header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Когда").Style(style);
                    header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Примечание").Style(style);
                });


                TextStyle cellStyle = TextStyle.Default.FontSize(16);
                List<RouteItem> workdayRoutes = _routes.Where(item => !item.IsSpecialDay).ToList();
                CreateScheduleBody(table, cellStyle, workdayRoutes);
            });

            List<RouteItem> specialRoutes = _routes.Where(item => item.IsSpecialDay).ToList();
            if (specialRoutes.Any())
            {
                descriptor.Item().Text(text =>
                {
                    text.AlignCenter();
                    text.DefaultTextStyle(TextStyle.Default.FontSize(32));
                    text.Span("Выходные и праздники");
                });
                descriptor.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        TextStyle style = TextStyle.Default.FontSize(20);

                        header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Откуда").Style(style);
                        header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Куда").Style(style);
                        header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Когда").Style(style);
                        header.Cell().BorderBottom(3).BorderColor(AccentColor).Text("Примечание").Style(style);
                    });

                    TextStyle cellStyle = TextStyle.Default.FontSize(16);
                    CreateScheduleBody(table, cellStyle, specialRoutes);
                });
            }
        });
    }

    private void CreateScheduleBody(TableDescriptor table, TextStyle cellStyle, IEnumerable<RouteItem> routes)
    {
        var resultList = routes.ToList();
        for (int i = 0; i < resultList.Count; i++)
        {
            RouteItem routeItem = resultList[i];

            if (i % 2 == 0)
            {
                table.Cell().Background(Colors.Grey.Lighten1).Text(routeItem.From).Style(cellStyle);
                table.Cell().Background(Colors.Grey.Lighten1).Text(routeItem.To).Style(cellStyle);
                table.Cell().Background(Colors.Grey.Lighten1).Text(routeItem.DepartureTime).Style(cellStyle);
                table.Cell().Background(Colors.Grey.Lighten1).Text(routeItem.Note).Style(cellStyle);
            }
            else
            {
                table.Cell().Text(routeItem.From).Style(cellStyle);
                table.Cell().Text(routeItem.To).Style(cellStyle);
                table.Cell().Text(routeItem.DepartureTime).Style(cellStyle);
                table.Cell().Text(routeItem.Note).Style(cellStyle);
            }
        }
    }

    private void HeaderElement(IContainer headerContainer)
    {
        headerContainer.Row(rowHeader =>
        {
            rowHeader.RelativeItem()
                .Row(column =>
                {
                    column.Spacing(260);

                    column.AutoItem()
                        .Text("BGIT the Best")
                        .FontSize(32);

                    column.AutoItem()
                        .Text("№" + _routes.First().RouteName)
                        .FontColor(AccentColor)
                        .FontSize(24);
                });
        });
    }

    public byte[] BuildPdf(IEnumerable<RouteItem> routeItems)
    {
        _routes = routeItems;
        
        return this.GeneratePdf();
    }

    Metadata IPdfBuilder.GetMetadata()
    {
        return new Metadata
        {
            Author = "Ivan Gagarin",
            ChangeDate = DateTime.Now,
            Title = $"Расписание общественного транспорта в городе Белая Калитва по маршруту №{_routes.First().RouteName}"
        };
    }
}