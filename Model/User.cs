using tunder.Model.Enums;

namespace tunder.Model
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public Sexes Sex { get; set; }
    }
}