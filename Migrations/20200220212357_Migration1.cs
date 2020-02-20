using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace massage.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Timeslot",
                columns: table => new
                {
                    TimeslotId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hour = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslot", x => x.TimeslotId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    Username = table.Column<string>(maxLength: 29, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    InsuranceId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    RoomServiceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.RoomServiceId);
                    table.ForeignKey(
                        name: "FK_RoomService_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAvailTime",
                columns: table => new
                {
                    PAvailTimeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PractitionerId = table.Column<int>(nullable: false),
                    TimeslotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAvailTime", x => x.PAvailTimeId);
                    table.ForeignKey(
                        name: "FK_PAvailTime_Users_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAvailTime_Timeslot_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "Timeslot",
                        principalColumn: "TimeslotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PInsurance",
                columns: table => new
                {
                    PInsuranceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsuranceId = table.Column<int>(nullable: false),
                    PractitionerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PInsurance", x => x.PInsuranceId);
                    table.ForeignKey(
                        name: "FK_PInsurance_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PInsurance_Users_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSchedule",
                columns: table => new
                {
                    PScheduleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PractitionerId = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<string>(nullable: true),
                    t6 = table.Column<bool>(nullable: false),
                    t7 = table.Column<bool>(nullable: false),
                    t8 = table.Column<bool>(nullable: false),
                    t9 = table.Column<bool>(nullable: false),
                    t10 = table.Column<bool>(nullable: false),
                    t11 = table.Column<bool>(nullable: false),
                    t12 = table.Column<bool>(nullable: false),
                    t13 = table.Column<bool>(nullable: false),
                    t14 = table.Column<bool>(nullable: false),
                    t15 = table.Column<bool>(nullable: false),
                    t16 = table.Column<bool>(nullable: false),
                    t17 = table.Column<bool>(nullable: false),
                    t18 = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSchedule", x => x.PScheduleId);
                    table.ForeignKey(
                        name: "FK_PSchedule_Users_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PService",
                columns: table => new
                {
                    PServiceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PractitionerId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PService", x => x.PServiceId);
                    table.ForeignKey(
                        name: "FK_PService_Users_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    PractitionerId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Users_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_InsuranceId",
                table: "Customer",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PAvailTime_PractitionerId",
                table: "PAvailTime",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PAvailTime_TimeslotId",
                table: "PAvailTime",
                column: "TimeslotId");

            migrationBuilder.CreateIndex(
                name: "IX_PInsurance_InsuranceId",
                table: "PInsurance",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PInsurance_PractitionerId",
                table: "PInsurance",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PSchedule_PractitionerId",
                table: "PSchedule",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PService_PractitionerId",
                table: "PService",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PService_ServiceId",
                table: "PService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CreatorId",
                table: "Reservation",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PractitionerId",
                table: "Reservation",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ServiceId",
                table: "Reservation",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_RoomId",
                table: "RoomService",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_ServiceId",
                table: "RoomService",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAvailTime");

            migrationBuilder.DropTable(
                name: "PInsurance");

            migrationBuilder.DropTable(
                name: "PSchedule");

            migrationBuilder.DropTable(
                name: "PService");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "RoomService");

            migrationBuilder.DropTable(
                name: "Timeslot");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}
