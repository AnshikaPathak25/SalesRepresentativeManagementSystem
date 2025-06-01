using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;

namespace BusinessLayer.IService
{
    public interface IUserBL
    {
        UserModel ValidateUser(LoginModel loginViewModel);
        string GenerateToken(UserModel userVM);
    }
}
