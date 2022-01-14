using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataLayer.Migrations
{
    public partial class addSToDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_ContactInfo_ContactInfoId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialisation_Doctor_DoctorsId",
                table: "DoctorSpecialisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Doctor_DoctorId",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameIndex(
                name: "IX_Doctor_Login",
                table: "Doctors",
                newName: "IX_Doctors_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Doctor_ContactInfoId",
                table: "Doctors",
                newName: "IX_Doctors_ContactInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_ContactInfo_ContactInfoId",
                table: "Doctors",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialisation_Doctors_DoctorsId",
                table: "DoctorSpecialisation",
                column: "DoctorsId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Doctors_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_ContactInfo_ContactInfoId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialisation_Doctors_DoctorsId",
                table: "DoctorSpecialisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Doctors_DoctorId",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_Login",
                table: "Doctor",
                newName: "IX_Doctor_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ContactInfoId",
                table: "Doctor",
                newName: "IX_Doctor_ContactInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_ContactInfo_ContactInfoId",
                table: "Doctor",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialisation_Doctor_DoctorsId",
                table: "DoctorSpecialisation",
                column: "DoctorsId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Doctor_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");
        }
    }
}
