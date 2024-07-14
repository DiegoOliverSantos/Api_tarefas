using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class TarefaContext : DbContext
    {
     public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
     {
     }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TarefaModel>().ToTable("Tarefas");

            builder
                .Entity<TarefaModel>()
                .HasKey(x => x.Id);

            builder
                .Entity<TarefaModel>()
                .Property(x => x.Title)
                .HasColumnType("varchar(30)")
                .HasColumnName("Titulo");

            builder
                .Entity<TarefaModel>()
                .Property(x => x.Description)
                .HasColumnType("varchar(100)")
                .HasColumnName("Descricao");

            builder
                .Entity<TarefaModel>()
                .Property(x => x.Completed)
                .HasColumnName("Concluida");

            builder
                .Entity<TarefaModel>()
                .Property(x => x.CreatedDate)
                .HasColumnName("Data_Criacao");

            builder
                .Entity<TarefaModel>()
                .Property(x => x.UpdateDate)
                .HasColumnName("Data_Atualizacao");

        }

        public DbSet<TarefaModel> Tarefas { get; set; }
    }

}