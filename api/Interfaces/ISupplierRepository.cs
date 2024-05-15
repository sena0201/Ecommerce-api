using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Supplier;
using api.Entity;
using api.Helpers;

namespace api.Interfaces
{
    public interface ISupplierRepository
    {
        public Task<List<Supplier>> GetAll();
        public Task<List<Supplier>> GetAll(SupplierQueryObject query);
        public Task<Supplier?> GetById(long supplierId);
        public Task<Supplier?> Create(Supplier supplier);
        public Task<Supplier?> Update(long supplierId, UpdateSupplierDto supplierDto);
        public Task<Supplier?> Delete(long supplierId);
        public int GetCount(SupplierQueryObject query);
    }
}