using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MD2.Migrations
{
    public partial class addDeviceTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeviceInsertDate",
                table: "SensorInput",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeviceInsertTime",
                table: "SensorInput",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceInsertDate",
                table: "SensorInput");

            migrationBuilder.DropColumn(
                name: "DeviceInsertTime",
                table: "SensorInput");
        }
    }
}
