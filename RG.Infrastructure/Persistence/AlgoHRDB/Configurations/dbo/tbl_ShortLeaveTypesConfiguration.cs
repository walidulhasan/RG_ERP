using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class tbl_ShortLeaveTypesConfiguration : IEntityTypeConfiguration<tbl_ShortLeaveTypes>
    {
        public void Configure(EntityTypeBuilder<tbl_ShortLeaveTypes> builder)
        {
            builder.HasKey(b => b.SL_typeID);
        }
    }
}
