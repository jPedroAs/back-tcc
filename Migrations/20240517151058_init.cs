using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JtTcc.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_pagina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sgNome = table.Column<string>(name: "sg_Nome", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pagina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_permissao_pagina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cdUsuario = table.Column<int>(name: "cd_Usuario", type: "int", nullable: false),
                    cdPaginaPermissao = table.Column<int>(name: "cd_Pagina_Permissao", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_permissao_pagina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_portao_localizacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmportaolocalizacao = table.Column<string>(name: "nm_portao_localizacao", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_portao_localizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_registro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cdtag = table.Column<string>(name: "cd_tag", type: "nvarchar(max)", nullable: false),
                    nmnome = table.Column<string>(name: "nm_nome", type: "nvarchar(max)", nullable: false),
                    dsobservacao = table.Column<string>(name: "ds_observacao", type: "nvarchar(max)", nullable: false),
                    cdcpf = table.Column<string>(name: "cd_cpf", type: "nvarchar(max)", nullable: false),
                    icvisitante = table.Column<bool>(name: "ic_visitante", type: "bit", nullable: false),
                    icpedestre = table.Column<bool>(name: "ic_pedestre", type: "bit", nullable: false),
                    pkPortaId = table.Column<int>(name: "pk_PortaId", type: "int", nullable: false),
                    pkusuarioId = table.Column<int>(name: "pk_usuarioId", type: "int", nullable: false),
                    icativo = table.Column<bool>(name: "ic_ativo", type: "bit", nullable: false),
                    cdcelular = table.Column<string>(name: "cd_celular", type: "nvarchar(max)", nullable: false),
                    iscreate = table.Column<DateTime>(name: "is_create", type: "datetime2", nullable: false),
                    base64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_registro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipoEntrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pkregistroId = table.Column<int>(name: "pk_registroId", type: "int", nullable: false),
                    cdtipoentrada = table.Column<int>(name: "cd_tipo_entrada", type: "int", nullable: false),
                    cdcreate = table.Column<DateTime>(name: "cd_create", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipoEntrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cdlogin = table.Column<string>(name: "cd_login", type: "nvarchar(max)", nullable: false),
                    cdsenha = table.Column<string>(name: "cd_senha", type: "nvarchar(max)", nullable: true),
                    cdcpf = table.Column<string>(name: "cd_cpf", type: "nvarchar(max)", nullable: false),
                    cdnome = table.Column<string>(name: "cd_nome", type: "nvarchar(max)", nullable: false),
                    cdcelular = table.Column<string>(name: "cd_celular", type: "nvarchar(max)", nullable: false),
                    cdpermissao = table.Column<bool>(name: "cd_permissao", type: "bit", nullable: false, defaultValue: false),
                    pkregistroId = table.Column<int>(name: "pk_registroId", type: "int", nullable: false),
                    cdstatus = table.Column<int>(name: "cd_status", type: "int", nullable: false),
                    create = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario_funcao",
                columns: table => new
                {
                    cdusuario = table.Column<int>(name: "cd_usuario", type: "int", nullable: false),
                    cdfuncao = table.Column<int>(name: "cd_funcao", type: "int", nullable: false),
                    icativo = table.Column<bool>(name: "ic_ativo", type: "bit", nullable: false),
                    dtassociacao = table.Column<DateTime>(name: "dt_associacao", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_funcao", x => new { x.cdusuario, x.cdfuncao });
                });

            migrationBuilder.CreateTable(
                name: "tb_veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cdtipoveiculo = table.Column<string>(name: "cd_tipo_veiculo", type: "nvarchar(max)", nullable: false),
                    cdplaca = table.Column<string>(name: "cd_placa", type: "nvarchar(max)", nullable: false),
                    pkregistroId = table.Column<int>(name: "pk_registroId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_veiculo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pagina");

            migrationBuilder.DropTable(
                name: "tb_permissao_pagina");

            migrationBuilder.DropTable(
                name: "tb_portao_localizacao");

            migrationBuilder.DropTable(
                name: "tb_registro");

            migrationBuilder.DropTable(
                name: "tb_tipoEntrada");

            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_usuario_funcao");

            migrationBuilder.DropTable(
                name: "tb_veiculo");
        }
    }
}
