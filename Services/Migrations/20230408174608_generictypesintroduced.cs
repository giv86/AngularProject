using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class generictypesintroduced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionsDictionary");

            migrationBuilder.DropTable(
                name: "ConversationsToLocations");

            migrationBuilder.DropTable(
                name: "DialoguesToConversations");

            migrationBuilder.DropTable(
                name: "HeroesToUsers");

            migrationBuilder.DropTable(
                name: "LocationsToUsers");

            migrationBuilder.AddColumn<int>(
                name: "ModelType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelType",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelType",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelType",
                table: "Dialogues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelType",
                table: "Conversations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelType",
                table: "Actions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelTypeOfFrom = table.Column<int>(type: "int", nullable: false),
                    ModelTypeOfTo = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    ModelType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Dialogues");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "ModelType",
                table: "Actions");

            migrationBuilder.CreateTable(
                name: "ActionsDictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConnectedWith = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    TargetType = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionsDictionary", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConversationsToLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConnectedWith = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationsToLocations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DialoguesToConversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConnectedWith = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialoguesToConversations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HeroesToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConnectedWith = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesToUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationsToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConnectedWith = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsToUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
