using System.ComponentModel.DataAnnotations;

namespace tunder.BusinessObject.Requests
{
    public class User
    {
        [Required] public string UserName { get; set; }
        public string Email { get; set; }
    }
}