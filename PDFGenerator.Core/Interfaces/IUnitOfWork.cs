namespace PDFGenerator.Core.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    ITemplateRepository Templates { get; }
    int Complete();
  }
}
