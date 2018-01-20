using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerRankings_API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerRankings_API.Controllers
{
    [Route("api/polloptions")]
    public class PollOptionController : Controller
    {
        private readonly PowerRankingsContext _context;

        public PollOptionController(PowerRankingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PollOption> GetPollOptions()
        {
            return _context.PollOptions.ToList();
        }

        [HttpGet("{Id}", Name = "GetPollOption")]
        public IActionResult GetPollOptionById(int id)
        {
            var item = _context.PollOptions.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreatePollOptions([FromBody] PollOption item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.PollOptions.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPoll", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePollOption(int id, [FromBody] PollOption item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var pollOption = _context.PollOptions.FirstOrDefault(t => t.Id == id);
            if (pollOption == null)
            {
                return NotFound();
            }

            pollOption.PollId = item.PollId;
            pollOption.Name = item.Name;
            pollOption.ModifyDate = DateTime.UtcNow;

            _context.PollOptions.Update(pollOption);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePollOption(int id)
        {
            var pollOption = _context.PollOptions.FirstOrDefault(t => t.Id == id);
            if (pollOption == null)
            {
                return NotFound();
            }

            _context.PollOptions.Remove(pollOption);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
