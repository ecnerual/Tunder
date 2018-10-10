using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tunder.Model;

namespace tunder.Services
{
    public interface IAuthService
    {
        Task<User> Register(); 
      
    }
}
