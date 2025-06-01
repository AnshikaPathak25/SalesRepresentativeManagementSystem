using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;

namespace RepositoryLayer.Repository
{
    public class SalesRepRepository : ISalesRepRepository
    {
        private readonly SalesRepDbContext _context;

        public SalesRepRepository(SalesRepDbContext context)
        {
            _context = context;
        }
        public bool Add(SalesRepresentativeEntity salesRep)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.SalesRepresentatives.Add(salesRep);
                var rowsAffected = _context.SaveChanges();//open connection, generate script, execute script, fetch latest id, close connection
                _context.Database.CommitTransaction();
                return (rowsAffected > 0);
            }
            catch (Exception e)
            {
                _context.Database.RollbackTransaction();
                return false;
            }
        }

        public bool Delete(int salesRepId)
        {
            var rowsAffected = _context.SalesRepresentatives.Where(d => d.SalesRepId == salesRepId).ExecuteDelete();
            _context.SaveChanges();
            return (rowsAffected > 0);
        }

        public IEnumerable<SalesRepresentativeEntity> GetAll()
        {
            var salesReps = _context.SalesRepresentatives.Include(p => p.Product).
                Include(p => p.Platform).
                Include(p => p.Region)
                .Where(sr => sr.SalesRepId > 0).ToList();
            return salesReps;
        }

        public SalesRepresentativeEntity GetSaleRepById(int salesRepId)
        {
            var salesRep = _context.SalesRepresentatives.Where(sr => sr.SalesRepId == salesRepId).FirstOrDefault();
            return salesRep;
        }

        public bool Update(SalesRepresentativeEntity salesRep)
        {
            _context.Entry<SalesRepresentativeEntity>(salesRep).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
