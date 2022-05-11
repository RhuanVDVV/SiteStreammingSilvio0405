using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteStreammingSilvio0405.Migrations
{
    public partial class bancodedados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streaming",
                columns: table => new
                {
                    StreammingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Linkimagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkvideomusica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloVideo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streaming", x => x.StreammingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streaming");
        }
    }
}
