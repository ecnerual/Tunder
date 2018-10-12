using System;
using System.ComponentModel.DataAnnotations;
using tunder.Model.Enums;

namespace tunder.BusinessObject.Requests
{
    public class UserDto
    {
        [Required] public string UserName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }
        
        [Required] public Sexes Sexe { get; set; }
    }
}