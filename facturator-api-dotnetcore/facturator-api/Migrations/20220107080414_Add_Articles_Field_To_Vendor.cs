using Microsoft.EntityFrameworkCore.Migrations;

namespace facturator_api.Migrations
{
    public partial class Add_Articles_Field_To_Vendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Vendors_VendorId",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Logins",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Articles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_VendorId",
                table: "Articles",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Vendors_VendorId",
                table: "Articles",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Vendors_VendorId",
                table: "Logins",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Vendors_VendorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Vendors_VendorId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Articles_VendorId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Logins",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Vendors_VendorId",
                table: "Logins",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
