using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public string AuthToken { get; set; }
        public string ActivationToken { get; set; }

        public ICollection<MatchAction> MatchActionsTo { get; set; }
        public ICollection<MatchAction> MatchActionsFrom { get; set; }

        public ICollection<UserMatch> Matches { get; set; }

        public static User From(UserRegisterDto userDto, byte[] hashedPassword, byte[] salt)
        {
            return new User()
            {
                Name = userDto.UserName,
                Sex = userDto.Sexe,
                Email = userDto.Email.ToLower(),
                HashedPassword = hashedPassword,
                Salt = salt,
                BirthDateTime = userDto.DateOfBirth
            };
        }
    }
}