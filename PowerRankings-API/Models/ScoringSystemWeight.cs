using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerRankings_API.Models
{
    public class ScoringSystemWeight
    {
        public int Id { get; set; }
        public int ScoringSystemId { get; set; }
        public int Rank { get; set; }
        public int Weight { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
