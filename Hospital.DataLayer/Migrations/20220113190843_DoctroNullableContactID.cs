using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataLayer.Migrations
{
    public partial class DoctroNullableContactID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_ContactInfo_ContactInfoId",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoId",
                table: "Doctor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_ContactInfo_ContactInfoId",
                table: "Doctor",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_ContactInfo_ContactInfoId",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_ContactInfo_ContactInfoId",
                table: "Doctor",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
