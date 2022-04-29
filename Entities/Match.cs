using MatchOddsProject.Models;
using MatchOddsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Entities
{
    public class Match
    {
        /// <summary>
        /// Auto-generated Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description of the match
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Date of the match
        /// </summary>
        public DateTime MatchDate { get; set; }
        /// <summary>
        /// Time of day of the match
        /// </summary>
        public TimeSpan MatchTime { get; set; }
        /// <summary>
        /// Name of Team A
        /// </summary>
        public string TeamA { get; set; }
        /// <summary>
        /// Name of Team B
        /// </summary>
        public string TeamB { get; set; }
        /// <summary>
        /// Sport type.
        /// </summary>
        public Sport Sport { get; set; }

    }
}
