using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetCorePostgres.Data;
using DotNetCorePostgres.Models;

namespace DotNetCorePostgres.Controllers
{
    [Produces("application/json")]
    [Route("api/Foos")]
    public class FoosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Foos
        [HttpGet]
        public IEnumerable<Foo> GetFoos()
        {
            return _context.Foos;
        }

        // GET: api/Foos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foo = await _context.Foos.SingleOrDefaultAsync(m => m.FooId == id);

            if (foo == null)
            {
                return NotFound();
            }

            return Ok(foo);
        }

        // PUT: api/Foos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoo([FromRoute] int id, [FromBody] Foo foo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foo.FooId)
            {
                return BadRequest();
            }

            _context.Entry(foo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooExists(id))
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

        // POST: api/Foos
        [HttpPost]
        public async Task<IActionResult> PostFoo([FromBody] FooViewModel foo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Foo nfoo = new Foo()
            {
                FooId = 1,
                DateJoined = DateTime.Now,
                Name = foo.Name,
                Bars = new List<Bar>()
            };

            _context.Foos.Add(nfoo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoo", new { id = nfoo.FooId }, foo);
        }

        // DELETE: api/Foos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foo = await _context.Foos.SingleOrDefaultAsync(m => m.FooId == id);
            if (foo == null)
            {
                return NotFound();
            }

            _context.Foos.Remove(foo);
            await _context.SaveChangesAsync();

            return Ok(foo);
        }

        private bool FooExists(int id)
        {
            return _context.Foos.Any(e => e.FooId == id);
        }
    }
}