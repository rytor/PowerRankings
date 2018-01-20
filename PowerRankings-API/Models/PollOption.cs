using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerRankings_API.Models
{
    public class PollOption
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
