using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Supplier;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepo;
        public SupplierController(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SupplierQueryObject query)
        {
            try
            {
                List<Supplier> suppliers = await _supplierRepo.GetAll(query);
                if (suppliers == null)
                {
                    return NotFound();
                }
                var count = _supplierRepo.GetCount(query);
                var pageCount = count % query.pageSize == 0 ? count / query.pageSize : count / query.pageSize + 1;
                return Ok(new ResponseSupplierDto
                {
                    page = query.page,
                    pageSize = query.pageSize,
                    pageCount = pageCount,
                    suppliers = suppliers.SupplierMapToDtos()
                });
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpGet]
        [Route("/api/allsupplier")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Supplier> suppliers = await _supplierRepo.GetAll();
                if (suppliers == null)
                {
                    return NotFound();
                }
                return Ok(suppliers);
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            try
            {
                var supplier = await _supplierRepo.GetById(id);
                if (supplier == null) { return NotFound(); }
                return Ok(supplier);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierDto supplierDto)
        {
            try
            {
                var supplier = await _supplierRepo.Create(supplierDto.ToSupplier());
                if (supplier == null)
                {
                    return Conflict(new { Message = "Data is invalid." });
                }
                return CreatedAtAction(nameof(GetById), new { id = supplier.SupplierId }, supplier.ToCreateSupplierDto());
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateSupplierDto supplierDto)
        {
            try
            {
                var supplier = await _supplierRepo.Update(id, supplierDto);
                if (supplier == null)
                {
                    return Conflict();
                }
                return Ok(supplier);
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                var supplier = await _supplierRepo.Delete(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }
            catch (Exception e) { return BadRequest(e); }
        }
    }
}