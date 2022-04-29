using MatchOddsProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsProject.Database.Configurations
{
    public class MatchOddsConfiguration : IEntityTypeConfiguration<MatchOdds>                           
    {
        public void Configure(EntityTypeBuilder<MatchOdds> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.MatchId).IsRequired();
            builder.Property(x => x.Specifier).IsRequired();
            builder.Property(p => p.Odd).IsRequired().HasColumnType("decimal(18,4)");
        }
    }
}
