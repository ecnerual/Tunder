using Data.Model.Enums;

namespace Data.Model
{
    public class Match
    {
        public User First { get; set; }
        public User Second { get; set; }
        public MatchStatus Status { get; set; }
        
    }
}