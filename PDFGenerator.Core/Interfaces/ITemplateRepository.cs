using PDFGenerator.Core.Entities;

namespace PDFGenerator.Core.Interfaces
{
  public interface ITemplateRepository : IRepository<Template>
  {
    string GenerateLetterAndSavePdf(RequestLetterData requestLetter);
  }
}
