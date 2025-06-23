﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XiangXunBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admins",
                newName: "Password");
        }
    }
}
