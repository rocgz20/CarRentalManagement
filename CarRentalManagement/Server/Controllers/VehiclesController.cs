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
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;

        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> GetVehicles()
        {
            if (_unitofWork.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _unitofWork.Vehicles.GetAll(includes: q => q.Include(x => x.Make).Include(x => x.Model).Include(x => x.Colour));
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            if (_unitofWork.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _unitofWork.Vehicles.Get(q => q.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            _unitofWork.Vehicles.Update(vehicle);

            try
            {
                await _unitofWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VehicleExists(id))
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
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (_unitofWork.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }

            await _unitofWork.Vehicles.Insert(vehicle);
            await _unitofWork.Save(HttpContext);

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (_unitofWork.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _unitofWork.Vehicles.Get(q => q.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            await _unitofWork.Vehicles.Delete(id);
            await _unitofWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> VehicleExists(int id)
        {
            var vehicle = await _unitofWork.Vehicles.Get(q => q.Id == id);
            return vehicle != null;
        }
    }
}

