using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XiangXunBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "x_categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_x_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "x_users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_x_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "x_posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_x_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_x_posts_x_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "x_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_x_posts_x_users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "x_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_x_posts_AuthorId",
                table: "x_posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_x_posts_CategoryId",
                table: "x_posts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "x_posts");

            migrationBuilder.DropTable(
                name: "x_categories");

            migrationBuilder.DropTable(
                name: "x_users");
        }
    }
}
