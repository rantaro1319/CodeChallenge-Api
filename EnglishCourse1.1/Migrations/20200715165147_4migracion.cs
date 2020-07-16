using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishCourse1._1.Migrations
{
    public partial class _4migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "curso",
                newName: "nombre");

            migrationBuilder.AddColumn<int>(
                name: "idcurso",
                table: "secciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idprofesores",
                table: "secciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idsecciones",
                table: "estudiantes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idcurso",
                table: "secciones");

            migrationBuilder.DropColumn(
                name: "idprofesores",
                table: "secciones");

            migrationBuilder.DropColumn(
                name: "idsecciones",
                table: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "curso",
                newName: "Nombre");
        }
    }
}
