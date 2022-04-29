﻿using MatchOddsProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Entities
{
    public class MatchOdds
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Specifier Specifier { get; set; }
        public decimal Odd { get; set; }
    }
}
