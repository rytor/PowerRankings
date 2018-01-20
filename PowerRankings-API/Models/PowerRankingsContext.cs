using Microsoft.EntityFrameworkCore;

namespace PowerRankings_API.Models
{
    public class PowerRankingsContext : DbContext
    {
        public PowerRankingsContext(DbContextOptions<PowerRankingsContext> options)
            : base(options)
        {

        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<PollRanking> PollRankings { get; set; }
        public DbSet<PollScoringSystem> PollScoringSystems { get; set; }
        public DbSet<ScoringSystemWeight> ScoringSystemWeights { get; set; }
    }
}
