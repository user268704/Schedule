using System;
using System.Collections.Generic;

namespace Schedule
{
    public partial class Route
    {
        public int Id { get; set; }
        public int RouteNumber { get; set; }
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public DateTime DepartureTime { get; set; }
        public string? Note { get; set; }
    }
}
