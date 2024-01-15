using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SQLitePCL;
using CarRentalManagement.Server.Repository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> GetCustomers()
        {
            if (_unitofWork.Customers == null)
            {
                return NotFound();
            }

            var customers = await _unitofWork.Customers.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if (_unitofWork.Customers == null)
            {
                return NotFound();
            }

            var customer = await _unitofWork.Customers.Get(q => q.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _unitofWork.Customers.Update(customer);

            try
            {
                await _unitofWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_unitofWork.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }

            await _unitofWork.Customers.Insert(customer);
            await _unitofWork.Save(HttpContext);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_unitofWork.Customers == null)
            {
                return NotFound();
            }
            var customer = await _unitofWork.Customers.Get(q => q.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            await _unitofWork.Customers.Delete(id);
            await _unitofWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CustomerExists(int id)
        {
            var customer = await _unitofWork.Customers.Get(q => q.Id == id);
            return customer != null;
        }
    }
}
