using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SquareFish.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingLeader",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeaderId = table.Column<int>(nullable: false),
                    BookingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingLeader", x => x.Id);
                    table.UniqueConstraint("AK_BookingLeader_BookingId_LeaderId", x => new { x.BookingId, x.LeaderId });
                    table.ForeignKey(
                        name: "FK_BookingLeader_Booking_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "dbo",
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingLeader_Leader_LeaderId",
                        column: x => x.LeaderId,
                        principalSchema: "dbo",
                        principalTable: "Leader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Leader",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Michael Scott" },
                    { 2, "Jim Halpert" },
                    { 3, "Pam Beesly" },
                    { 4, "Dwight Schrute" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingLeader_LeaderId",
                schema: "dbo",
                table: "BookingLeader",
                column: "LeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingLeader",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Booking",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Leader",
                schema: "dbo");
        }
    }
}
