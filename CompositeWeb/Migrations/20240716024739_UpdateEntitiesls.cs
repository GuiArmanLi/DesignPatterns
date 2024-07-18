using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompositeWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdFromFavoriteBooks",
                table: "Users",
                newName: "FavoriteBookId");

            migrationBuilder.RenameColumn(
                name: "Describe",
                table: "Chapter",
                newName: "Images");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAdult",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Chapter",
                type: "varchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Chapter",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "NextChapter",
                table: "Chapter",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NumberOfChapter",
                table: "Chapter",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PreviousChapter",
                table: "Chapter",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Books",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Books",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Nationality = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_NextChapter",
                table: "Chapter",
                column: "NextChapter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_NumberOfChapter",
                table: "Chapter",
                column: "NumberOfChapter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_PreviousChapter",
                table: "Chapter",
                column: "PreviousChapter",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_NextChapter",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_NumberOfChapter",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_PreviousChapter",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsAdult",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "NextChapter",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "NumberOfChapter",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "PreviousChapter",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "FavoriteBookId",
                table: "Users",
                newName: "IdFromFavoriteBooks");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Chapter",
                newName: "Describe");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Chapter",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldMaxLength: 75)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Books",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
