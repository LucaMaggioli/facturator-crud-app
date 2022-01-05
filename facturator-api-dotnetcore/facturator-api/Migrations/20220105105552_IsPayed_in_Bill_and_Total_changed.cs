using Microsoft.EntityFrameworkCore.Migrations;

namespace facturator_api.Migrations
{
    public partial class IsPayed_in_Bill_and_Total_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Bills");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayed",
                table: "Bills",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayed",
                table: "Bills");

            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "Bills",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Bills",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
