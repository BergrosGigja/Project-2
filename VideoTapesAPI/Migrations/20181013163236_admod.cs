using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoTapesAPI.Migrations
{
    public partial class admod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FriendId = table.Column<int>(nullable: false),
                    TapeId = table.Column<int>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowDto_Tapes_TapeId",
                        column: x => x.TapeId,
                        principalTable: "Tapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowDto_TapeId",
                table: "BorrowDto",
                column: "TapeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowDto");
        }
    }
}
