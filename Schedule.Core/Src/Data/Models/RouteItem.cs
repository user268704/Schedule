namespace Schedule.Core.Data.Models
{
    public sealed class RouteItem : IEquatable<RouteItem>
    {
        public int Id { get; set; }
        public string RouteName { get; set; } = null!;
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public string? Note { get; set; }
        public bool IsSpecialDay { get; set; }
        public TimeOnly? DepartureTime { get; set; }

        public bool Equals(RouteItem? other)
        {
            return other != null &&
                   other.IsSpecialDay == IsSpecialDay &&
                   other.From == From &&
                   other.Id == Id &&
                   other.To == To && 
                   other.Note == Note &&
                   other.DepartureTime == DepartureTime &&
                   other.RouteName == RouteName;
        }
    }
}