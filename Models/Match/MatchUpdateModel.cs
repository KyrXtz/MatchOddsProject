#nullable enable
using MatchOddsProject.Entities;
using MatchOddsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Models
{
    public class MatchUpdateModel
    {
        /// <summary>
        /// Description of match to be updated. Leave null to not update.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Date of match to be updated. Leave null to not update.
        /// </summary>
        public DateTime? MatchDate { get; set; }
        /// <summary>
        /// Time of day of match to be updated. Leave null to not update.
        /// </summary>
        public TimeSpan? MatchTime { get; set; }
        /// <summary>
        /// Team A Name. Leave null to not update.
        /// </summary>
        public string? TeamA { get; set; }
        /// <summary>
        /// Team B Name. Leave null to not update.
        /// </summary>
        public string? TeamB { get; set; }
        /// <summary>
        /// Sport type. 1 = Football, 2 = Basketball. Leave null to not update.
        /// </summary>
        [Range(1, 2)]
        public Sport? Sport { get; set; }

        /// <summary>
        /// Convert MatchUpdateModel to Match object to update to Database
        /// </summary>
        public Match CastToExistingMatch(Match match)
        {
            if (Description != null) match.Description = Description;
            if (MatchDate != null) match.MatchDate = (DateTime)MatchDate;
            if (MatchTime != null) match.MatchTime = (TimeSpan)MatchTime;
            if (TeamA != null) match.TeamA = TeamA;
            if (TeamB != null) match.TeamB = TeamB;
            if (Sport != null) match.Sport = (Sport)Sport;
            return match;
        }
    }
}
