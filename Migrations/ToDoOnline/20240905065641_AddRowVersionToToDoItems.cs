using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations.ToDoOnline
{
    public partial class AddRowVersionToToDoItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ToDoItems",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ToDoItems");
        }
    }
}
