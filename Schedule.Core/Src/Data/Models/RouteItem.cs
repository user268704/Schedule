namespace Schedule.Data.Models
{
    public class RouteItem : IEquatable<RouteItem>
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

        public override bool Equals(object? obj)
        {
            if (obj is not RouteItem)
                throw new InvalidCastException();

            var equaler = (RouteItem)obj;

            return equaler.IsSpecialDay == IsSpecialDay &&
                   equaler.From == From &&
                   equaler.Id == Id &&
                   equaler.To == To &&
                   equaler.Note == Note &&
                   equaler.DepartureTime == DepartureTime &&
                   equaler.RouteName == RouteName;
        }
    }
}