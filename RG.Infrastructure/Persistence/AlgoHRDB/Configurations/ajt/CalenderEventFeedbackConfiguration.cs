using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class CalenderEventFeedbackConfiguration : IEntityTypeConfiguration<CalenderEventFeedback>
    {
        public void Configure(EntityTypeBuilder<CalenderEventFeedback> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("CalenderEventFeedback", "ajt");
        }
    }
}
