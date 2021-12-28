using Microsoft.EntityFrameworkCore;
using FixCondominioBackEnd.Data.Tabelas;

public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // PostgreSQL uses the public schema by default - not dbo.
        modelBuilder.HasDefaultSchema("public");
        base.OnModelCreating(modelBuilder);

        //Rename Identity tables to lowercase
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var currentTableName = modelBuilder.Entity(entity.Name).Metadata.GetDefaultTableName();
            modelBuilder.Entity(entity.Name).ToTable(currentTableName.ToLower());
        }

        UsuariosTable.TableBuildBranch(modelBuilder);
        LancamentosTable.TableBuildBranch(modelBuilder);
    }

    public DbSet<FixCondominioBackEnd.Models.UsuarioModel> Usuario { get; set; }
    public DbSet<FixCondominioBackEnd.Models.LancamentosModel> Lancamentos { get; set; }
}
