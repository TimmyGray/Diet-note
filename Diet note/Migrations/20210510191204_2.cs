using Microsoft.EntityFrameworkCore.Migrations;

namespace Diet_note.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Users_UserId",
                table: "Edges");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Edges");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Edges",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Users_UserId",
                table: "Edges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Users_UserId",
                table: "Edges");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Edges",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Edges",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Users_UserId",
                table: "Edges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
