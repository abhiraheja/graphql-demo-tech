using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo1.Migrations
{
    /// <inheritdoc />
    public partial class inititals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstructorTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FatherName = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FatherName = table.Column<string>(type: "TEXT", nullable: true),
                    RollNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourseTbl_CourseTbl_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseTbl_StudentTbl_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubjectTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubjectTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSubjectTbl_CourseTbl_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubjectTbl_SubjectTbl_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSubjectTbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstratuctorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSubjectTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorSubjectTbl_InstructorTbl_InstratuctorId",
                        column: x => x.InstratuctorId,
                        principalTable: "InstructorTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorSubjectTbl_SubjectTbl_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjectTbl_CourseId",
                table: "CourseSubjectTbl",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjectTbl_SubjectId",
                table: "CourseSubjectTbl",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubjectTbl_InstratuctorId",
                table: "InstructorSubjectTbl",
                column: "InstratuctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubjectTbl_SubjectId",
                table: "InstructorSubjectTbl",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseTbl_CourseId",
                table: "StudentCourseTbl",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseTbl_StudentId",
                table: "StudentCourseTbl",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSubjectTbl");

            migrationBuilder.DropTable(
                name: "InstructorSubjectTbl");

            migrationBuilder.DropTable(
                name: "StudentCourseTbl");

            migrationBuilder.DropTable(
                name: "InstructorTbl");

            migrationBuilder.DropTable(
                name: "SubjectTbl");

            migrationBuilder.DropTable(
                name: "CourseTbl");

            migrationBuilder.DropTable(
                name: "StudentTbl");
        }
    }
}
