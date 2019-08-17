using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Infra.EntityConfig
{
    public class EmailConfiguracao : EntityTypeConfiguration<Email>
    {
        public EmailConfiguracao()
        {
            HasKey(e => e.EmailId);

            Property(e => e.EmailContato)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(e => e.Contato)
                .WithMany()
                .HasForeignKey(e => e.ContatoId);
        }
    }
}
