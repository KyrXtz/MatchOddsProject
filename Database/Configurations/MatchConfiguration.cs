using MatchOddsProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Database.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.MatchDate).IsRequired();
            builder.Property(x => x.MatchTime).IsRequired();
            builder.Property(x => x.TeamA).IsRequired();
            builder.Property(x => x.TeamB).IsRequired();
            builder.Property(x => x.Sport).IsRequired();
        }
    }
}
