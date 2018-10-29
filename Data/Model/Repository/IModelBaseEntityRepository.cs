﻿using System;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public interface IModelBaseEntityRepository
    {
        
        Task<User> GetById(long id);
        Task<User> GetByGuidAsync(Guid guid);
    }
}