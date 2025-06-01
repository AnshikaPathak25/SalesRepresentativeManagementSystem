using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.IService;
using BusinessModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserBL(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public UserModel ValidateUser(LoginModel loginViewModel)
        {
            var userExist = _userRepository.ValidateUser(loginViewModel.EmailId, loginViewModel.Password);
            if (userExist != null)
            {
                UserModel userViewModel = new UserModel
                {
                    UserId = userExist.UserId,
                    EmailId = userExist.EmailId,
                    FullName = userExist.FullName,
                    Role = userExist.Role
                };
                return userViewModel;
            }
            return null;

    }

    public string GenerateToken(UserModel userVM)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? "");

        var claims = new[]
        {
                new Claim(ClaimTypes.Name, userVM.FullName),
                new Claim(ClaimTypes.Email, userVM.EmailId),
                new Claim(ClaimTypes.Role, userVM.Role)
            };

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        //parameters to generate the token
        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(5),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
}