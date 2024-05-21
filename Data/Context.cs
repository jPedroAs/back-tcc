using JtTcc.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Pagina> Paginas { get; set; }
    public DbSet<PermissaoPaginas> PermissaoPaginas { get; set; }
    // public DbSet<Funcao>? Funcoes { get; set; }
    public DbSet<UsuarioFuncao>? UsuariosFuncoes { get; set; }
    public DbSet<Registro> Registros { get; set; }
    public DbSet<TipoEntrada> TipoEntradas { get; set; }
    // public DbSet<Pessoa>? Pessoas { get; set; }
    // public DbSet<Conta> Contas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    // public DbSet<TipoPessoa>? TiposPessoa { get; set; }
    // public DbSet<Funcionario>? Funcionarios { get; set; }
    // public DbSet<PessoaTipo>? PessoasTipos { get; set; }
    public DbSet<PortaoLocalizacao> PortoesLocalizacao { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    // public DbSet<VeiculoPessoa>? VeiculosPessoas { get; set; }
    // public DbSet<TagPessoa>? TagsPessoa { get; set; }
    // public DbSet<Morador>? Moradores { get; set; }
    // public DbSet<Visitante>? Visitantes { get; set; }
    // public DbSet<TipoVeiculo>? TiposVeiculo { get; set; }
    // public DbSet<TagVeiculo>? TagsVeiculo { get; set; }
    // public DbSet<TipoTag>? TiposTag { get; set; }
    // public DbSet<Tag>? Tags { get; set; }
    // public DbSet<Endereco>? Enderecos { get; set; }
    // public DbSet<Bloco>? Blocos { get; set; }
    // public DbSet<Apartamento>? Apartamentos { get; set; }
    // public DbSet<MoradorApartamento>? MoradoresApartamentos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=teodozo.database.windows.net;Initial Catalog=TCC;User ID=teodozo;Password=Tcc_2024;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PermissaoMap());
        modelBuilder.ApplyConfiguration(new PermissaoFuncaoMap());
        // modelBuilder.ApplyConfiguration(new FuncaoMap());
        modelBuilder.ApplyConfiguration(new UsuarioFuncaoMap());
        modelBuilder.ApplyConfiguration(new RegistroMap());
        modelBuilder.ApplyConfiguration(new TipoEntradaMap());
        // modelBuilder.ApplyConfiguration(new NovaContaMap());
        // modelBuilder.ApplyConfiguration(new PessoaMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        // modelBuilder.ApplyConfiguration(new TipoPessoaMap());
        // modelBuilder.ApplyConfiguration(new FuncionarioMap());
        // modelBuilder.ApplyConfiguration(new PessoaTipoMap());
        modelBuilder.ApplyConfiguration(new PortaoLocalizacaoMap());
        modelBuilder.ApplyConfiguration(new VeiculoMap());
        // modelBuilder.ApplyConfiguration(new VeiculoPessoaMap());
        // modelBuilder.ApplyConfiguration(new TagPessoaMap());
        // modelBuilder.ApplyConfiguration(new MoradorMap());
        // modelBuilder.ApplyConfiguration(new VisitanteMap());
        // modelBuilder.ApplyConfiguration(new TipoVeiculoMap());
        // modelBuilder.ApplyConfiguration(new TagVeiculoMap());
        // modelBuilder.ApplyConfiguration(new TipoTagMap());
        // modelBuilder.ApplyConfiguration(new TagMap());
        // modelBuilder.ApplyConfiguration(new EnderecoMap());
        // modelBuilder.ApplyConfiguration(new BlocoMap());
        // modelBuilder.ApplyConfiguration(new ApartamentoMap());
        // modelBuilder.ApplyConfiguration(new MoradorApartamentoMap());
    }
}
