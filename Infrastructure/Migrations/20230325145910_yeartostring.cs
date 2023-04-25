using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class yeartostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("e86739f2-eccd-4b0c-8a0e-01b3aca11f78"));

            migrationBuilder.AlterColumn<string>(
                name: "year",
                table: "researches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("e74e2caf-6d0c-4e99-bf94-ae4334cf7d33"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("e74e2caf-6d0c-4e99-bf94-ae4334cf7d33"));

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "researches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("e86739f2-eccd-4b0c-8a0e-01b3aca11f78"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }
    }
}
