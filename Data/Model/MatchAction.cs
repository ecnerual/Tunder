using Data.Model.Enums;

namespace Data.Model
{
    public class MatchAction
    {
        public long LikerID { get; set; }
        public virtual User Liker { get; set; }

        public long LikedID { get; set; }
        public virtual User Liked { get; set; }

        public MatchActionStatus Status { get; set; }
    }
}