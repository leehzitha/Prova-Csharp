using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova_Csharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Passeios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passeios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Passeios_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PasseioPonto",
                columns: table => new
                {
                    PasseiosID = table.Column<int>(type: "int", nullable: false),
                    PontosID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasseioPonto", x => new { x.PasseiosID, x.PontosID });
                    table.ForeignKey(
                        name: "FK_PasseioPonto_Passeios_PasseiosID",
                        column: x => x.PasseiosID,
                        principalTable: "Passeios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PasseioPonto_Pontos_PontosID",
                        column: x => x.PontosID,
                        principalTable: "Pontos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasseioPonto_PontosID",
                table: "PasseioPonto",
                column: "PontosID");

            migrationBuilder.CreateIndex(
                name: "IX_Passeios_CreatorID",
                table: "Passeios",
                column: "CreatorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasseioPonto");

            migrationBuilder.DropTable(
                name: "Passeios");

            migrationBuilder.DropTable(
                name: "Pontos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
