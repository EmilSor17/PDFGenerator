using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDFGenerator.Core.Entities;

namespace PDFGenerator.Infraestructure.Data.Configurations
{
  public class TemplateConfiguration : IEntityTypeConfiguration<Template>
  {
    public void Configure(EntityTypeBuilder<Template> builder)
    {
      builder.ToTable("Templates");
      builder.HasKey(t => t.Id);
    }
  }
}
