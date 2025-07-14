using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mission.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    city_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CMS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    slug = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    modified_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email_address = table.Column<string>(type: "text", nullable: true),
                    subject = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ForgotPassword",
                columns: table => new
                {
                    temp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    request_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPassword", x => x.temp_id);
                });

            migrationBuilder.CreateTable(
                name: "MissionSkill",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skill_name = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionSkill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MissionTheme",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    theme_name = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionTheme", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    email_address = table.Column<string>(type: "text", nullable: true),
                    user_type = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    user_image = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skill = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mission_title = table.Column<string>(type: "text", nullable: true),
                    mission_description = table.Column<string>(type: "text", nullable: true),
                    mission_organisation_name = table.Column<string>(type: "text", nullable: true),
                    mission_organisation_detail = table.Column<string>(type: "text", nullable: true),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "Date", nullable: false),
                    end_date = table.Column<DateTime>(type: "Date", nullable: false),
                    mission_type = table.Column<string>(type: "text", nullable: true),
                    total_sheets = table.Column<int>(type: "integer", nullable: true),
                    registration_deadline = table.Column<DateTime>(type: "Date", nullable: true),
                    mission_theme_id = table.Column<int>(type: "integer", nullable: false),
                    mission_skill_id = table.Column<string>(type: "text", nullable: true),
                    mission_images = table.Column<string>(type: "text", nullable: true),
                    mission_documents = table.Column<string>(type: "text", nullable: true),
                    mission_availability = table.Column<string>(type: "text", nullable: true),
                    mission_video_url = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Missions_City_city_id",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Country_country_id",
                        column: x => x.country_id,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_MissionTheme_mission_theme_id",
                        column: x => x.mission_theme_id,
                        principalTable: "MissionTheme",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    employee_id = table.Column<string>(type: "text", nullable: true),
                    manager = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    department = table.Column<string>(type: "text", nullable: true),
                    my_profile = table.Column<string>(type: "text", nullable: true),
                    why_i_volunteer = table.Column<string>(type: "text", nullable: true),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    availability = table.Column<string>(type: "text", nullable: true),
                    linkd_in_url = table.Column<string>(type: "text", nullable: true),
                    my_skills = table.Column<string>(type: "text", nullable: true),
                    user_image = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserDetail_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionApplication",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    applied_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    sheet = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionApplication", x => x.id);
                    table.ForeignKey(
                        name: "FK_MissionApplication_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionApplication_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionComment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    comment_description = table.Column<string>(type: "text", nullable: true),
                    comment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionComment", x => x.id);
                    table.ForeignKey(
                        name: "FK_MissionComment_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionComment_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionFavourites",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionFavourites", x => x.id);
                    table.ForeignKey(
                        name: "FK_MissionFavourites_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionFavourites_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionRating",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionRating", x => x.id);
                    table.ForeignKey(
                        name: "FK_MissionRating_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionRating_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    story_title = table.Column<string>(type: "text", nullable: true),
                    story_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    story_description = table.Column<string>(type: "text", nullable: true),
                    video_url = table.Column<string>(type: "text", nullable: true),
                    story_image = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    story_viewer_count = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.id);
                    table.ForeignKey(
                        name: "FK_Story_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Story_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteeringGoals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "Date", nullable: false),
                    action = table.Column<int>(type: "integer", nullable: false),
                    message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteeringGoals", x => x.id);
                    table.ForeignKey(
                        name: "FK_VolunteeringGoals_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteeringGoals_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteeringHours",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    mission_id = table.Column<int>(type: "integer", nullable: false),
                    date_volunteered = table.Column<DateTime>(type: "Date", nullable: false),
                    hours = table.Column<string>(type: "text", nullable: true),
                    minutes = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteeringHours", x => x.id);
                    table.ForeignKey(
                        name: "FK_VolunteeringHours_Missions_mission_id",
                        column: x => x.mission_id,
                        principalTable: "Missions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteeringHours_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "CreatedDate", "email_address", "first_name", "IsDeleted", "last_name", "ModifiedDate", "password", "phone_number", "user_image", "user_type" },
                values: new object[] { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@tatvasoft.com", "Tatva", false, "Admin", null, "Tatva@123", "9876543210", "", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_MissionApplication_mission_id",
                table: "MissionApplication",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionApplication_user_id",
                table: "MissionApplication",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionComment_mission_id",
                table: "MissionComment",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionComment_user_id",
                table: "MissionComment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionFavourites_mission_id",
                table: "MissionFavourites",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionFavourites_user_id",
                table: "MissionFavourites",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionRating_mission_id",
                table: "MissionRating",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_MissionRating_user_id",
                table: "MissionRating",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_city_id",
                table: "Missions",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_country_id",
                table: "Missions",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_mission_theme_id",
                table: "Missions",
                column: "mission_theme_id");

            migrationBuilder.CreateIndex(
                name: "IX_Story_mission_id",
                table: "Story",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_Story_user_id",
                table: "Story",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_user_id",
                table: "UserDetail",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringGoals_mission_id",
                table: "VolunteeringGoals",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringGoals_user_id",
                table: "VolunteeringGoals",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringHours_mission_id",
                table: "VolunteeringHours",
                column: "mission_id");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringHours_user_id",
                table: "VolunteeringHours",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMS");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "ForgotPassword");

            migrationBuilder.DropTable(
                name: "MissionApplication");

            migrationBuilder.DropTable(
                name: "MissionComment");

            migrationBuilder.DropTable(
                name: "MissionFavourites");

            migrationBuilder.DropTable(
                name: "MissionRating");

            migrationBuilder.DropTable(
                name: "MissionSkill");

            migrationBuilder.DropTable(
                name: "Story");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "VolunteeringGoals");

            migrationBuilder.DropTable(
                name: "VolunteeringHours");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "MissionTheme");
        }
    }
}
