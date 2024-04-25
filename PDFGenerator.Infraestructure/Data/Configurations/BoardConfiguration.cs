using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDFGenerator.Core.Entities;

namespace PDFGenerator.Infraestructure.Data.Configurations
{
  public class BoardConfiguration : IEntityTypeConfiguration<Board>
  {
    public void Configure(EntityTypeBuilder<Board> builder)
    {
      builder.ToTable("Board");
      builder.HasKey(s => s.Id);
      builder.Property(s => s.Assignment).IsRequired().HasMaxLength(50);
      builder.Property(s => s.Text).IsRequired().HasMaxLength(100);
    }
  }
}
