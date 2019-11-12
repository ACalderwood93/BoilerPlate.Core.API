using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(AuthenticateModel model);
    }
}
