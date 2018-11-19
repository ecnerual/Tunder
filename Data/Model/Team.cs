using System.Collections.Generic;

namespace Data.Model
{
    public class Team : ModelBase
    {
        public ICollection<UserTeam> UserTeams { get; set; }
        public string Name { get; set; }
    }
}