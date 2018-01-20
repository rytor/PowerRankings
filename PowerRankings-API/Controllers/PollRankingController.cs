using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerRankings_API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerRankings_API.Controllers
{
    [Route("api/pollrankings")]
    public class PollRankingController : Controller
    {
        private readonly PowerRankingsContext _context;

        public PollRankingController(PowerRankingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PollRanking> GetPollRankings()
        {
            return _context.PollRankings.ToList();
        }

        [HttpGet("{Id}", Name = "GetPollRanking")]
        public IActionResult GetPollRankingById(int id)
        {
            var item = _context.PollRankings.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreatePollRanking([FromBody] PollRanking item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.PollRankings.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPollRanking", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePollRanking(int id, [FromBody] PollRanking item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var pollRanking = _context.PollRankings.FirstOrDefault(t => t.Id == id);
            if (pollRanking == null)
            {
                return NotFound();
            }

            pollRanking.PollId = item.PollId;
            pollRanking.OptionId = item.OptionId;
            pollRanking.Rank = item.Rank;
            pollRanking.ModifyDate = DateTime.UtcNow;

            _context.PollRankings.Update(pollRanking);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePollRanking(int id)
        {
            var pollRanking = _context.PollRankings.FirstOrDefault(t => t.Id == id);
            if (pollRanking == null)
            {
                return NotFound();
            }

            _context.PollRankings.Remove(pollRanking);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
