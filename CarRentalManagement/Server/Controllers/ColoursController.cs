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
    public class ColoursController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;

        public ColoursController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> GetColours()
        {
            if (_unitofWork.Colours == null)
            {
                return NotFound();
            }

            var colours = await _unitofWork.Colours.GetAll();
            return Ok(colours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColour(int id)
        {
            if (_unitofWork.Colours == null)
            {
                return NotFound();
            }

            var colour = await _unitofWork.Colours.Get(q => q.Id == id);

            if (colour == null)
            {
                return NotFound();
            }
            return Ok(colour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutColour(int id, Colour colour)
        {
            if (id != colour.Id)
            {
                return BadRequest();
            }

            _unitofWork.Colours.Update(colour);

            try
            {
                await _unitofWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ColourExists(id))
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
        public async Task<ActionResult<Colour>> PostColour(Colour colour)
        {
            if (_unitofWork.Colours == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
            }

            await _unitofWork.Colours.Insert(colour);
            await _unitofWork.Save(HttpContext);

            return CreatedAtAction("GetColour", new { id = colour.Id }, colour);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColour(int id)
        {
            if (_unitofWork.Colours == null)
            {
                return NotFound();
            }
            var colour = await _unitofWork.Colours.Get(q => q.Id == id);
            if (colour == null)
            {
                return NotFound();
            }

            await _unitofWork.Colours.Delete(id);
            await _unitofWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ColourExists(int id)
        {
            var colour = await _unitofWork.Colours.Get(q => q.Id == id);
            return colour != null;
        }
    }
}