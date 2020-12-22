using Microsoft.EntityFrameworkCore.Migrations;

namespace PillsPiston.DAL.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Model", "UserId" },
                values: new object[] { "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee", "Basic", null });

            migrationBuilder.InsertData(
                table: "Cell",
                columns: new[] { "Id", "DeviceId", "Name" },
                values: new object[] { "82c74137-0ac2-4253-847f-91517f0fe65b", "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee", null });

            migrationBuilder.InsertData(
                table: "Cell",
                columns: new[] { "Id", "DeviceId", "Name" },
                values: new object[] { "95580112-8343-4bb8-8986-86ce6bcfed56", "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee", null });

            migrationBuilder.InsertData(
                table: "Cell",
                columns: new[] { "Id", "DeviceId", "Name" },
                values: new object[] { "d2c5370c-0e4a-4029-80b0-c81b8dd10ca5", "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cell",
                keyColumn: "Id",
                keyValue: "82c74137-0ac2-4253-847f-91517f0fe65b");

            migrationBuilder.DeleteData(
                table: "Cell",
                keyColumn: "Id",
                keyValue: "95580112-8343-4bb8-8986-86ce6bcfed56");

            migrationBuilder.DeleteData(
                table: "Cell",
                keyColumn: "Id",
                keyValue: "d2c5370c-0e4a-4029-80b0-c81b8dd10ca5");

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee");
        }
    }
}
