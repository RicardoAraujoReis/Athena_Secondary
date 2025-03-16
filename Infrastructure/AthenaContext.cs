using Athena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Athena.Data;

public class AthenaContext : DbContext
{
    public AthenaContext(DbContextOptions<AthenaContext> options) : base(options)
    {
    }

    public AthenaContext()
    {
    }

    private string connectionString = "server=METAORA0727\\SERVER_REIS;database=Athena;user=sa;password=MEUnome1994*;TrustServerCertificate=True";

    //Aplicando as configurações de acesso ao banco de dados
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    //Aplicando as configurações utilizando as definições do EntityTypeConfiguration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);        
    }

    public DbSet<AtendimentoPlantao> Atendimentos { get; set; }

    public DbSet<LinhaNegocio> LinhaDeNegocio { get; set; }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<PreAtendimentoPlantao> PreAtentimentos { get; set; }    

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<UsuLhn> UsuLhns { get; set; }

    public DbSet<Departamento> Departamentos { get; set; }

    public DbSet<Funcao> Funcoes { get; set; }

    public DbSet<DepFunc> DepFuncs { get; set; }

    public DbSet<DadosListas> DadosListas { get; set; }

    public DbSet<TipoDadosListas> TipoDadosListas { get; set; }    
}