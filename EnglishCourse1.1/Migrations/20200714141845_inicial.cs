using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishCourse1._1.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profesores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "secciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hora = table.Column<DateTime>(nullable: false),
                    Aula = table.Column<string>(nullable: true),
                    idcurso = table.Column<int>(nullable: false),
                    idprofesor = table.Column<int>(nullable: false),
                    cursoId = table.Column<int>(nullable: true),
                    profesoresId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_secciones_curso_cursoId",
                        column: x => x.cursoId,
                        principalTable: "curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_secciones_profesores_profesoresId",
                        column: x => x.profesoresId,
                        principalTable: "profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    edad = table.Column<int>(nullable: false),
                    correo = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    idseccion = table.Column<int>(nullable: false),
                    seccionesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estudiantes_secciones_seccionesId",
                        column: x => x.seccionesId,
                        principalTable: "secciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_seccionesId",
                table: "estudiantes",
                column: "seccionesId");

            migrationBuilder.CreateIndex(
                name: "IX_secciones_cursoId",
                table: "secciones",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_secciones_profesoresId",
                table: "secciones",
                column: "profesoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "secciones");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropTable(
                name: "profesores");
        }
    }
}
