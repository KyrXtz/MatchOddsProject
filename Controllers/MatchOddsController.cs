using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatchOddsProject.Database;
using MatchOddsProject.Entities;
using Microsoft.AspNetCore.Http;
using MatchOddsProject.Models;

namespace MatchOddsProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchOddsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchOddsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all match odds
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(MatchOdds[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.MatchesOdds.ToListAsync());
        }

        /// <summary>
        /// Get match odds record by Id
        /// </summary>
        /// <param name="id">Id of match</param>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(MatchOdds), StatusCodes.Status200OK)]
        public async Task<IActionResult> Details(int id)
        {
            var matchOdds = await _context.MatchesOdds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchOdds == null)
            {
                return NotFound();
            }

            return Ok(matchOdds);
        }

        /// <summary>
        /// Create a match odds record. Returns the Auto-Generated id of the record
        /// </summary>
        /// <param name="matchOddsCreateModel"></param>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] MatchOddsCreateModel matchOddsCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchOdds = matchOddsCreateModel.CastToMatchOdds();
            if (matchOdds.Odd < 1)
                return BadRequest("Odd less than 1");
            try
            {               
                _context.Add(matchOdds);
                await _context.SaveChangesAsync();
                return Ok(matchOdds.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        /// <summary>
        /// Update a match odds record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="matchOddsUpdateModel"></param>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] MatchOddsUpdateModel matchOddsUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchOdds = await _context.MatchesOdds.FindAsync(id);
            if (matchOdds == null)
            {
                return NotFound();
            }
            matchOdds = matchOddsUpdateModel.CastToExistingMatchOdds(matchOdds);
            if (matchOdds.Odd < 1)
                return BadRequest("Odd less than 1");
            try
            {
                _context.Update(matchOdds);
                await _context.SaveChangesAsync();
                return Ok(matchOdds);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchOddsExists(matchOdds.Id))
                {
                    return NotFound();
                }
                else
                {
                    return Redirect(nameof(Update));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        /// <summary>
        /// Delete a match odds record
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var matchOdds = await _context.MatchesOdds.FindAsync(id);
            if (matchOdds == null)
            {
                return NotFound();
            }
            try
            {
                _context.MatchesOdds.Remove(matchOdds);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            
        }

        [NonAction]
        private bool MatchOddsExists(int id)
        {
            return _context.MatchesOdds.Any(e => e.Id == id);
        }
    }
}
