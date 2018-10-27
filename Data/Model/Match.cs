using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Match : ModelBase
    {
        public ICollection<User> MatchesUsers { get; set; }
    }
}
