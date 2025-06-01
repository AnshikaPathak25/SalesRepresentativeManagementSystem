using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;

namespace BusinessLayer.IService
{
    public interface ISalesRepBL
    {
        IEnumerable<SalesRepresentativeModel> GetAllSaleReps();

        bool AddSalesRep(SalesRepresentativeModel salesRep);

        bool UpdateSalesRep(SalesRepresentativeModel salesRep);

        SalesRepresentativeModel GetSaleRepById(int id);

        bool RemoveSalesRep(int id);
    }
}
