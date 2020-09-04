using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class organizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationRequisites",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    LegalAddress = table.Column<string>(nullable: true),
                    PostAddress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 255, nullable: true),
                    Fax = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Inn = table.Column<string>(maxLength: 10, nullable: true),
                    Kpp = table.Column<string>(maxLength: 9, nullable: true),
                    Ogrn = table.Column<string>(maxLength: 13, nullable: true),
                    Okved = table.Column<string>(maxLength: 255, nullable: true),
                    Okpo = table.Column<string>(maxLength: 8, nullable: true),
                    Okato = table.Column<string>(maxLength: 11, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: true),
                    BankTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Bik = table.Column<string>(maxLength: 9, nullable: true),
                    BankCorrespAccount = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRequisites", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TitleShort = table.Column<string>(nullable: true),
                    ParentOrganizationId = table.Column<Guid>(nullable: true),
                    OrganizationTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationTypes_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "OrganizationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationDistrictLinks",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationDistrictLinks", x => new { x.OrganizationId, x.DistrictId });
                    table.ForeignKey(
                        name: "FK_OrganizationDistrictLinks_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationTypeId",
                table: "Organizations",
                column: "OrganizationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationDistrictLinks");

            migrationBuilder.DropTable(
                name: "OrganizationRequisites");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "OrganizationTypes");
        }
    }
}
