using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.IService;
using BusinessModels;
using DataAccessLayer.Entities;
using RepositoryLayer.IRepository;

namespace BusinessLayer.Service
{
    public class SalesRepBL : ISalesRepBL
    {
        private readonly ISalesRepRepository _salesRepRepository;

        public SalesRepBL(ISalesRepRepository salesRepRepository)
        {
            _salesRepRepository = salesRepRepository;
        }

        public bool AddSalesRep(SalesRepresentativeModel salesRepModel)
        {
            SalesRepresentativeEntity salesRep = new SalesRepresentativeEntity()
            {
                Name = salesRepModel.Name,
                RegionId = salesRepModel.RegionId,
                ProductId = salesRepModel.ProductId,
                Email = salesRepModel.Email,
                PlatformId = salesRepModel.PlatformId,
                PhoneNumber = salesRepModel.PhoneNumber
            };
            var isAdded = _salesRepRepository.Add(salesRep);

            return isAdded;
        }

        public IEnumerable<SalesRepresentativeModel> GetAllSaleReps()
        {
            var products = _salesRepRepository.GetAll();

            List<SalesRepresentativeModel> salesRepModel = new List<SalesRepresentativeModel>();
            foreach (var item in products)
            {
                salesRepModel.Add(new SalesRepresentativeModel()
                {
                    Name = item.Name,
                    Product = item.Product.ProductName,
                    Region = item.Region.Name,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Platform = item.Platform.Name,
                    ProductId = item.ProductId,
                    RegionId = item.RegionId,
                    PlatformId = item.PlatformId,
                    SalesRepId = item.SalesRepId

                });
            }

            return salesRepModel;
        }

        public SalesRepresentativeModel GetSaleRepById(int id)
        {
            var salesRep = _salesRepRepository.GetSaleRepById(id);
            if (salesRep != null)
            {
                SalesRepresentativeModel salesRepModel = new()
                {
                    Name = salesRep.Name,
                    ProductId = salesRep.ProductId,
                    Product = salesRep.Product.ProductName,
                    RegionId = salesRep.RegionId,
                    Email = salesRep.Email,
                    PhoneNumber = salesRep.PhoneNumber,
                    Platform = salesRep.Platform.Name,
                    PlatformId = salesRep.PlatformId,
                    SalesRepId = salesRep.SalesRepId
                };

                return salesRepModel;
            }
            return null;
        }

        public bool RemoveSalesRep(int id)
        {
            var isDeleted = _salesRepRepository.Delete(id);
            return isDeleted;
        }

        public bool UpdateSalesRep(SalesRepresentativeModel salesRep)
        {
            SalesRepresentativeEntity salesRepToUpdate = new SalesRepresentativeEntity()
            {
                SalesRepId = salesRep.SalesRepId,
                Name = salesRep.Name,
                ProductId = salesRep.ProductId,
                RegionId = salesRep.RegionId,
                PlatformId = salesRep.PlatformId,
                Email = salesRep.Email,
                PhoneNumber = salesRep.PhoneNumber

            };
            var isUpdated = _salesRepRepository.Update(salesRepToUpdate);

            return isUpdated;
        }
    }
}
