﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appSix.Models;

namespace appSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CitiesController : ControllerBase
    {
        private readonly SixcoContext _context;

        public CitiesController(SixcoContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cities>>> GetCities()
        {
            return await _context.Cities
                 //.AsNoTracking()
                .AsQueryable()
                .Include(cities => cities.Country)
                .ToListAsync();
           
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> GetCities(int id)
        {
            var cities = await _context.Cities.FindAsync(id);

            if (cities == null)
            {
                return NotFound();
            }

            return cities;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCities(int id, Cities cities)
        {
            if (id != cities.Id)
            {
                return BadRequest();
            }

            _context.Entry(cities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitiesExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cities>> PostCities(Cities cities)
        {
            _context.Cities.Add(cities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CitiesExists(cities.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCities", new { id = cities.Id }, cities);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cities>> DeleteCities(int id)
        {
            var cities = await _context.Cities.FindAsync(id);
            if (cities == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(cities);
            await _context.SaveChangesAsync();

            return cities;
        }

        private bool CitiesExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
