using Newtonsoft.Json;
using System;
using Data.BusinessObject.Requests;
using Data.Model;
using Data.Model.Enums;

namespace Data.Model
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public Sexes Sex { get; set; }
        public string Email { get; set; }
        public DateTime BirthDateTime { get; set; }
        [JsonIgnore]
        public byte[] HashedPassword { get; set; }
        [JsonIgnore]
        public byte[] Salt { get; set; }
        [JsonIgnore]
        public string AuthToken { get; set; }
        [JsonIgnore]
        public bool IsActivited { get; set; }
        [JsonIgnore]
        public string ActivationToken { get; set; }

        public static User From(UserRegisterDto userDto, byte[] hashedPassword, byte[] salt)
        {
            return new User()
            {
                Name = userDto.UserName,
                Sex = userDto.Sexe,
                Email = userDto.Email.ToLower(),
                HashedPassword = hashedPassword,
                Salt = salt
            };
        }
    }
}