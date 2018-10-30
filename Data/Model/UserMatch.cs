using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class UserMatch
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long MatchId { get; set; }
        public Match Match { get; set; }
    }
}
