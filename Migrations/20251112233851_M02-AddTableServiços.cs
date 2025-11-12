using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iBarber.Migrations
{
    /// <inheritdoc />
    public partial class M02AddTableServiços : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serviços",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preço = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviços", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serviços_Barbearias_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviços_BarbeariaId",
                table: "Serviços",
                column: "BarbeariaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serviços");
        }
    }
}
