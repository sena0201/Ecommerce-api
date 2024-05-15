using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Supplier;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _context;
        public SupplierRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Supplier?> Create(Supplier supplier)
        {
            var s = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierName == supplier.SupplierName);
            if (s != null)
            {
                return null;
            }
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier?> Delete(long supplierId)
        {
            var s = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == supplierId);
            if (s == null)
            {
                return null;
            }
            _context.Suppliers.Remove(s);
            await _context.SaveChangesAsync();
            return s;
        }

        public async Task<List<Supplier>> GetAll(SupplierQueryObject query)
        {
            var suppliers = _context.Suppliers.Include(s => s.Categories).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                suppliers = _context.Suppliers.Where(s => s.SupplierName!.Contains(query.searchValue));
            }
            var nextNumber = (query.page - 1) * query.pageSize;
            return await suppliers.Skip(nextNumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetById(long supplierId)
        {
            var supplier = await _context.Suppliers.Include(s => s.Categories).FirstOrDefaultAsync(c => c.SupplierId == supplierId);
            if (supplier == null) { return null; }
            return supplier;
        }

        public int GetCount(SupplierQueryObject query)
        {
            var suppliers = _context.Suppliers.Include(s => s.Categories).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                suppliers = _context.Suppliers.Where(s => s.SupplierName!.Contains(query.searchValue));
            }
            return suppliers.Count();
        }

        public async Task<Supplier?> Update(long supplierId, UpdateSupplierDto supplierDto)
        {
            var s = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == supplierId);
            if (s == null)
            {
                return null;
            }
            if (s.SupplierName == supplierDto.SupplierName)
            {
                return null;
            }
            s.Hotline = supplierDto.Hotline;
            s.Email = supplierDto.Email;
            s.SupplierName = supplierDto.SupplierName;
            s.Address = supplierDto.Address;
            await _context.SaveChangesAsync();
            return s;
        }
    }
}