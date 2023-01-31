using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InspGraph.Migrations
{
    public partial class _20230130 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectResults",
                columns: table => new
                {
                    InspectResultId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkDataId = table.Column<int>(type: "integer", nullable: false),
                    CameraNo = table.Column<int>(type: "integer", nullable: false),
                    PCNo = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    IsOK = table.Column<bool>(type: "boolean", nullable: false),
                    DefectDetail = table.Column<string>(type: "text", nullable: false),
                    InspTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectResults", x => x.InspectResultId);
                });

            migrationBuilder.CreateTable(
                name: "ModuleResults",
                columns: table => new
                {
                    ModuleResultId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InspResultId = table.Column<int>(type: "integer", nullable: false),
                    DataName = table.Column<string>(type: "text", nullable: false),
                    ModuleResultData = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleResults", x => x.ModuleResultId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingHours",
                columns: table => new
                {
                    ReciveSignalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRunning = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingHours", x => x.ReciveSignalTime);
                });

            migrationBuilder.CreateTable(
                name: "WorkData",
                columns: table => new
                {
                    WorkDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkDataName = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkData", x => x.WorkDataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectResults");

            migrationBuilder.DropTable(
                name: "ModuleResults");

            migrationBuilder.DropTable(
                name: "OperatingHours");

            migrationBuilder.DropTable(
                name: "WorkData");
        }
    }
}
