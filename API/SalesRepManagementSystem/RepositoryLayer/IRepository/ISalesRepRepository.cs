using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace RepositoryLayer.IRepository
{
    public interface ISalesRepRepository
    {
        bool Add(SalesRepresentativeEntity salesRep);

        bool Update(SalesRepresentativeEntity salesRep);

        bool Delete(int salesRepId);

        IEnumerable<SalesRepresentativeEntity> GetAll();

        SalesRepresentativeEntity GetSaleRepById(int salesRepId);

    }
}
