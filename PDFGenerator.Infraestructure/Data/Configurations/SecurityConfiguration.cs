using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDFGenerator.Core.Enums;
using PDFGenerator.Models;

namespace PDFGenerator.Infraestructure.Data.Configurations
{
  public class SecurityConfiguration : IEntityTypeConfiguration<Security>
  {
    public void Configure(EntityTypeBuilder<Security> builder)
    {
      builder.ToTable("Security");
      builder.HasKey(s => s.Id);
      builder.Property(s => s.User).IsRequired().HasMaxLength(50);
      builder.Property(s => s.UserName).IsRequired().HasMaxLength(100);
      builder.Property(s => s.Password).IsRequired().HasMaxLength(200);

      builder.Property(s => s.Role)
        .IsRequired()
        .HasConversion(
        x=> x.ToString(),
        x=> (RoleEnum)Enum.Parse(typeof(RoleEnum), x));
    }
  }
}
