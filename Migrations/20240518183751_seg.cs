using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JtTcc.Migrations
{
    /// <inheritdoc />
    public partial class seg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cd_permissao",
                table: "tb_usuario",
                newName: "active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "active",
                table: "tb_usuario",
                newName: "cd_permissao");
        }
    }
}
