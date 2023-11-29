using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "e505d9dd-dc13-4725-992a-9fa2b5ba125a", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEH7SHGHEDs9l7hvw4bnqVgeactqhrtxPMwkYT0zuT5vu25FNrhI7vgZmuxkR+QvfLA==", null, false, "577fe861-402f-4679-91aa-d43e13806936", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(2582), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(2593), "Black", "System" },
                    { 2, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(2596), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(2597), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3117), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3119), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3121), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3122), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3427), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3428), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3430), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3430), "X5", "System" },
                    { 3, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3432), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3432), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3433), new DateTime(2023, 11, 29, 9, 37, 32, 901, DateTimeKind.Local).AddTicks(3434), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
