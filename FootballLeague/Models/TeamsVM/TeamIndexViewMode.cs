using System.Collections.Generic;

namespace FootballLeague.Models.TeamsVM
{
    public class TeamIndexViewMode
    {
        public IEnumerable<TeamViewModel> Teams { get; set; }

        public int? PreviousPage { get; set; }
        public int? NextPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
