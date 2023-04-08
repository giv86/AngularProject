using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class gameclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Locations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Dialogues",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Conversations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Actions",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DisplayText",
                table: "Locations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dialogues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DisplayText",
                table: "Dialogues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Conversations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DisplayText",
                table: "Conversations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Actions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DisplayText",
                table: "Actions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DisplayText",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dialogues");

            migrationBuilder.DropColumn(
                name: "DisplayText",
                table: "Dialogues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "DisplayText",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "DisplayText",
                table: "Actions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Locations",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dialogues",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Conversations",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Actions",
                newName: "Key");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Heroes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
