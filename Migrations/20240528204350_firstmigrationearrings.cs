using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace earrings.Migrations
{
    /// <inheritdoc />
    public partial class firstmigrationearrings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Earrings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earrings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Earrings",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"), "Söta hängande avokadoörhängen", "/avokado.png", "Avokados", 50.0 },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c"), "Spökörhängen. Perfekta till Halloween!", "/spoken.png", "Spöken", 50.0 },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3d"), "Tassar till husse eller matte!", "/tassar.png", "Hundtassar", 50.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Earrings");
        }
    }
}
