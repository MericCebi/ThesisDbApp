using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThesisDbApp.Migrations
{
    /// <inheritdoc />
    public partial class Branches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ShareStocks = table.Column<int>(type: "int", nullable: false),
                    ShareBonds = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "273e3004-ddf3-4330-90e0-a2958dfa5f6b", "3430f1e1-89b6-43e0-b333-63544147e83c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wuerzburg" },
                    { 2, "New York" },
                    { 3, "Tokyo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BranchId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "25ce1e17-b7fa-47d6-b0d8-e45cf0c2b845", 0, 2, "b5b33492-7655-49a0-a5f9-9a1d510f67cc", "admin@abc.com", false, false, null, "ADMIN@ABC.COM", "ADMIN@ABC.COM", "AQAAAAEAACcQAAAAEMw3ktUNa2VzYkd1bvU6Q0vyUWtCnOW2C/ukChhZU2LleqEC+5G/3GWIslim7IubJQ==", null, false, "5eb82af4-3f9f-4dd9-9ff6-2e059c5d2a98", false, "admin@abc.com" },
                    { "32d77755-b75c-4fac-a3ee-d6d116ead346", 0, 1, "6ccd3533-4e31-41b0-bc92-aa88ad911157", "erika@abc.com", false, false, null, "ERIKA@ABC.COM", "ERIKA@ABC.COM", "AQAAAAEAACcQAAAAEIL/qOcVgbMDr1ZXWowFZhUdj2TXEA1zVS6J3FStRm6qmdkvUMx2EkJnMnWUIwNzyQ==", null, false, "5f7e4364-68ff-4d1e-995a-3c528843ea9a", false, "erika@abc.com" },
                    { "334da8d4-da44-458f-bb8f-255d448dfa0d", 0, 2, "673a9c52-20ff-4feb-b71a-0f26fe588759", "john@abc.com", false, false, null, "JOHN@ABC.COM", "JOHN@ABC.COM", "AQAAAAEAACcQAAAAECg9wqkTcxUMOt6kHSXx1bLD6FrIHzj84G29b0I6gQ93b+RzvU51y9c4Idh/cUPxKg==", null, false, "688d7e0c-3ccc-40e6-8e00-3d74c6c4dcaa", false, "john@abc.com" },
                    { "d3ab4607-a098-4628-a594-bc2b08573f5e", 0, 3, "f06d46b2-a538-4485-9668-9d84a3ed21c3", "sakura@abc.com", false, false, null, "SAKURA@ABC.COM", "SAKURA@ABC.COM", "AQAAAAEAACcQAAAAEC4ymlNXQhdnpGMIIV0OI+ieH0m6wskF2uon1z7xV8DeUSIoZKVTcaefaUTA47IjUw==", null, false, "baad417a-d54e-4c27-bcd6-7e4439e26400", false, "sakura@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "BranchId", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[,]
                {
                    { 1, new DateTime(1964, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "franziska.gamma@uni-wuerzburg.de", 0, "Franziska Gamma", 44, 56 },
                    { 2, new DateTime(1953, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "christian.epsilon@uni-wuerzburg.de", 1, "Christian Epsilon", 22, 78 },
                    { 3, new DateTime(1960, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "berta.omega@uni-wuerzburg.de", 0, "Berta Omega", 97, 3 },
                    { 4, new DateTime(1993, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "egon.alpha@uni-wuerzburg.de", 1, "Egon Alpha", 92, 8 },
                    { 5, new DateTime(1998, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "egon.gamma@uni-wuerzburg.de", 0, "Egon Gamma", 98, 2 },
                    { 6, new DateTime(1984, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "franziska.alpha@uni-wuerzburg.de", 1, "Franziska Alpha", 90, 10 },
                    { 7, new DateTime(1997, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "daniela.omega@uni-wuerzburg.de", 0, "Daniela Omega", 13, 87 },
                    { 8, new DateTime(1966, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "berta.gamma@uni-wuerzburg.de", 1, "Berta Gamma", 76, 24 },
                    { 9, new DateTime(1997, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "daniela.gamma@uni-wuerzburg.de", 0, "Daniela Gamma", 20, 80 },
                    { 10, new DateTime(1962, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "anton.omega@uni-wuerzburg.de", 1, "Anton Omega", 16, 84 },
                    { 11, new DateTime(1988, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "daniela.delta@uni-wuerzburg.de", 0, "Daniela Delta", 96, 4 },
                    { 12, new DateTime(1985, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "franziska.alpha@uni-wuerzburg.de", 1, "Franziska Alpha", 72, 28 },
                    { 13, new DateTime(1997, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "daniela.beta@uni-wuerzburg.de", 0, "Daniela Beta", 77, 23 },
                    { 14, new DateTime(1973, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "egon.alpha@uni-wuerzburg.de", 1, "Egon Alpha", 6, 94 },
                    { 15, new DateTime(1973, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "franziska.gamma@uni-wuerzburg.de", 0, "Franziska Gamma", 2, 98 },
                    { 16, new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "berta.omega@uni-wuerzburg.de", 1, "Berta Omega", 8, 92 },
                    { 17, new DateTime(1981, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "franziska.omega@uni-wuerzburg.de", 0, "Franziska Omega", 8, 92 },
                    { 18, new DateTime(1967, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "franziska.beta@uni-wuerzburg.de", 1, "Franziska Beta", 85, 15 },
                    { 19, new DateTime(1959, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "egon.omega@uni-wuerzburg.de", 0, "Egon Omega", 41, 59 },
                    { 20, new DateTime(1998, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "egon.epsilon@uni-wuerzburg.de", 1, "Egon Epsilon", 86, 14 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "273e3004-ddf3-4330-90e0-a2958dfa5f6b", "25ce1e17-b7fa-47d6-b0d8-e45cf0c2b845" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchId",
                table: "Customers",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
