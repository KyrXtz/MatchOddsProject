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
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all matches
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Match[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Matches.ToListAsync());
        }
        /// <summary>
        /// Get match record by Id
        /// </summary>
        /// <param name="id">Id of match</param>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(Match), StatusCodes.Status200OK)]
        public async Task<IActionResult> Details(int id)
        {       
            var match = await _context.Matches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        /// <summary>
        /// Create a match record. Returns the Auto-Generated id of the record
        /// </summary>
        /// <param name="matchCreateRequest"></param>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] MatchCreateModel matchCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = matchCreateRequest.CastToMatch();
            try
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return Ok(match.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }


        }

        /// <summary>
        /// Update a match record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="matchUpdateModel"></param>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] MatchUpdateModel matchUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            match = matchUpdateModel.CastToExistingMatch(match);
            try
            {
                _context.Update(match);
                await _context.SaveChangesAsync();
                return Ok(match);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(match.Id))
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
        /// Delete a match record
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [NonAction]
        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
