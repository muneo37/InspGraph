using System;
using System.Collections.Generic;
using InspGraph.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InspGraph
{
    public class InspectionDataContext : DbContext
    {

        public DbSet<InspectResult> InspectResults { get; set; } = null!;
        public DbSet<ModuleResult> ModuleResults { get; set; } = null!;
        public DbSet<WorkData> WorkData { get; set; } = null!;
        public DbSet<OperatingHour> OperatingHours { get; set; } = null!;

        public string DatabaseName { get; set; } = "InspectionData";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Host=localhost; Port=5432; Database=" + DatabaseName + "; Username=postgres; Password=asvt; Include Error Detail=true;";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
 
    }
}
