using MatchOddsProject.Entities;
using MatchOddsProject.Enums;
using MatchOddsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Models
{
    public class MatchOddsCreateModel
    {
        /// <summary>
        /// Id of the match that these odds apply to.
        /// </summary>
        [Required]
        public int MatchId { get; set; }
        /// <summary>
        /// Specifier of the record odds. 0 = X, 1 = One, 2 = Two
        /// </summary>
        [Required]
        [Range(0,2)]
        public Specifier Specifier { get; set; }
        /// <summary>
        /// Odds of this record
        /// </summary>
        [Required]
        public decimal Odd { get; set; }

        /// <summary>
        /// Convert MatchOddsCreateModel to MatchOdds object to insert to Database
        /// </summary>
        public MatchOdds CastToMatchOdds()
        {
            return new MatchOdds
            {
                MatchId = MatchId,
                Specifier = Specifier,
                Odd = Odd
            };
        }
    }
}
