using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Data;
using PDFGenerator.Infraestructure.Repositories;

namespace PDFGenerator.Infraestructure.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly PDFGeneratorContext _pDFGeneratorContext;
    public UnitOfWork(PDFGeneratorContext pDFGeneratorContext)
    {
      _pDFGeneratorContext = pDFGeneratorContext;

      Templates = new TemplateRepository(_pDFGeneratorContext);
      Securities = new SecurityRepository(_pDFGeneratorContext);
      Boards = new BoardRepository(_pDFGeneratorContext);
    }
    public ITemplateRepository Templates { get; private set; }
    public ISecurityRepository Securities { get; private set; }
    public IBoardRepository Boards { get; private set; }

    public int Complete()
    {
      return _pDFGeneratorContext.SaveChanges();
    }

    public void Dispose()
    {
      _pDFGeneratorContext.Dispose();
    }
  }
}

