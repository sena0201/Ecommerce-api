using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Supplier;
using api.Entity;

namespace api.Mappers
{
    public static class SupplierMappers
    {

        public static CreateSupplierDto ToCreateSupplierDto(this Supplier supplier)
        {
            return new CreateSupplierDto
            {
                SupplierName = supplier.SupplierName,
                Address = supplier.Address,
                Email = supplier.Email,
                Hotline = supplier.Hotline,
            };
        }
        public static Supplier ToSupplier(this CreateSupplierDto supplierDto)
        {
            return new Supplier
            {
                SupplierName = supplierDto.SupplierName,
                Address = supplierDto.Address,
                Email = supplierDto.Email,
                Hotline = supplierDto.Hotline

            };
        }
        public static List<SupplierDto> SupplierMapToDtos(this List<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                return new List<SupplierDto>();
            }

            return suppliers.Select(supplier => new SupplierDto
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Address = supplier.Address,
                Email = supplier.Email,
                Hotline = supplier.Hotline,
                categories = supplier.Categories.Select(c => c.ToCategoryDto()).ToList()
            }).ToList();
        }
    }
}