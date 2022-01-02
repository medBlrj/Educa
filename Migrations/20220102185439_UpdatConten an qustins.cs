using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educa.Migrations
{
    public partial class UpdatContenanqustins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contents",
                newName: "ContentId");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ContentId",
                table: "Questions",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Contents_ContentId",
                table: "Questions",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Contents_ContentId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ContentId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "Contents",
                newName: "Id");
        }
    }
}
