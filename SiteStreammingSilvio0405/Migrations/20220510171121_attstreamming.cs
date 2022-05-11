using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteStreammingSilvio0405.Migrations
{
    public partial class attstreamming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Linkvideomusica",
                table: "Streaming",
                newName: "TipoVideo");

            migrationBuilder.RenameColumn(
                name: "Linkimagem",
                table: "Streaming",
                newName: "DescriçãoVideo");

            migrationBuilder.AddColumn<int>(
                name: "TamanhoVideo",
                table: "Streaming",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TamanhoVideo",
                table: "Streaming");

            migrationBuilder.RenameColumn(
                name: "TipoVideo",
                table: "Streaming",
                newName: "Linkvideomusica");

            migrationBuilder.RenameColumn(
                name: "DescriçãoVideo",
                table: "Streaming",
                newName: "Linkimagem");
        }
    }
}
