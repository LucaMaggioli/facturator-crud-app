﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace facturator_api.Migrations
{
    public partial class AddIsArchivedClientColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Clients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Clients");
        }
    }
}
