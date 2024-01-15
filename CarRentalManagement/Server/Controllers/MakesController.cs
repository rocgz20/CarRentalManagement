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
    public class MakesController : ControllerBase
    {
        // Refactored
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofWork;

        // Refactored
        // public MakesController(ApplicationDbContext context)
        public MakesController(IUnitOfWork unitOfWork)
        {
            // Refactored
            // _context = context;
            _unitofWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        // Refactored
        // public async Task<ActionResult<IEnumerable<Make>>> GetMakes()

         public async Task<IActionResult> GetMakes()
        {       
            if (_unitofWork.Makes== null)
            {
                return NotFound();
            }

            var makes = await _unitofWork.Makes.GetAll();
            return Ok(makes);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        // Refactored
        // public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetMake(int id)
        {
            if (_unitofWork.Makes == null)
            {
                    return NotFound();
            }

            var make = await _unitofWork.Makes.Get(q => q.Id == id);

            if (make == null)
            {
                return NotFound();
            }
            return Ok(make);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

            _unitofWork.Makes.Update(make);

            try
            {
                await _unitofWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MakeExists(id))
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

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
          if (_unitofWork.Makes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
          }

            await _unitofWork.Makes.Insert(make);
            await _unitofWork.Save(HttpContext);

            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            if (_unitofWork.Makes == null)
            {
                return NotFound();
            }
            var make = await _unitofWork.Makes.Get(q => q.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            await _unitofWork.Makes.Delete(id);
            await _unitofWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> MakeExists(int id)
        {
            var make = await _unitofWork.Makes.Get(q => q.Id == id);
            return make != null;
        }
    }
}
