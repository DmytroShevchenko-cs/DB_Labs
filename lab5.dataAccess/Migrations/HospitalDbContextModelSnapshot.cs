﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using lab5.dataAccess;

#nullable disable

namespace lab5.dataAccess.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("AdministratorId");

                    b.ToTable("Administrators", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardId"));

                    b.Property<DateTime>("CardCreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("CardId");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Cards", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DistrictId"));

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PolyclinicId")
                        .HasColumnType("integer");

                    b.HasKey("DistrictId");

                    b.HasIndex("PolyclinicId");

                    b.ToTable("Districts", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.DoctorDistrict", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateOfEndWork")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfStartWork")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DoctorId", "DistrictId");

                    b.HasIndex("DistrictId");

                    b.ToTable("DoctorDistricts", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Human", b =>
                {
                    b.Property<int>("HumanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HumanId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("HumanId");

                    b.ToTable("Humans", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("CardId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("PatientId");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Polyclinic", b =>
                {
                    b.Property<int>("PolyclinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PolyclinicId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("PolyclinicId");

                    b.ToTable("Polyclinics", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScheduleId"));

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.HasKey("ScheduleId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Schedules", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VisitId"));

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsSickLeaveIssued")
                        .HasColumnType("boolean");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Prescriptions")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("SickLeaveDuration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("VisitId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Visits", (string)null);
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Administrator", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.Human", "Human")
                        .WithOne("Administrator")
                        .HasForeignKey("lab5.dataAccess.Database.Entities.Administrator", "AdministratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Human");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Card", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.Patient", "Patient")
                        .WithOne("Card")
                        .HasForeignKey("lab5.dataAccess.Database.Entities.Card", "PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.District", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.Polyclinic", "Polyclinic")
                        .WithMany("Districts")
                        .HasForeignKey("PolyclinicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Polyclinic");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Doctor", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.Human", "Human")
                        .WithOne("Doctor")
                        .HasForeignKey("lab5.dataAccess.Database.Entities.Doctor", "DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Human");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.DoctorDistrict", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.District", "District")
                        .WithMany("DoctorDistricts")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lab5.dataAccess.Database.Entities.Doctor", "Doctor")
                        .WithMany("DoctorDistricts")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Patient", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.Human", "Human")
                        .WithOne("Patient")
                        .HasForeignKey("lab5.dataAccess.Database.Entities.Patient", "PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Human");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Schedule", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.District", "District")
                        .WithMany("Schedules")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lab5.dataAccess.Database.Entities.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Visit", b =>
                {
                    b.HasOne("lab5.dataAccess.Database.Entities.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lab5.dataAccess.Database.Entities.Schedule", "Schedule")
                        .WithMany("Visits")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.District", b =>
                {
                    b.Navigation("DoctorDistricts");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Doctor", b =>
                {
                    b.Navigation("DoctorDistricts");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Human", b =>
                {
                    b.Navigation("Administrator")
                        .IsRequired();

                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Patient", b =>
                {
                    b.Navigation("Card")
                        .IsRequired();

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Polyclinic", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("lab5.dataAccess.Database.Entities.Schedule", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}