using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagueiBaratoApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCaminhoImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemPath",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemPath",
                table: "Lojas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemPath",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ImagemPath",
                table: "Lojas");
        }
    }
}
