using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AIPSv1;

namespace AIPSv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly gemsandcrystalsContext _context;

        public DecksController(gemsandcrystalsContext context)
        {
            _context = context;
        }

        // GET: api/Decks
        [HttpGet]
        public IEnumerable<Deck> GetDeck()
        {
            return _context.Deck;
        }

        // GET: api/Decks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deck = await _context.Deck.FindAsync(id);

            if (deck == null)
            {
                return NotFound();
            }

            return Ok(deck);
        }

        // PUT: api/Decks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck([FromRoute] int id, [FromBody] Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deck.IdDeck)
            {
                return BadRequest();
            }

            _context.Entry(deck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(id))
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

        // POST: api/Decks
        [HttpPost]
        public async Task<IActionResult> PostDeck([FromBody] Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Deck.Add(deck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeck", new { id = deck.IdDeck }, deck);
        }

        // DELETE: api/Decks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deck = await _context.Deck.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            _context.Deck.Remove(deck);
            await _context.SaveChangesAsync();

            return Ok(deck);
        }

        private bool DeckExists(int id)
        {
            return _context.Deck.Any(e => e.IdDeck == id);
        }
    }
}