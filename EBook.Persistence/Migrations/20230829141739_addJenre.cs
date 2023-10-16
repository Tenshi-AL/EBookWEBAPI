using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addJenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("3f0d14ce-8456-41c6-be14-e135dee18d28"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("50b69098-92c5-4a91-a738-389e2b5bb30b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("99664a28-969e-44ee-9dbc-a21dece280cd"));

            migrationBuilder.AddColumn<Guid>(
                name: "JenreId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Jenres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jenres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "BookLanguage" },
                values: new object[,]
                {
                    { new Guid("11d7177e-02e8-4eca-9245-dbec83fc2be9"), "RU" },
                    { new Guid("99815ee4-48b5-49ea-b9e5-e01c710df6b3"), "USA" },
                    { new Guid("f8e8ea0b-a7da-4667-9cf2-dc5f5c973438"), "UA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_JenreId",
                table: "Books",
                column: "JenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Jenres_JenreId",
                table: "Books",
                column: "JenreId",
                principalTable: "Jenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Jenres_JenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Jenres");

            migrationBuilder.DropIndex(
                name: "IX_Books_JenreId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("11d7177e-02e8-4eca-9245-dbec83fc2be9"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("99815ee4-48b5-49ea-b9e5-e01c710df6b3"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f8e8ea0b-a7da-4667-9cf2-dc5f5c973438"));

            migrationBuilder.DropColumn(
                name: "JenreId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "BookLanguage" },
                values: new object[,]
                {
                    { new Guid("3f0d14ce-8456-41c6-be14-e135dee18d28"), "USA" },
                    { new Guid("50b69098-92c5-4a91-a738-389e2b5bb30b"), "UA" },
                    { new Guid("99664a28-969e-44ee-9dbc-a21dece280cd"), "RU" }
                });
        }
    }
}
