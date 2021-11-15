using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyManagerWebAPI.Migrations
{
    public partial class FamC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    StreetName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    HouseNumber = table.Column<int>(type: "INTEGER", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => new { x.HouseNumber, x.StreetName });
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    Type = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => new { x.Description, x.Type });
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobTitle = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Salary = table.Column<int>(type: "INTEGER", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => new { x.Salary, x.JobTitle });
                });

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyHouseNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyStreetName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    HairColor = table.Column<string>(type: "TEXT", nullable: true),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Child_Families_FamilyHouseNumber_FamilyStreetName",
                        columns: x => new { x.FamilyHouseNumber, x.FamilyStreetName },
                        principalTable: "Families",
                        principalColumns: new[] { "HouseNumber", "StreetName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobSalary = table.Column<int>(type: "INTEGER", nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyHouseNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyStreetName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    HairColor = table.Column<string>(type: "TEXT", nullable: true),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adult_Families_FamilyHouseNumber_FamilyStreetName",
                        columns: x => new { x.FamilyHouseNumber, x.FamilyStreetName },
                        principalTable: "Families",
                        principalColumns: new[] { "HouseNumber", "StreetName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adult_Job_JobSalary_JobTitle",
                        columns: x => new { x.JobSalary, x.JobTitle },
                        principalTable: "Job",
                        principalColumns: new[] { "Salary", "JobTitle" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildInterest",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterestsDescription = table.Column<string>(type: "TEXT", nullable: false),
                    InterestsType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildInterest", x => new { x.ChildrenId, x.InterestsDescription, x.InterestsType });
                    table.ForeignKey(
                        name: "FK_ChildInterest_Child_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildInterest_Interest_InterestsDescription_InterestsType",
                        columns: x => new { x.InterestsDescription, x.InterestsType },
                        principalTable: "Interest",
                        principalColumns: new[] { "Description", "Type" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Species = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    ChildId = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyHouseNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyStreetName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pet_Families_FamilyHouseNumber_FamilyStreetName",
                        columns: x => new { x.FamilyHouseNumber, x.FamilyStreetName },
                        principalTable: "Families",
                        principalColumns: new[] { "HouseNumber", "StreetName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adult_FamilyHouseNumber_FamilyStreetName",
                table: "Adult",
                columns: new[] { "FamilyHouseNumber", "FamilyStreetName" });

            migrationBuilder.CreateIndex(
                name: "IX_Adult_JobSalary_JobTitle",
                table: "Adult",
                columns: new[] { "JobSalary", "JobTitle" });

            migrationBuilder.CreateIndex(
                name: "IX_Child_FamilyHouseNumber_FamilyStreetName",
                table: "Child",
                columns: new[] { "FamilyHouseNumber", "FamilyStreetName" });

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterest_InterestsDescription_InterestsType",
                table: "ChildInterest",
                columns: new[] { "InterestsDescription", "InterestsType" });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ChildId",
                table: "Pet",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_FamilyHouseNumber_FamilyStreetName",
                table: "Pet",
                columns: new[] { "FamilyHouseNumber", "FamilyStreetName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adult");

            migrationBuilder.DropTable(
                name: "ChildInterest");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
