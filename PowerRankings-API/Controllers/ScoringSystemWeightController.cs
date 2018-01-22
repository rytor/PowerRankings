using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerRankings_API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerRankings_API.Controllers
{
    [Route("api/scoringsystemweights")]
    public class ScoringSystemWeightController : Controller
    {
        private readonly PowerRankingsContext _context;

        public ScoringSystemWeightController(PowerRankingsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ScoringSystemWeight> GetScoringSystemWeights()
        {
            return _context.ScoringSystemWeights.ToList();
        }

        [HttpGet("{Id}", Name = "GetScoringSystemWeight")]
        public IActionResult GetScoringSystemWeightById(int id)
        {
            var item = _context.ScoringSystemWeights.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreateScoringSystemWeight([FromBody] ScoringSystemWeight item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ScoringSystemWeights.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetScoringSystemWeight", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateScoringSystemWeight(int id, [FromBody] ScoringSystemWeight item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var ssw = _context.ScoringSystemWeights.FirstOrDefault(t => t.Id == id);
            if (ssw == null)
            {
                return NotFound();
            }

            ssw.ScoringSystemId = item.ScoringSystemId;
            ssw.Rank = item.Rank;
            ssw.Weight = item.Weight;
            ssw.ModifyDate = DateTime.UtcNow;

            _context.ScoringSystemWeights.Update(ssw);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteScoringSystemWeight(int id)
        {
            var ssw = _context.ScoringSystemWeights.FirstOrDefault(t => t.Id == id);
            if (ssw == null)
            {
                return NotFound();
            }

            _context.ScoringSystemWeights.Remove(ssw);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
