using Data.Model.Enums;

namespace Data.Model
{
    public class Match
    {
        public long FirstUserId { get; set; }
        public User First { get; set; }

        public long SecondUserId { get; set; }
        public User Second { get; set; }

        public MatchStatus Status { get; set; }
    }
}