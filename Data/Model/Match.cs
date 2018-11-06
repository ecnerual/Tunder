using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Match : ModelBase
    {
        public ICollection<UserMatch> MatchesUsers { get; set; }
        public DateTime MatchedSince { get; set; }

        public Match()
        {
            MatchedSince = DateTime.UtcNow;
        }
    }
}
