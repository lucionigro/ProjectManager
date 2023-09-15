using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Migrations
{
    public partial class initialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    USER_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    OWNER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Users_OWNER_ID",
                        column: x => x.OWNER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUMMARY = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    REPORTER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DUE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Issues_Projects_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Users_REPORTER_ID",
                        column: x => x.REPORTER_ID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_PROJECT_ID",
                table: "Issues",
                column: "PROJECT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_REPORTER_ID",
                table: "Issues",
                column: "REPORTER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OWNER_ID",
                table: "Projects",
                column: "OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_USERNAME",
                table: "Users",
                column: "USERNAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
