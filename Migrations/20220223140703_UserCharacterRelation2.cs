﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace _Net_Core_web_API.Migrations
{
    public partial class UserCharacterRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_characters_UserId",
                table: "characters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_User_UserId",
                table: "characters",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_User_UserId",
                table: "characters");

            migrationBuilder.DropIndex(
                name: "IX_characters_UserId",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "characters");
        }
    }
}
