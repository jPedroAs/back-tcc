using JtTcc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using static JtTcc.Models.Registro;

// Mapeamento para a tabela tb_permissao
public class PermissaoMap : IEntityTypeConfiguration<Pagina>
{
    public void Configure(EntityTypeBuilder<Pagina> builder)
    {
        builder.ToTable("tb_pagina");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasColumnName("sg_Nome");

    }
}

// Mapeamento para a tabela tb_permissao_funcao
public class PermissaoFuncaoMap : IEntityTypeConfiguration<PermissaoPaginas>
{
    public void Configure(EntityTypeBuilder<PermissaoPaginas> builder)
    {
        builder.ToTable("tb_permissao_pagina");
        builder.HasKey(pf => pf.Id);
        builder.Property(pf => pf.UsuarioId).HasColumnName("cd_Usuario").IsRequired();
        builder.Property(pf => pf.PaginaId).HasColumnName("cd_Pagina_Permissao").IsRequired();

        // builder.HasOne(p => p.Usuarios)
        // .WithMany(p => p.Paginas)
        // .HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Restrict);

        // builder.HasOne(p => p.Paginas)
        // .WithMany(p => p.Paginas).
        // HasForeignKey(p => p.PaginaId).OnDelete(DeleteBehavior.Restrict);
    }
}

// Mapeamento para a tabela tb_funcao
// public class FuncaoMap : IEntityTypeConfiguration<Funcao>
// {
//     public void Configure(EntityTypeBuilder<Funcao> builder)
//     {
//         builder.ToTable("tb_funcao");
//         builder.HasKey(f => f.Id);
//         builder.Property(f => f.Sigla).HasColumnName("sg_funcao");
//         builder.Property(f => f.Nome).HasColumnName("nm_funcao");
//         builder.Property(f => f.Descricao).HasColumnName("ds_funcao");
//         builder.Property(f => f.Administrador).HasColumnName("ic_administrador");
//     }
// }

// public class NovaContaMap : IEntityTypeConfiguration<Conta>
// {
//     public void Configure(EntityTypeBuilder<Conta> builder)
//     {
//         builder.ToTable("tb_funcao");
//         builder.Property(f => f.CPF).HasColumnName("CPF");
//         builder.Property(f => f.Nome).HasColumnName("Nome");
//         builder.Property(f => f.Celular).HasColumnName("Celular");
//         builder.Property(f => f.funcao).HasColumnName("funcao");
//     }
// }


// Mapeamento para a tabela tb_usuario_funcao
public class UsuarioFuncaoMap : IEntityTypeConfiguration<UsuarioFuncao>
{
    public void Configure(EntityTypeBuilder<UsuarioFuncao> builder)
    {
        builder.ToTable("tb_usuario_funcao");
        builder.HasKey(uf => new { uf.UsuarioId, uf.FuncaoId });
        builder.Property(uf => uf.UsuarioId).HasColumnName("cd_usuario");
        builder.Property(uf => uf.FuncaoId).HasColumnName("cd_funcao");
        builder.Property(uf => uf.Ativo).HasColumnName("ic_ativo");
        builder.Property(uf => uf.DataAssociacao).HasColumnName("dt_associacao");
    }
}

// Mapeamento para a tabela tb_portao
public class RegistroMap : IEntityTypeConfiguration<Registro>
{
    public void Configure(EntityTypeBuilder<Registro> builder)
    {
        builder.ToTable("tb_registro");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Tag).HasColumnName("cd_tag");
        builder.Property(p => p.Nome).HasColumnName("nm_nome");
        builder.Property(p => p.Descricao).HasColumnName("ds_observacao");
        builder.Property(p => p.Ativo).HasColumnName("ic_ativo");
        builder.Property(p => p.CPF).HasColumnName("cd_cpf");
        builder.Property(p => p.Celular).HasColumnName("cd_celular");
        builder.Property(p => p.UsuarioId).HasColumnName("pk_usuarioId");
        builder.Property(p => p.PortaoId).HasColumnName("pk_PortaId");
        builder.Property(p => p.Visitante).HasColumnName("ic_visitante");
        builder.Property(p => p.Pedestre).HasColumnName("ic_pedestre");
        builder.Property(p => p.Create).HasColumnName("is_create");
        builder.Property(p => p.Base64).HasColumnName("base64");

        // builder.HasOne(p => p.Usuarios)
        // .WithMany(p => p.Registros)
        // .HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Restrict);

    
    }
}

