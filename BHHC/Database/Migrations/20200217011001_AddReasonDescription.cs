using Microsoft.EntityFrameworkCore.Migrations;

namespace BHHC.Database.Migrations
{
    public partial class AddReasonDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FantasticReasons",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "", 1 });

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "", 2 });

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FantasticReasons");

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayOrder",
                value: 3);
        }
    }
}
