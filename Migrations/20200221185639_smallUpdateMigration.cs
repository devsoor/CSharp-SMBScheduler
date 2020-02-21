using Microsoft.EntityFrameworkCore.Migrations;

namespace massage.Migrations
{
    public partial class smallUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Insurance_InsuranceId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_PAvailTime_Users_PractitionerId",
                table: "PAvailTime");

            migrationBuilder.DropForeignKey(
                name: "FK_PAvailTime_Timeslot_TimeslotId",
                table: "PAvailTime");

            migrationBuilder.DropForeignKey(
                name: "FK_PInsurance_Insurance_InsuranceId",
                table: "PInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_PInsurance_Users_PractitionerId",
                table: "PInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_PSchedule_Users_PractitionerId",
                table: "PSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PService_Users_PractitionerId",
                table: "PService");

            migrationBuilder.DropForeignKey(
                name: "FK_PService_Service_ServiceId",
                table: "PService");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_CreatorId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customer_CustomerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_PractitionerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Service_ServiceId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Timeslot_TimeslotId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomService_Room_RoomId",
                table: "RoomService");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomService_Service_ServiceId",
                table: "RoomService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeslot",
                table: "Timeslot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomService",
                table: "RoomService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PService",
                table: "PService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PSchedule",
                table: "PSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PInsurance",
                table: "PInsurance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAvailTime",
                table: "PAvailTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Timeslot",
                newName: "Timeslots");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "RoomService",
                newName: "RoomServices");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "PService",
                newName: "PServices");

            migrationBuilder.RenameTable(
                name: "PSchedule",
                newName: "PSchedules");

            migrationBuilder.RenameTable(
                name: "PInsurance",
                newName: "PInsurances");

            migrationBuilder.RenameTable(
                name: "PAvailTime",
                newName: "PAvailTimes");

            migrationBuilder.RenameTable(
                name: "Insurance",
                newName: "Insurances");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_RoomService_ServiceId",
                table: "RoomServices",
                newName: "IX_RoomServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomService_RoomId",
                table: "RoomServices",
                newName: "IX_RoomServices_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_TimeslotId",
                table: "Reservations",
                newName: "IX_Reservations_TimeslotId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ServiceId",
                table: "Reservations",
                newName: "IX_Reservations_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservations",
                newName: "IX_Reservations_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PractitionerId",
                table: "Reservations",
                newName: "IX_Reservations_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CreatorId",
                table: "Reservations",
                newName: "IX_Reservations_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_PService_ServiceId",
                table: "PServices",
                newName: "IX_PServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PService_PractitionerId",
                table: "PServices",
                newName: "IX_PServices_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_PSchedule_PractitionerId",
                table: "PSchedules",
                newName: "IX_PSchedules_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_PInsurance_PractitionerId",
                table: "PInsurances",
                newName: "IX_PInsurances_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_PInsurance_InsuranceId",
                table: "PInsurances",
                newName: "IX_PInsurances_InsuranceId");

            migrationBuilder.RenameIndex(
                name: "IX_PAvailTime_TimeslotId",
                table: "PAvailTimes",
                newName: "IX_PAvailTimes_TimeslotId");

            migrationBuilder.RenameIndex(
                name: "IX_PAvailTime_PractitionerId",
                table: "PAvailTimes",
                newName: "IX_PAvailTimes_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_InsuranceId",
                table: "Customers",
                newName: "IX_Customers_InsuranceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Insurances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeslots",
                table: "Timeslots",
                column: "TimeslotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomServices",
                table: "RoomServices",
                column: "RoomServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PServices",
                table: "PServices",
                column: "PServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PSchedules",
                table: "PSchedules",
                column: "PScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PInsurances",
                table: "PInsurances",
                column: "PInsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAvailTimes",
                table: "PAvailTimes",
                column: "PAvailTimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurances",
                table: "Insurances",
                column: "InsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Insurances_InsuranceId",
                table: "Customers",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAvailTimes_Users_PractitionerId",
                table: "PAvailTimes",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAvailTimes_Timeslots_TimeslotId",
                table: "PAvailTimes",
                column: "TimeslotId",
                principalTable: "Timeslots",
                principalColumn: "TimeslotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PInsurances_Insurances_InsuranceId",
                table: "PInsurances",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PInsurances_Users_PractitionerId",
                table: "PInsurances",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSchedules_Users_PractitionerId",
                table: "PSchedules",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PServices_Users_PractitionerId",
                table: "PServices",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PServices_Services_ServiceId",
                table: "PServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_CreatorId",
                table: "Reservations",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_PractitionerId",
                table: "Reservations",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Timeslots_TimeslotId",
                table: "Reservations",
                column: "TimeslotId",
                principalTable: "Timeslots",
                principalColumn: "TimeslotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServices_Rooms_RoomId",
                table: "RoomServices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServices_Services_ServiceId",
                table: "RoomServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Insurances_InsuranceId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_PAvailTimes_Users_PractitionerId",
                table: "PAvailTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_PAvailTimes_Timeslots_TimeslotId",
                table: "PAvailTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_PInsurances_Insurances_InsuranceId",
                table: "PInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_PInsurances_Users_PractitionerId",
                table: "PInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_PSchedules_Users_PractitionerId",
                table: "PSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_PServices_Users_PractitionerId",
                table: "PServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PServices_Services_ServiceId",
                table: "PServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_CreatorId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_PractitionerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Timeslots_TimeslotId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServices_Rooms_RoomId",
                table: "RoomServices");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServices_Services_ServiceId",
                table: "RoomServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeslots",
                table: "Timeslots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomServices",
                table: "RoomServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PServices",
                table: "PServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PSchedules",
                table: "PSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PInsurances",
                table: "PInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAvailTimes",
                table: "PAvailTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurances",
                table: "Insurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Timeslots",
                newName: "Timeslot");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "RoomServices",
                newName: "RoomService");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "PServices",
                newName: "PService");

            migrationBuilder.RenameTable(
                name: "PSchedules",
                newName: "PSchedule");

            migrationBuilder.RenameTable(
                name: "PInsurances",
                newName: "PInsurance");

            migrationBuilder.RenameTable(
                name: "PAvailTimes",
                newName: "PAvailTime");

            migrationBuilder.RenameTable(
                name: "Insurances",
                newName: "Insurance");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServices_ServiceId",
                table: "RoomService",
                newName: "IX_RoomService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServices_RoomId",
                table: "RoomService",
                newName: "IX_RoomService_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TimeslotId",
                table: "Reservation",
                newName: "IX_Reservation_TimeslotId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservation",
                newName: "IX_Reservation_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservation",
                newName: "IX_Reservation_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PractitionerId",
                table: "Reservation",
                newName: "IX_Reservation_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservation",
                newName: "IX_Reservation_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CreatorId",
                table: "Reservation",
                newName: "IX_Reservation_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_PServices_ServiceId",
                table: "PService",
                newName: "IX_PService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PServices_PractitionerId",
                table: "PService",
                newName: "IX_PService_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_PSchedules_PractitionerId",
                table: "PSchedule",
                newName: "IX_PSchedule_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_PInsurances_PractitionerId",
                table: "PInsurance",
                newName: "IX_PInsurance_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_PInsurances_InsuranceId",
                table: "PInsurance",
                newName: "IX_PInsurance_InsuranceId");

            migrationBuilder.RenameIndex(
                name: "IX_PAvailTimes_TimeslotId",
                table: "PAvailTime",
                newName: "IX_PAvailTime_TimeslotId");

            migrationBuilder.RenameIndex(
                name: "IX_PAvailTimes_PractitionerId",
                table: "PAvailTime",
                newName: "IX_PAvailTime_PractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_InsuranceId",
                table: "Customer",
                newName: "IX_Customer_InsuranceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Insurance",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeslot",
                table: "Timeslot",
                column: "TimeslotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomService",
                table: "RoomService",
                column: "RoomServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PService",
                table: "PService",
                column: "PServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PSchedule",
                table: "PSchedule",
                column: "PScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PInsurance",
                table: "PInsurance",
                column: "PInsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAvailTime",
                table: "PAvailTime",
                column: "PAvailTimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance",
                column: "InsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Insurance_InsuranceId",
                table: "Customer",
                column: "InsuranceId",
                principalTable: "Insurance",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAvailTime_Users_PractitionerId",
                table: "PAvailTime",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAvailTime_Timeslot_TimeslotId",
                table: "PAvailTime",
                column: "TimeslotId",
                principalTable: "Timeslot",
                principalColumn: "TimeslotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PInsurance_Insurance_InsuranceId",
                table: "PInsurance",
                column: "InsuranceId",
                principalTable: "Insurance",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PInsurance_Users_PractitionerId",
                table: "PInsurance",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSchedule_Users_PractitionerId",
                table: "PSchedule",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PService_Users_PractitionerId",
                table: "PService",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PService_Service_ServiceId",
                table: "PService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_CreatorId",
                table: "Reservation",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customer_CustomerId",
                table: "Reservation",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_PractitionerId",
                table: "Reservation",
                column: "PractitionerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_RoomId",
                table: "Reservation",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Service_ServiceId",
                table: "Reservation",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Timeslot_TimeslotId",
                table: "Reservation",
                column: "TimeslotId",
                principalTable: "Timeslot",
                principalColumn: "TimeslotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomService_Room_RoomId",
                table: "RoomService",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomService_Service_ServiceId",
                table: "RoomService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
