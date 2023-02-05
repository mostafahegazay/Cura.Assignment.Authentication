using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cura.Assignment.Authentication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionsIdentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesIdentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersIdentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersIdentity_RolesIdentity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RolesIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionsIdentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermssionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionsIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissionsIdentity_PermissionsIdentity_PermssionId",
                        column: x => x.PermssionId,
                        principalTable: "PermissionsIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissionsIdentity_UsersIdentity_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionsIdentity",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("06c64da8-221e-4eab-8145-710ef6e8f962"), new DateTime(2023, 2, 5, 22, 56, 38, 403, DateTimeKind.Local).AddTicks(882), "b_game" },
                    { new Guid("998351e7-91de-49d7-9ef6-20d0898d7786"), new DateTime(2023, 2, 5, 22, 56, 38, 403, DateTimeKind.Local).AddTicks(878), "vip_chararacter_personalize" }
                });

            migrationBuilder.InsertData(
                table: "RolesIdentity",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("7d64f5c3-c11b-456e-9f24-9f3f21871b25"), new DateTime(2023, 2, 5, 22, 56, 38, 403, DateTimeKind.Local).AddTicks(793), "player" },
                    { new Guid("f4391979-5c20-4207-b51a-e3dd7481fdf8"), new DateTime(2023, 2, 5, 22, 56, 38, 403, DateTimeKind.Local).AddTicks(735), "admin" }
                });

            migrationBuilder.InsertData(
                table: "UsersIdentity",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "RoleId", "Salt" },
                values: new object[] { new Guid("68bb1f70-00cf-4a03-9a7a-bae4e2448da5"), new DateTime(2023, 2, 5, 22, 56, 38, 403, DateTimeKind.Local).AddTicks(898), "mostafa.emad@hotmail.com", "Mostafa Emad", "uZaIgLj/hmp77MzARRNYIdJMxbmB9uKzXJHf4xfq+Ro=", new Guid("f4391979-5c20-4207-b51a-e3dd7481fdf8"), "Srrf53wM+crCUvybDv1WzbUzKFrLaowe5dKErJKo/+KTNO6e41hGDg==" });

            migrationBuilder.InsertData(
                table: "UserPermissionsIdentity",
                columns: new[] { "Id", "CreatedAt", "PermssionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0283b732-4f02-4fbc-a01c-a752497cef1c"), new DateTime(2023, 2, 5, 22, 56, 38, 404, DateTimeKind.Local).AddTicks(3890), new Guid("06c64da8-221e-4eab-8145-710ef6e8f962"), new Guid("68bb1f70-00cf-4a03-9a7a-bae4e2448da5") },
                    { new Guid("e96129cb-77fc-462a-b022-cad105159b11"), new DateTime(2023, 2, 5, 22, 56, 38, 404, DateTimeKind.Local).AddTicks(3886), new Guid("998351e7-91de-49d7-9ef6-20d0898d7786"), new Guid("68bb1f70-00cf-4a03-9a7a-bae4e2448da5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionsIdentity_PermssionId",
                table: "UserPermissionsIdentity",
                column: "PermssionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionsIdentity_UserId",
                table: "UserPermissionsIdentity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersIdentity_Email",
                table: "UsersIdentity",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersIdentity_RoleId",
                table: "UsersIdentity",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissionsIdentity");

            migrationBuilder.DropTable(
                name: "PermissionsIdentity");

            migrationBuilder.DropTable(
                name: "UsersIdentity");

            migrationBuilder.DropTable(
                name: "RolesIdentity");
        }
    }
}
