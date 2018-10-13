using System;
using tunder.BusinessObject.Requests;
using tunder.Model.Enums;

namespace tunder.Model
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public Sexes Sex { get; set; }
        public string Email { get; set; }
        public DateTime BirthDateTime { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }


        public static User From(UserDto userDto, byte[] hashedPassword, byte[] salt)
        {
            return new User()
            {
                Name = userDto.UserName,
                Sex = userDto.Sexe,
                Email = userDto.Email,
                HashedPassword = hashedPassword,
                Salt = salt
            };
        }
    }
}