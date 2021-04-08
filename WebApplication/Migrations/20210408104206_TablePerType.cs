using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class TablePerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Routines");

            migrationBuilder.CreateTable(
                name: "CardioRoutines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardioRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardioRoutines_Routines_Id",
                        column: x => x.Id,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GymRoutines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymRoutines_Routines_Id",
                        column: x => x.Id,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardioRoutines");

            migrationBuilder.DropTable(
                name: "GymRoutines");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Routines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Routines",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intensity",
                table: "Routines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Routines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Routines",
                type: "int",
                nullable: true);
        }
    }
}
