namespace PDFGenerator.Core.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    ITemplateRepository Templates { get; }
    ISecurityRepository Securities { get; }
    IBoardRepository Boards { get; }
    int Complete();
  }
}
