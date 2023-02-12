using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastDeliveriApi.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "custumers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    PhomeNumberCustumer = table.Column<string>(type: "text", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "text", maxLength: 120, nullable: false),
                    Address = table.Column<string>(type: "text", maxLength: 120, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custumers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "custumers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhomeNumberCustumer", "Status" },
                values: new object[,]
                {
                    { 1, "Morazan", "JorgeArgueta@univo.edu.sv", "Jorge Argueta", "7889-9639", true },
                    { 2, "Morazan", "JavieraRamirez@univo.edu.sv", "Javier Ramirez", "7999-9639", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "custumers");
        }
    }
}
