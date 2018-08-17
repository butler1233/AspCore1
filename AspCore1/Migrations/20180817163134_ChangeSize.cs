using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCore1.Migrations
{
    public partial class ChangeSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SizeKb",
                table: "Download",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SizeKb",
                table: "Download",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
