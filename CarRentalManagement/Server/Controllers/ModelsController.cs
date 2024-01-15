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
    public class ModelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;

        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        [HttpGet]


        public async Task<IActionResult> GetModels()
        {
            if (_unitofWork.Models == null)
            {
                return NotFound();
            }

            var models = await _unitofWork.Models.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetModels(int id)
        {
            if (_unitofWork.Models == null)
            {
                return NotFound();
            }

            var model = await _unitofWork.Models.Get(q => q.Id == id);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitofWork.Models.Update(model);

            try
            {
                await _unitofWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await modelExists(id))
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

        // POST: api/makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> Postmake(Model model)
        {
            if (_unitofWork.Models == null)
            {
                return Problem("Entity set 'ApplicationDbContext.makes'  is null.");
            }

            await _unitofWork.Models.Insert(model);
            await _unitofWork.Save(HttpContext);

            return CreatedAtAction("Getmake", new { id = model.Id }, model);
        }

        // DELETE: api/makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemake(int id)
        {
            if (_unitofWork.Models == null)
            {
                return NotFound();
            }
            var model = await _unitofWork.Models.Get(q => q.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            await _unitofWork.Models.Delete(id);
            await _unitofWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> modelExists(int id)
        {
            var model = await _unitofWork.Models.Get(q => q.Id == id);
            return model != null;
        }
    }
}
