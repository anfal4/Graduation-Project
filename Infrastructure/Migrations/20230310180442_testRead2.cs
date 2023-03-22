using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class testRead2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("25b0a576-f596-4d71-8ade-cc8488a54a32"));

            migrationBuilder.DropColumn(
                name: "owner",
                table: "researches");

            migrationBuilder.DropColumn(
                name: "reads",
                table: "researches");

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("60fa7e2b-215b-4e85-b29b-c6f40281f382"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("60fa7e2b-215b-4e85-b29b-c6f40281f382"));

            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "researches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "reads",
                table: "researches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("25b0a576-f596-4d71-8ade-cc8488a54a32"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }
    }
}
