#nullable enable
using MatchOddsProject.Entities;
using MatchOddsProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Models
{
    public class MatchOddsUpdateModel
    {
        /// <summary>
        /// Match id Of match odds record to be update. Leave null to not update.
        /// </summary>
        public int? MatchId { get; set; }
        /// <summary>
        /// Specifier of match odds record to be updated. 0 = X, 1 = One, 2 = Two. Leave null to not update.
        /// </summary>
        public Specifier? Specifier { get; set; }
        /// <summary>
        /// Odd decimal of match odds record to be updated. Leave null to not update.
        /// </summary>
        public decimal? Odd { get; set; }

        /// <summary>
        /// Convert MatchOddsUpdateModel to MatchOdds object to update to Database
        /// </summary>
        public MatchOdds CastToExistingMatchOdds(MatchOdds matchOdds)
        {
            if (MatchId != null) matchOdds.MatchId = (int)MatchId;
            if (Specifier != null) matchOdds.Specifier = (Specifier)Specifier;
            if (Odd != null) matchOdds.Odd = (decimal)Odd;           
            return matchOdds;
        }
    }
}
