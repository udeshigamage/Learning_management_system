using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_management_system.Migrations
{
    /// <inheritdoc />
    public partial class build_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Announcement",
                columns: table => new
                {
                    Announcement_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Createddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Announcement", x => x.Announcement_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Announcement_Tb_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Tb_Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Assignment",
                columns: table => new
                {
                    Assignment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Assignment_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Assignment_Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Createddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    duedate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Module_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Assignment", x => x.Assignment_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Assignment_Tb_Coursemodules_Module_Id",
                        column: x => x.Module_Id,
                        principalTable: "Tb_Coursemodules",
                        principalColumn: "Module_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Certifications",
                columns: table => new
                {
                    Certification_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    issue_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    certificate_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Certifications", x => x.Certification_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Certifications_Tb_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Tb_Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Certifications_Tb_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Enrollment",
                columns: table => new
                {
                    Enrollment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enrollment_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    enrollmentstatus = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id1 = table.Column<int>(type: "int", nullable: false),
                    CoursesCourse_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Enrollment", x => x.Enrollment_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Enrollment_Tb_Courses_CoursesCourse_Id",
                        column: x => x.CoursesCourse_Id,
                        principalTable: "Tb_Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Enrollment_Tb_Users_User_Id1",
                        column: x => x.User_Id1,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Forums",
                columns: table => new
                {
                    ForumTopic_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ForumTopic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    createdby = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Forums", x => x.ForumTopic_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Forums_Tb_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Tb_Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Forums_Tb_Users_createdby",
                        column: x => x.createdby,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Liveclasses",
                columns: table => new
                {
                    Liveclass_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vedio_link = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Createddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Liveclasses", x => x.Liveclass_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Liveclasses_Tb_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Tb_Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Liveclasses_Tb_Users_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Quizes",
                columns: table => new
                {
                    Quiz_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quiz_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Createddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Quizes", x => x.Quiz_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Quizes_Tb_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Tb_Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Submission",
                columns: table => new
                {
                    Submission_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    submission_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    feedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    filepaths = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    grade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Assignment_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Submission", x => x.Submission_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Submission_Tb_Assignment_Assignment_Id",
                        column: x => x.Assignment_Id,
                        principalTable: "Tb_Assignment",
                        principalColumn: "Assignment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Submission_Tb_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Forumposts",
                columns: table => new
                {
                    Forumpost_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    postcontent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Createddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ForumTopic_Id = table.Column<int>(type: "int", nullable: false),
                    createdby = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Forumposts", x => x.Forumpost_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Forumposts_Tb_Forums_ForumTopic_Id",
                        column: x => x.ForumTopic_Id,
                        principalTable: "Tb_Forums",
                        principalColumn: "ForumTopic_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Forumposts_Tb_Users_createdby",
                        column: x => x.createdby,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Quizquestions",
                columns: table => new
                {
                    question_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    answertypes = table.Column<int>(type: "int", nullable: false),
                    question_text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quiz_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Quizquestions", x => x.question_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Quizquestions_Tb_Quizes_Quiz_Id",
                        column: x => x.Quiz_Id,
                        principalTable: "Tb_Quizes",
                        principalColumn: "Quiz_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Quizresult",
                columns: table => new
                {
                    result_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    datetaken = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Quiz_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Quizresult", x => x.result_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Quizresult_Tb_Quizes_Quiz_Id",
                        column: x => x.Quiz_Id,
                        principalTable: "Tb_Quizes",
                        principalColumn: "Quiz_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Quizresult_Tb_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Tb_Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Quizoptions",
                columns: table => new
                {
                    Option_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Option_text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Is_correct = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Question_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Quizoptions", x => x.Option_Id);
                    table.ForeignKey(
                        name: "FK_Tb_Quizoptions_Tb_Quizquestions_Question_Id",
                        column: x => x.Question_Id,
                        principalTable: "Tb_Quizquestions",
                        principalColumn: "question_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Announcement_Course_Id",
                table: "Tb_Announcement",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Assignment_Module_Id",
                table: "Tb_Assignment",
                column: "Module_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Certifications_Course_Id",
                table: "Tb_Certifications",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Certifications_User_Id",
                table: "Tb_Certifications",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Enrollment_CoursesCourse_Id",
                table: "Tb_Enrollment",
                column: "CoursesCourse_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Enrollment_User_Id1",
                table: "Tb_Enrollment",
                column: "User_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Forumposts_createdby",
                table: "Tb_Forumposts",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Forumposts_ForumTopic_Id",
                table: "Tb_Forumposts",
                column: "ForumTopic_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Forums_Course_Id",
                table: "Tb_Forums",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Forums_createdby",
                table: "Tb_Forums",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Liveclasses_Course_Id",
                table: "Tb_Liveclasses",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Liveclasses_instructor_id",
                table: "Tb_Liveclasses",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Quizes_Course_Id",
                table: "Tb_Quizes",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Quizoptions_Question_Id",
                table: "Tb_Quizoptions",
                column: "Question_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Quizquestions_Quiz_Id",
                table: "Tb_Quizquestions",
                column: "Quiz_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Quizresult_Quiz_Id",
                table: "Tb_Quizresult",
                column: "Quiz_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Quizresult_User_Id",
                table: "Tb_Quizresult",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Submission_Assignment_Id",
                table: "Tb_Submission",
                column: "Assignment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Submission_User_Id",
                table: "Tb_Submission",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Announcement");

            migrationBuilder.DropTable(
                name: "Tb_Certifications");

            migrationBuilder.DropTable(
                name: "Tb_Enrollment");

            migrationBuilder.DropTable(
                name: "Tb_Forumposts");

            migrationBuilder.DropTable(
                name: "Tb_Liveclasses");

            migrationBuilder.DropTable(
                name: "Tb_Quizoptions");

            migrationBuilder.DropTable(
                name: "Tb_Quizresult");

            migrationBuilder.DropTable(
                name: "Tb_Submission");

            migrationBuilder.DropTable(
                name: "Tb_Forums");

            migrationBuilder.DropTable(
                name: "Tb_Quizquestions");

            migrationBuilder.DropTable(
                name: "Tb_Assignment");

            migrationBuilder.DropTable(
                name: "Tb_Quizes");
        }
    }
}
