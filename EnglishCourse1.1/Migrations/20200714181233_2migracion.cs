using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishCourse1._1.Migrations
{
    public partial class _2migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idcurso",
                table: "secciones");

            migrationBuilder.DropColumn(
                name: "idprofesor",
                table: "secciones");

            migrationBuilder.DropColumn(
                name: "idseccion",
                table: "estudiantes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idcurso",
                table: "secciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idprofesor",
                table: "secciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idseccion",
                table: "estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
