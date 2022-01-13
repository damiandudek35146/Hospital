using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataLayer.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_UserId",
                table: "ContactInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Patients");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Patients",
                newName: "ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Login",
                table: "Patients",
                newName: "IX_Patients_Login");

            migrationBuilder.RenameIndex(
                name: "IX_User_BedId",
                table: "Patients",
                newName: "IX_Patients_BedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_ContactInfo_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "ContactInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ContactInfoId",
                table: "Patients",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ContactInfoId",
                table: "Doctor",
                column: "ContactInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialisation_Doctor_DoctorsId",
                table: "DoctorSpecialisation",
                column: "DoctorsId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Beds_BedId",
                table: "Patients",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ContactInfo_ContactInfoId",
                table: "Patients",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Doctor_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Patients_PatientId",
                table: "Treatments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialisation_Doctor_DoctorsId",
                table: "DoctorSpecialisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Beds_BedId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ContactInfo_ContactInfoId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Doctor_DoctorId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Patients_PatientId",
                table: "Treatments");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ContactInfoId",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "ContactInfoId",
                table: "User",
                newName: "AccountType");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Login",
                table: "User",
                newName: "IX_User_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_BedId",
                table: "User",
                newName: "IX_User_BedId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ContactInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_UserId",
                table: "ContactInfo",
                column: "UserId",
                unique: true);

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
    }
}
