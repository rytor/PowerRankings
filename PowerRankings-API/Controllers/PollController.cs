using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerRankings_API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerRankings_API.Controllers
{
    [Route("api/polls")]
    public class PollController : Controller
    {
        private readonly PowerRankingsContext _context;

        public PollController(PowerRankingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Poll> GetPolls()
        {
            return _context.Polls.ToList();
        }

        [HttpGet("{Id}", Name = "GetPoll")]
        public IActionResult GetPollById(int id)
        {
            var item = _context.Polls.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreatePoll([FromBody] Poll item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Polls.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPoll", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePoll(int id, [FromBody] Poll item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var poll = _context.Polls.FirstOrDefault(t => t.Id == id);
            if (poll == null)
            {
                return NotFound();
            }

            poll.Description = item.Description;
            poll.ScoringSystemId = item.ScoringSystemId;
            poll.StartDate = item.StartDate;
            poll.EndDate = item.EndDate;
            poll.ModifyDate = DateTime.UtcNow;

            _context.Polls.Update(poll);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePoll(int id)
        {
            var poll = _context.Polls.FirstOrDefault(t => t.Id == id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Polls.Remove(poll);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
