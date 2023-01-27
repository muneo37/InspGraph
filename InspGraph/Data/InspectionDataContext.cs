using System;
using System.Collections.Generic;
using InspGraph.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InspGraph
{
    public class InspectionDataContext : DbContext
    {
        public InspectionDataContext(DbContextOptions<InspectionDataContext> options)
        : base(options)
        {
        }

        public DbSet<InspectResult> InspectResults { get; set; } = null!;
        public DbSet<ModuleResult> ModuleResults { get; set; } = null!;
        public DbSet<WorkData> WorkDatas { get; set; } = null!;
        public DbSet<OperatingHours> WorkDataChangeLogs { get; set; } = null!;
    }
}
