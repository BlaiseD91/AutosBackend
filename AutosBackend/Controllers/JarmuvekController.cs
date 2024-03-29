﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutosBackend.Models;

namespace AutosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JarmuvekController : ControllerBase
    {
        private readonly Jarmuvek _context;
        Random vszg = new Random();

        public JarmuvekController(Jarmuvek context)
        {
            _context = context;
            Jarmu j = new Jarmu();
            j.Id = vszg.Next(1, 99);
            j.Rendszam = "JAB-001";
            j.Marka = "Opel";
            j.Ar = 1200000;
            _context.Add(j);
            _context.SaveChanges();
        }

        // GET: api/Jarmuvek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jarmu>>> Getjarmuvek()
        {
          if (_context.jarmuvek == null)
          {
              return NotFound();
          }
            return await _context.jarmuvek.ToListAsync();
        }

        // GET: api/Jarmuvek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jarmu>> GetJarmu(int id)
        {
          if (_context.jarmuvek == null)
          {
              return NotFound();
          }
            var jarmu = await _context.jarmuvek.FindAsync(id);

            if (jarmu == null)
            {
                return NotFound();
            }

            return jarmu;
        }

        // PUT: api/Jarmuvek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJarmu(int id, Jarmu jarmu)
        {
            if (id != jarmu.Id)
            {
                return BadRequest();
            }

            _context.Entry(jarmu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JarmuExists(id))
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

        // POST: api/Jarmuvek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jarmu>> PostJarmu(Jarmu jarmu)
        {
          if (_context.jarmuvek == null)
          {
              return Problem("Entity set 'Jarmuvek.jarmuvek'  is null.");
          }
            _context.jarmuvek.Add(jarmu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJarmu", new { id = jarmu.Id }, jarmu);
        }

        // DELETE: api/Jarmuvek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJarmu(int id)
        {
            if (_context.jarmuvek == null)
            {
                return NotFound();
            }
            var jarmu = await _context.jarmuvek.FindAsync(id);
            if (jarmu == null)
            {
                return NotFound();
            }

            _context.jarmuvek.Remove(jarmu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JarmuExists(int id)
        {
            return (_context.jarmuvek?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
