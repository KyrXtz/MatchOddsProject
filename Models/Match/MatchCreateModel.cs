using MatchOddsProject.Entities;
using MatchOddsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Models
{
    public class MatchCreateModel
    { 
        /// <summary>
        /// Description of new match
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// New match date and time
        /// </summary>
        [Required]
        public DateTime MatchDate { get; set; }
        /// <summary>
        /// Team A Name
        /// </summary>
        [Required]
        public string TeamA { get; set; }
        /// <summary>
        /// Team B Name
        /// </summary>
        [Required]
        public string TeamB { get; set; }
        /// <summary>
        /// Sport type. 1 = Football, 2 = Basketball
        /// </summary>
        [Required]
        [Range(1,2)]
        public Sport Sport { get; set; }

        /// <summary>
        /// Convert MatchCreateModel to Match object to insert to Database
        /// </summary>
        public Match CastToMatch()
        {
            return new Match 
            {
                Description = Description,
                MatchDate = MatchDate.Date,
                MatchTime = MatchDate.TimeOfDay,
                TeamA = TeamA,
                TeamB = TeamB,
                Sport = Sport
            };
        }
    }
}
