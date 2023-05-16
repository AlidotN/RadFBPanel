using Microsoft.EntityFrameworkCore.Migrations;

namespace radFB.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_jobCategory_Tbl_guild_fk_guildID",
                table: "Tbl_jobCategory");

            migrationBuilder.AlterColumn<int>(
                name: "fk_countryID",
                table: "Tbl_province",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_jobCategory_Tbl_guild_fk_guildID",
                table: "Tbl_jobCategory",
                column: "fk_guildID",
                principalTable: "Tbl_guild",
                principalColumn: "guildID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_jobCategory_Tbl_guild_fk_guildID",
                table: "Tbl_jobCategory");

            migrationBuilder.AlterColumn<int>(
                name: "fk_countryID",
                table: "Tbl_province",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_jobCategory_Tbl_guild_fk_guildID",
                table: "Tbl_jobCategory",
                column: "fk_guildID",
                principalTable: "Tbl_guild",
                principalColumn: "guildID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
