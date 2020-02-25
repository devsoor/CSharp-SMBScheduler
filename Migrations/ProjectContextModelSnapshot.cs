﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using massage.Models;

namespace massage.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("massage.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("InsuranceId");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Zip");

                    b.HasKey("CustomerId");

                    b.HasIndex("InsuranceId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("massage.Models.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("InsuranceId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("massage.Models.PAvailTime", b =>
                {
                    b.Property<int>("PAvailTimeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PractitionerId");

                    b.Property<string>("PractitionerId1");

                    b.Property<int>("TimeslotId");

                    b.HasKey("PAvailTimeId");

                    b.HasIndex("PractitionerId1");

                    b.HasIndex("TimeslotId");

                    b.ToTable("PAvailTimes");
                });

            modelBuilder.Entity("massage.Models.PInsurance", b =>
                {
                    b.Property<int>("PInsuranceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InsuranceId");

                    b.Property<int>("PractitionerId");

                    b.Property<string>("PractitionerId1");

                    b.HasKey("PInsuranceId");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("PractitionerId1");

                    b.ToTable("PInsurances");
                });

            modelBuilder.Entity("massage.Models.PSchedule", b =>
                {
                    b.Property<int>("PScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DayOfWeek");

                    b.Property<int>("PractitionerId");

                    b.Property<string>("PractitionerId1");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<bool>("t10");

                    b.Property<bool>("t11");

                    b.Property<bool>("t12");

                    b.Property<bool>("t13");

                    b.Property<bool>("t14");

                    b.Property<bool>("t15");

                    b.Property<bool>("t16");

                    b.Property<bool>("t17");

                    b.Property<bool>("t18");

                    b.Property<bool>("t6");

                    b.Property<bool>("t7");

                    b.Property<bool>("t8");

                    b.Property<bool>("t9");

                    b.HasKey("PScheduleId");

                    b.HasIndex("PractitionerId1");

                    b.ToTable("PSchedules");
                });

            modelBuilder.Entity("massage.Models.PService", b =>
                {
                    b.Property<int>("PServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PractitionerId");

                    b.Property<string>("PractitionerId1");

                    b.Property<int>("ServiceId");

                    b.HasKey("PServiceId");

                    b.HasIndex("PractitionerId1");

                    b.HasIndex("ServiceId");

                    b.ToTable("PServices");
                });

            modelBuilder.Entity("massage.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatorId");

                    b.Property<string>("CreatorId1");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Notes");

                    b.Property<int>("PractitionerId");

                    b.Property<string>("PractitionerId1");

                    b.Property<int>("RoomId");

                    b.Property<int>("ServiceId");

                    b.Property<int>("TimeslotId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ReservationId");

                    b.HasIndex("CreatorId1");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PractitionerId1");

                    b.HasIndex("RoomId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TimeslotId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("massage.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("massage.Models.RoomService", b =>
                {
                    b.Property<int>("RoomServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("RoomId");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("RoomServiceId");

                    b.HasIndex("RoomId");

                    b.HasIndex("ServiceId");

                    b.ToTable("RoomServices");
                });

            modelBuilder.Entity("massage.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("massage.Models.Timeslot", b =>
                {
                    b.Property<int>("TimeslotId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Hour");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("TimeslotId");

                    b.ToTable("Timeslots");
                });

            modelBuilder.Entity("massage.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("massage.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("massage.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("massage.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("massage.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("massage.Models.Customer", b =>
                {
                    b.HasOne("massage.Models.Insurance", "Insurance")
                        .WithMany("Customers")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("massage.Models.PAvailTime", b =>
                {
                    b.HasOne("massage.Models.User", "Practitioner")
                        .WithMany("AvailTimes")
                        .HasForeignKey("PractitionerId1");

                    b.HasOne("massage.Models.Timeslot", "TimeSlot")
                        .WithMany("PsAvail")
                        .HasForeignKey("TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("massage.Models.PInsurance", b =>
                {
                    b.HasOne("massage.Models.Insurance", "Insurance")
                        .WithMany("Practitioners")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("massage.Models.User", "Practitioner")
                        .WithMany("InsurancesAccepted")
                        .HasForeignKey("PractitionerId1");
                });

            modelBuilder.Entity("massage.Models.PSchedule", b =>
                {
                    b.HasOne("massage.Models.User", "Practitioner")
                        .WithMany("PSchedules")
                        .HasForeignKey("PractitionerId1");
                });

            modelBuilder.Entity("massage.Models.PService", b =>
                {
                    b.HasOne("massage.Models.User", "Practitioner")
                        .WithMany("Services")
                        .HasForeignKey("PractitionerId1");

                    b.HasOne("massage.Models.Service", "Service")
                        .WithMany("Practitioners")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("massage.Models.Reservation", b =>
                {
                    b.HasOne("massage.Models.User", "Creator")
                        .WithMany("CreatedReservations")
                        .HasForeignKey("CreatorId1");

                    b.HasOne("massage.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("massage.Models.User", "Practitioner")
                        .WithMany("Appointments")
                        .HasForeignKey("PractitionerId1");

                    b.HasOne("massage.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("massage.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("massage.Models.Timeslot", "Timeslot")
                        .WithMany("Reservations")
                        .HasForeignKey("TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("massage.Models.RoomService", b =>
                {
                    b.HasOne("massage.Models.Room", "Room")
                        .WithMany("Services")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("massage.Models.Service", "Service")
                        .WithMany("Rooms")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
