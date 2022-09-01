using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Views
{
    public class Vw_User_SetupConfiguration : IEntityTypeConfiguration<Vw_User_Setup>
    {
        public void Configure(EntityTypeBuilder<Vw_User_Setup> builder)
        {
            builder.HasKey(b=>b.ID);
            builder.ToTable("Vw_User_Setup", "ajt");
        }
    }
}
