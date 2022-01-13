using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataLayer.Migrations
{
    public partial class RemoveUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Users_UserId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialisation_Users_DoctorsId",
                table: "DoctorSpecialisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Users_DoctorId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Users_PatientId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Beds_BedId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Login",
                table: "User",
                newName: "IX_User_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BedId",
                table: "User",
                newName: "IX_User_BedId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "IdCardNumber",
                table: "User",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_User_UserId",
                table: "ContactInfo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialisation_User_DoctorsId",
                table: "DoctorSpecialisation",
                column: "DoctorsId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_User_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_User_PatientId",
                table: "Treatments",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Beds_BedId",
                table: "User",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_User_UserId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialisation_User_DoctorsId",
                table: "DoctorSpecialisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_User_DoctorId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_User_PatientId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Beds_BedId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_Login",
                table: "Users",
                newName: "IX_Users_Login");

            migrationBuilder.RenameIndex(
                name: "IX_User_BedId",
                table: "Users",
                newName: "IX_Users_BedId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IdCardNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Users_UserId",
                table: "ContactInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialisation_Users_DoctorsId",
                table: "DoctorSpecialisation",
                column: "DoctorsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Users_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Users_PatientId",
                table: "Treatments",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Beds_BedId",
                table: "Users",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");
        }
    }
}
