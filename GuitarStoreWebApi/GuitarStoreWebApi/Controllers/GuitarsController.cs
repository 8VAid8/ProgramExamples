using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuitarsProject;
using GuitarsProject.DAL;

namespace GuitarStoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Guitars")]
    public class GuitarsController : Controller
    {
        GuitarsRepository guitars;

        public GuitarsController(GuitarContext context)
        {
            guitars = new GuitarsRepository(context);
        }

        // GET: api/Guitars
        [HttpGet]
        public IEnumerable<Guitar> GetGuitars()
        {
            var g = guitars.Get();
            return g;
        }

        // GET: api/Guitars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuitar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guitar = guitars.Get(id);

            if (guitar == null)
            {
                return NotFound();
            }

            return Ok(guitar);
        }

        // PUT: api/Guitars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuitar([FromRoute] int id, [FromBody] Guitar guitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guitar.GuitarId)
            {
                return BadRequest();
            }
    
            //_context.Entry(guitar).State = EntityState.Modified;
            try
            {
                guitars.Update(guitar);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuitarExists(id))
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

        // POST: api/Guitars
        [HttpPost]
        public async Task<IActionResult> PostGuitar([FromBody] Guitar guitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            guitars.Create(guitar);
            //_context.Guitars.Add(guitar);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuitar", new { id = guitar.GuitarId }, guitar);
        }

        // DELETE: api/Guitars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuitar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var guitar = await _context.Guitars.SingleOrDefaultAsync(m => m.GuitarId == id);
            bool isDeleted = guitars.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(true);
        }

        private bool GuitarExists(int id)
        {
            return guitars.IsExists(id);
        }
    }
}