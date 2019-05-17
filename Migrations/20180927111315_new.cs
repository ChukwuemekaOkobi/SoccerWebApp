using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SoccerWebApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Tipster",
                newName: "Office");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Tipster",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Tipster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Tipster");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Tipster");

            migrationBuilder.RenameColumn(
                name: "Office",
                table: "Tipster",
                newName: "PhoneNumber");
        }
    }
}
