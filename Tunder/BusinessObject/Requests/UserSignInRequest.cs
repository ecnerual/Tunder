using System.ComponentModel.DataAnnotations;

namespace tunder.BusinessObject.Requests
{
    public class UserSignInRequest
    {
        [Required] public string Name { get; set; }
    }
}