using Microsoft.EntityFrameworkCore.Migrations;

namespace radFB.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "guildColor",
                table: "Tbl_guild",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "guildColor",
                table: "Tbl_guild",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
