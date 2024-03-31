using Microsoft.EntityFrameworkCore;
using PDFGenerator.Core.Entities;
using PDFGenerator.Infraestructure.Data.Configurations;

namespace PDFGenerator.Infraestructure.Data
{
  public partial class PDFGeneratorContext : DbContext
  {
    public PDFGeneratorContext()
    {
    }

    public PDFGeneratorContext(DbContextOptions<PDFGeneratorContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Template> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TemplateConfiguration());
    }
  }
}
