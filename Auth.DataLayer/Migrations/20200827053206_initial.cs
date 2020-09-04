using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Snils = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RegistrationAddress = table.Column<string>(nullable: true),
                    FactAddress = table.Column<string>(nullable: true),
                    OtherPhones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AuthToken = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    LastActionTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false),
                    RuleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.RoleId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_Permissions_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleSystemModuleLinks",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    SystemModuleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSystemModuleLinks", x => new { x.RoleId, x.SystemModuleId });
                    table.ForeignKey(
                        name: "FK_RoleSystemModuleLinks_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSystemModuleLinks_SystemModules_SystemModuleId",
                        column: x => x.SystemModuleId,
                        principalTable: "SystemModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleLinks",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleLinks", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoleLinks_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleLinks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingEntityOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SystemModuleId = table.Column<Guid>(nullable: false),
                    WorkingEntityId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingEntityOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingEntityOperations_SystemModules_SystemModuleId",
                        column: x => x.SystemModuleId,
                        principalTable: "SystemModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingEntityOperations_WorkingEntities_WorkingEntityId",
                        column: x => x.WorkingEntityId,
                        principalTable: "WorkingEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_OperationId",
                table: "Permissions",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RuleId",
                table: "Permissions",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSystemModuleLinks_SystemModuleId",
                table: "RoleSystemModuleLinks",
                column: "SystemModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleLinks_RoleId",
                table: "UserRoleLinks",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingEntityOperations_SystemModuleId",
                table: "WorkingEntityOperations",
                column: "SystemModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingEntityOperations_WorkingEntityId",
                table: "WorkingEntityOperations",
                column: "WorkingEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RoleSystemModuleLinks");

            migrationBuilder.DropTable(
                name: "UserRoleLinks");

            migrationBuilder.DropTable(
                name: "WorkingEntityOperations");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SystemModules");

            migrationBuilder.DropTable(
                name: "WorkingEntities");
        }
    }
}
