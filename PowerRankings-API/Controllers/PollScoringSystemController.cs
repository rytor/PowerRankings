using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerRankings_API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerRankings_API.Controllers
{
    [Route("api/pollscoringsystems")]
    public class PollScoringSystemController : Controller
    {
        private readonly PowerRankingsContext _context;

        public PollScoringSystemController(PowerRankingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PollScoringSystem> GetPollScoringSystems()
        {
            return _context.PollScoringSystems.ToList();
        }

        [HttpGet("{Id}", Name = "GetPollScoringSystem")]
        public IActionResult GetPollScoringSystemById(int id)
        {
            var item = _context.PollScoringSystems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreatePollScoringSystem([FromBody] PollScoringSystem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.PollScoringSystems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPollScoringSystem", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePollScoringSystem(int id, [FromBody] PollScoringSystem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var pollScoringSystem = _context.PollScoringSystems.FirstOrDefault(t => t.Id == id);
            if (pollScoringSystem == null)
            {
                return NotFound();
            }

            pollScoringSystem.Description = item.Description;
            pollScoringSystem.ModifyDate = DateTime.UtcNow;

            _context.PollScoringSystems.Update(pollScoringSystem);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePollScoringSystem(int id)
        {
            var pollScoringSystem = _context.PollScoringSystems.FirstOrDefault(t => t.Id == id);
            if (pollScoringSystem == null)
            {
                return NotFound();
            }

            _context.PollScoringSystems.Remove(pollScoringSystem);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
