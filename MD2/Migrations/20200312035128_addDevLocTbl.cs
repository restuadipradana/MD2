using Microsoft.EntityFrameworkCore.Migrations;

namespace MD2.Migrations
{
    public partial class addDevLocTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceLocaton",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceMac = table.Column<string>(nullable: false),
                    Location = table.Column<string>(maxLength: 20, nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    AssetNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceLocaton", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceLocaton");
        }
    }
}
