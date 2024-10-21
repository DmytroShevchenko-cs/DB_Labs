using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lab3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    HumanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.HumanId);
                });

            migrationBuilder.CreateTable(
                name: "Polyclinics",
                columns: table => new
                {
                    PolyclinicId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polyclinics", x => x.PolyclinicId);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_Administrators_Humans_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Humans_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Humans_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PolyclinicId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Polyclinics_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinics",
                        principalColumn: "PolyclinicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "serial", nullable: false),
                    CardCreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PolicyNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_Patients_CardId",
                        column: x => x.CardId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDistricts",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    DateOfStartWork = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfEndWork = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDistricts", x => new { x.DoctorId, x.DistrictId });
                    table.ForeignKey(
                        name: "FK_DoctorDistricts_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorDistricts_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    RoomNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Diagnosis = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prescriptions = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsSickLeaveIssued = table.Column<bool>(type: "boolean", nullable: false),
                    SickLeaveDuration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_PolyclinicId",
                table: "Districts",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDistricts_DistrictId",
                table: "DoctorDistricts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DistrictId",
                table: "Schedules",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ScheduleId",
                table: "Visits",
                column: "ScheduleId");
            
                        migrationBuilder.Sql(
                "INSERT INTO \"Humans\" (\"FirstName\", \"LastName\", \"MiddleName\", \"Gender\", \"Age\", \"DateOfBirth\")" +
                "VALUES" +
                "('John', 'Doe', 'Michael', 1, 35, '1989-03-25')," +
                "('Jane', 'Smith', 'Anna', 2, 28, '1996-07-10')," +
                "('Richard', 'Miles', 'James', 1, 42, '1981-01-15')," +
                "('Sarah', 'Johnson', 'Louise', 2, 30, '1993-09-09')," +
                "('David', 'Brown', 'Henry', 1, 55, '1969-11-11')," +
                "('Emily', 'Davis', 'Grace', 2, 24, '1999-02-12')," +
                "('Michael', 'Wilson', 'George', 1, 38, '1985-07-07')," +
                "('Laura', 'Taylor', 'Marie', 2, 31, '1992-11-22');");
                        
            migrationBuilder.Sql(
                "INSERT INTO \"Patients\" (\"PatientId\", \"CardId\", \"Address\", \"IsActive\") " +
                "VALUES " +
                "(1, 1, '123 Elm St', true)," +
                "(2, 2, '456 Oak Ave', true)," +
                "(3, 3, '789 Pine Ln', true)," +
                "(4, 4, '321 Maple Blvd', true)," +
                "(5, 5, '654 Cedar Ct', true)," +
                "(6, 6, '987 Walnut Rd', true)," +
                "(7, 7, '543 Pinewood St', true)," +
                "(8, 8, '789 Cedar Dr', true);");
                        
            migrationBuilder.Sql(
                "INSERT INTO \"Cards\" ( \"CardCreationDate\", \"PolicyNumber\") " +
                "VALUES " +
                "('2021-03-25', 'POL123456')," +
                "('2022-05-12', 'POL654321')," +
                "('2020-01-05', 'POL789012')," +
                "('2021-09-11', 'POL345678')," +
                "('2023-06-30', 'POL567890')," +
                "('2022-08-22', 'POL678901')," +
                "('2023-02-14', 'POL345432')," +
                "('2021-11-15', 'POL567321');");
          

            migrationBuilder.Sql(
                "INSERT INTO \"Doctors\" (\"DoctorId\", \"Category\", \"Experience\", \"IsActive\") " +
                "VALUES " +
                "(3, 'Cardiologist', 10, true)," +
                "(1, 'General Practitioner', 5, true)," +
                "(4, 'Pediatrician', 6, true)," +
                "(5, 'Surgeon', 15, true)," +
                "(7, 'Neurologist', 9, true)," +
                "(8, 'Dermatologist', 7, true)," +
                "(2, 'Endocrinologist', 8, true)," +
                "(6, 'Cardiologist', 7, true);");

            migrationBuilder.Sql(
                "INSERT INTO \"Polyclinics\" (\"Name\", \"Address\") " +
                "VALUES " +
                "('Central Polyclinic', '100 Main St')," +
                "('Northside Medical Center', '200 North St')," +
                "('Eastside Clinic', '300 East Ave')," +
                "('Westside Healthcare', '400 West Blvd')," +
                "('Southside Medical Plaza', '500 South St');");

            migrationBuilder.Sql(
                "INSERT INTO \"Districts\" (\"PolyclinicId\", \"Name\", \"Floor\") " +
                "VALUES " +
                "(1, 'District 1', 2)," +
                "(1, 'District 2', 3)," +
                "(2, 'District 3', 1)," +
                "(2, 'District 4', 4)," +
                "(3, 'District 5', 2)," +
                "(4, 'District 6', 3)," +
                "(5, 'District 7', 1);");

            migrationBuilder.Sql(
                "INSERT INTO \"DoctorDistricts\" (\"DoctorId\", \"DistrictId\", \"DateOfStartWork\") " +
                "VALUES " +
                "(1, 1, '2018-03-25')," +
                "(2, 2, '2019-02-24')," +
                "(3, 3, '2021-06-09')," +
                "(4, 4, '2020-07-16')," +
                "(5, 5, '2021-08-01')," +
                "(6, 6, '2023-02-21')," +
                "(7, 7, '2022-11-12');");

            migrationBuilder.Sql(
                "INSERT INTO \"Schedules\" (\"DoctorId\", \"DistrictId\", \"StartTime\", \"EndTime\", \"Day\", \"RoomNumber\") " +
                "VALUES " +
                "(1, 1, '09:00', '17:00', 1, 101)," +
                "(1, 1, '09:00', '17:00', 3, 101)," +
                "(2, 2, '10:00', '16:00', 2, 102)," +
                "(2, 2, '10:00', '16:00', 4, 102)," +
                "(2, 2, '08:00', '14:00', 1, 103)," +
                "(3, 3, '08:00', '14:00', 5, 103)," +
                "(4, 4, '12:00', '18:00', 2, 104)," +
                "(4, 4, '12:00', '18:00', 5, 104)," +
                "(5, 5, '09:00', '15:00', 3, 105)," +
                "(5, 5, '09:00', '15:00', 4, 105)," +
                "(6, 6, '11:00', '19:00', 1, 106)," +
                "(6, 6, '11:00', '19:00', 2, 106)," +
                "(7, 7, '08:00', '13:00', 4, 107)," +
                "(7, 7, '08:00', '13:00', 5, 107);");

            migrationBuilder.Sql(
                "INSERT INTO \"Visits\" (\"PatientId\", \"ScheduleId\", \"VisitDate\", \"Diagnosis\", \"Prescriptions\", \"IsSickLeaveIssued\", \"SickLeaveDuration\") " +
                "VALUES " +
                "(1, 1, '2024-09-01 09:00:00', 'Flu', 'Paracetamol', TRUE, '2024-09-10')," +
                "(1, 2, '2024-09-10 10:00:00', 'Headache', 'Ibuprofen', FALSE, NULL)," +
                "(2, 1, '2024-09-05 11:00:00', 'Back Pain', 'Tylenol', TRUE, '2024-09-11')," +
                "(2, 3, '2024-09-15 14:00:00', 'Cough', 'Cough Syrup', FALSE, NULL)," +
                "(3, 2, '2024-09-07 08:30:00', 'Allergy', 'Antihistamines', FALSE, NULL)," +
                "(3, 4, '2024-09-20 13:00:00', 'Stomach Ache', 'Antacids', TRUE, '2024-09-21')," +
                "(4, 3, '2024-09-12 15:00:00', 'Flu', 'Cough Syrup', TRUE, '2024-09-15')," +
                "(4, 5, '2024-09-22 09:30:00', 'Headache', 'Pain Relievers', FALSE, NULL)," +
                "(5, 4, '2024-09-03 10:00:00', 'Skin Rash', 'Topical Cream', FALSE, NULL)," +
                "(5, 6, '2024-09-18 11:30:00', 'Fever', 'Antipyretics', TRUE, '2024-09-21');");

            migrationBuilder.Sql(
                "INSERT INTO \"Administrators\" (\"AdministratorId\", \"Role\", \"Login\", \"Password\") " +
                "VALUES " +
                "(5, 1, 'admin1', 'adminPass1')," +
                "(1, 1, 'manager1', 'managerPass1')," +
                "(3, 1, 'hr1', 'hrPass1')," +
                "(2, 1, 'sup1', 'supPass1')," +
                "(4, 1, 'it1', 'itPass1');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "DoctorDistricts");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Polyclinics");

            migrationBuilder.DropTable(
                name: "Humans");
        }
    }
}
