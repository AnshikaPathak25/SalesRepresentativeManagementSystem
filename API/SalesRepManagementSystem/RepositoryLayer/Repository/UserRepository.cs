using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using RepositoryLayer.IRepository;

namespace RepositoryLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesRepDbContext _context;

        public UserRepository(SalesRepDbContext context)
        {
            _context = context;
        }

        public UserEntity ValidateUser(string email, string pwd)
        {
            var user = _context.Users
                .Where(
                d => d.EmailId.ToLower() == email.ToLower()
                && d.Password == pwd).FirstOrDefault();
            return user;
        }
    }
}
