using FixCondominioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace FixCondominioBackEnd.Data.Tabelas
{
    public class LancamentosTable
    {
        public static void TableBuildBranch(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancamentosModel>(entity =>
            {
                entity.ToTable("lancamentos");
                entity.Property(e => e.ID).HasColumnName("lan_id").ValueGeneratedOnAdd();
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Descricao).HasColumnName("lan_descricao");
                entity.Property(e => e.Valor).HasColumnName("lan_valor");
                entity.Property(e => e.Lancamento).HasColumnName("lan_tipo");
                entity.Property(e => e.DataAlteracao).HasColumnName("lan_dataalteracao").HasDefaultValueSql("now()");
            });
        }
    }
}
