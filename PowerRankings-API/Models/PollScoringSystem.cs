﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerRankings_API.Models
{
    public class PollScoringSystem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
