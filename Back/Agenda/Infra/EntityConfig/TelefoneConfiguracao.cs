using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Infra.EntityConfig
{
    public class TelefoneConfiguracao : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfiguracao()
        {
            HasKey(t => t.TelefoneId);

            Property(t => t.TelefoneContato)
                .IsRequired()
                .HasMaxLength(13);

            HasRequired(t => t.Contato)
                .WithMany()
                .HasForeignKey(t => t.ContatoId);
        }
    }
}
