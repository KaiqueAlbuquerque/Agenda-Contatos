using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Infra.EntityConfig
{
    public class ContatoConfiguracao : EntityTypeConfiguration<Contato>
    {
        public ContatoConfiguracao()
        {
            HasKey(c => c.ContatoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
