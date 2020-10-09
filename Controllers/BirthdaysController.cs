using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirthdaysWebApi.Models;

namespace BirthdaysWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdaysController : ControllerBase
    {
        private readonly BirthdayContext _context;

        public BirthdaysController(BirthdayContext context)
        {
            _context = context;
        }

        // GET: api/Birthdays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetBirthdays()
        {
            return await _context.Birthdays.ToListAsync();
        }

        // GET: api/Birthdays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Birthday>> GetBirthday(int id)
        {
            var birthday = await _context.Birthdays.FindAsync(id);

            if (birthday == null)
            {
                return NotFound();
            }

            return birthday;
        }

        // PUT: api/Birthdays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBirthday(int id, Birthday birthday)
        {
            if (id != birthday.Id)
            {
                return BadRequest();
            }

            _context.Entry(birthday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirthdayExists(id))
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

        // POST: api/Birthdays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Birthday>> PostBirthday(Birthday birthday)
        {
            _context.Birthdays.Add(birthday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBirthday", new { id = birthday.Id }, birthday);
        }

        // DELETE: api/Birthdays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Birthday>> DeleteBirthday(int id)
        {
            var birthday = await _context.Birthdays.FindAsync(id);
            if (birthday == null)
            {
                return NotFound();
            }

            _context.Birthdays.Remove(birthday);
            await _context.SaveChangesAsync();

            return birthday;
        }

        private bool BirthdayExists(int id)
        {
            return _context.Birthdays.Any(e => e.Id == id);
        }
    }
}
