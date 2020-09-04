using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class delete_operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Operations_OperationId",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_OperationId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkingEntityOperationId",
                table: "Permissions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                columns: new[] { "RoleId", "WorkingEntityOperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_WorkingEntityOperationId",
                table: "Permissions",
                column: "WorkingEntityOperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_WorkingEntityOperations_WorkingEntityOperationId",
                table: "Permissions",
                column: "WorkingEntityOperationId",
                principalTable: "WorkingEntityOperations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_WorkingEntityOperations_WorkingEntityOperationId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_WorkingEntityOperationId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "WorkingEntityOperationId",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "OperationId",
                table: "Permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                columns: new[] { "RoleId", "OperationId" });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_OperationId",
                table: "Permissions",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Operations_OperationId",
                table: "Permissions",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