//Mapeamento para a tabela tb_registro
public class TipoEntradaMap : IEntityTypeConfiguration<TipoEntrada>
{
    public void Configure(EntityTypeBuilder<TipoEntrada> builder)
    {
        builder.ToTable("tb_tipoEntrada");
        builder.HasKey(p => p.Id);
        builder.Property(r => r.Tipo).HasColumnName("cd_tipo_entrada");
        builder.Property(r => r.RegistroId).HasColumnName("pk_registroId");
        builder.Property(r => r.Create).HasColumnName("cd_create");

    }
}

// Mapeamento para a tabela tb_pessoa
// public class PessoaMap : IEntityTypeConfiguration<Pessoa>
// {
//     public void Configure(EntityTypeBuilder<Pessoa> builder)
//     {
//         builder.ToTable("tb_pessoa");
//         builder.HasKey(p => p.Id);
//         builder.Property(p => p.Nome).HasColumnName("nm_pessoa");
//         builder.Property(p => p.CPF).HasColumnName("cd_cpf");
//         builder.Property(p => p.Email).HasColumnName("cd_email");
//         builder.Property(p => p.DataNascimento).HasColumnName("dt_nascimento");
//     }
// }

// Mapeamento para a tabela tb_usuario
public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("tb_usuario");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Login).HasColumnName("cd_login");
        builder.Property(u => u.Senha).HasColumnName("cd_senha");
        builder.Property(u => u.CPF).HasColumnName("cd_cpf");
        builder.Property(u => u.Nome).HasColumnName("cd_nome");
        builder.Property(u => u.Celular).HasColumnName("cd_celular");
        builder.Property(u => u.Active).HasColumnName("active").HasDefaultValue(false);
        builder.Property(u => u.RegistroId).HasColumnName("pk_registroId");
        builder.Property(u => u.Status).HasColumnName("cd_status");
        builder.Property(u => u.Create).HasColumnName("create");
    }
}

// Mapeamento para a tabela tb_tipo_pessoa
// public class TipoPessoaMap : IEntityTypeConfiguration<TipoPessoa>
// {
//     public void Configure(EntityTypeBuilder<TipoPessoa> builder)
//     {
//         builder.ToTable("tb_tipo_pessoa");
//         builder.HasKey(tp => tp.Id);
//         builder.Property(tp => tp.Sigla).HasColumnName("sg_tipo_pessoa");
//         builder.Property(tp => tp.Descricao).HasColumnName("ds_tipo_pessoa");
//     }
// }

// // Mapeamento para a tabela tb_funcionario
// public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
// {
//     public void Configure(EntityTypeBuilder<Funcionario> builder)
//     {
//         builder.ToTable("tb_funcionario");
//         builder.HasKey(f => f.Id);
//         builder.Property(f => f.PessoaTipoId).HasColumnName("cd_pessoa_tipo");
//         builder.Property(f => f.CargoNome).HasColumnName("nm_cargo_funcionario");
//         builder.Property(f => f.CargoDescricao).HasColumnName("ds_cargo_funcionario");
//     }
// }

// // Mapeamento para a tabela tb_pessoa_tipo
// public class PessoaTipoMap : IEntityTypeConfiguration<PessoaTipo>
// {
//     public void Configure(EntityTypeBuilder<PessoaTipo> builder)
//     {
//         builder.ToTable("tb_pessoa_tipo");
//         builder.HasKey(pt => new { pt.PessoaId, pt.TipoPessoaId });
//         builder.Property(pt => pt.PessoaId).HasColumnName("cd_pessoa");
//         builder.Property(pt => pt.TipoPessoaId).HasColumnName("cd_pessoa_tipo");
//         builder.Property(pt => pt.Valido).HasColumnName("ic_valido");
//     }
// }

// Mapeamento para a tabela tb_portao_localizacao
public class PortaoLocalizacaoMap : IEntityTypeConfiguration<PortaoLocalizacao>
{
    public void Configure(EntityTypeBuilder<PortaoLocalizacao> builder)
    {
        builder.ToTable("tb_portao_localizacao");
        builder.HasKey(pl => pl.Id);
        builder.Property(pl => pl.Nome).HasColumnName("nm_portao_localizacao");
        // builder.HasOne(p => p.Registros).WithOne(p => p.PortaoLocalizacoes).HasForeignKey<Registro>(p => p.PortaoId).OnDelete(DeleteBehavior.Restrict);
    }
}

// Mapeamento para a tabela tb_veiculo
public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("tb_veiculo");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.TipoVeiculo).HasColumnName("cd_tipo_veiculo");
        builder.Property(v => v.Placa).HasColumnName("cd_placa");
        builder.Property(v => v.RegistroId).HasColumnName("pk_registroId");

    }
}


