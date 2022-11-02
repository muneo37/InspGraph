using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InspGraph
{
    public class InspectionDatasContext : DbContext
    {
        public DbSet<InspectResult> InspectResults { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<WorkData> WorkDatas { get; set; } = null!;
        public DbSet<WorkDataChangeLog> WorkDataChangeLogs { get; set; } = null!;

        public string DatabaseName { get; set; } = "InspectionDatasContext";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Host=172.21.6.153; Port=5432; Database=" + DatabaseName + "; Username=postgres; Password=asvt; Include Error Detail=true;";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

    }
}
