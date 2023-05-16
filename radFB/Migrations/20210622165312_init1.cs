using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace radFB.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_maritalstatus",
                table: "Tbl_RealCient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "birthday",
                table: "Tbl_RealCient",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "interdusedEmail",
                table: "Tbl_RadFBUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "fk_userID",
                table: "Tbl_poster",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "majorID",
                table: "Tbl_major",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Tbl_maritalStatus",
                columns: table => new
                {
                    maritalstatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maritalstatusTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_maritalStatus", x => x.maritalstatusID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_maritalStatus");

            migrationBuilder.DropColumn(
                name: "Fk_maritalstatus",
                table: "Tbl_RealCient");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "Tbl_RealCient");

            migrationBuilder.DropColumn(
                name: "fk_userID",
                table: "Tbl_poster");

            migrationBuilder.AlterColumn<int>(
                name: "interdusedEmail",
                table: "Tbl_RadFBUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "majorID",
                table: "Tbl_major",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
