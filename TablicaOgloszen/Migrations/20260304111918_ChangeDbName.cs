using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TablicaOgloszen.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Posty",
                table: "Posty");

            migrationBuilder.RenameTable(
                name: "Posty",
                newName: "Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Posty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posty",
                table: "Posty",
                column: "Id");
        }
    }
}
