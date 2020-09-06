using System.Collections.Generic;

namespace FootballLeague.Models.MatchesVM
{
    public class MatchIndexViewMode
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }

        public int? PreviousPage { get; set; }
        public int? NextPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
