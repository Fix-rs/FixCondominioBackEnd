using FixCondominioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace FixCondominioBackEnd.Data.Tabelas
{
    public class UsuarioTable
    {
        public static void TableBuildBranch(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("usuario");
                entity.Property(e => e.ID).HasColumnName("usu_id").ValueGeneratedOnAdd();
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Nome).HasColumnName("usu_nome");
                entity.Property(e => e.Email).HasColumnName("usu_email");
                entity.Property(e => e.Senha).HasColumnName("usu_senha");
                entity.Property(e => e.Regra).HasColumnName("usu_regra");
                entity.Property(e => e.DataAlteracao).HasColumnName("usu_dataalteracao").HasDefaultValueSql("now()");
            });
        }
    }
}
