using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FixCondominioBackEnd.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "lancamentos",
                schema: "public",
                columns: table => new
                {
                    lan_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lan_descricao = table.Column<string>(type: "text", nullable: false),
                    lan_valor = table.Column<decimal>(type: "numeric", nullable: false),
                    lan_tipo = table.Column<int>(type: "integer", nullable: false),
                    lan_dataalteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lancamentos", x => x.lan_id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "public",
                columns: table => new
                {
                    usu_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usu_nome = table.Column<string>(type: "text", nullable: false),
                    usu_email = table.Column<string>(type: "text", nullable: false),
                    usu_senha = table.Column<string>(type: "text", nullable: false),
                    usu_regra = table.Column<int>(type: "integer", nullable: false),
                    usu_dataalteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarios", x => x.usu_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lancamentos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "public");
        }
    }
}
