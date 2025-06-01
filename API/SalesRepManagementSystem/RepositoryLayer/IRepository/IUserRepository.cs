using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace RepositoryLayer.IRepository
{
    public interface IUserRepository
    {
        UserEntity ValidateUser(string email, string pwd);
    }
}
