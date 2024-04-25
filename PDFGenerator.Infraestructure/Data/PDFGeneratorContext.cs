using Microsoft.EntityFrameworkCore;
using PDFGenerator.Core.Entities;
using PDFGenerator.Models;
using System.Reflection;

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
    public virtual DbSet<Security> Securities { get; set; }
    public virtual DbSet<Board> Boards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
