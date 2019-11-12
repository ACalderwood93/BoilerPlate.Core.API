using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;

namespace WebAPI.Data.QueryClasses.Interfaces
{
    public interface IUserQueries
    {
        User GetUser(string username);
    }
}
