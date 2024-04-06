using PDFGenerator.Core.Entities;

namespace PDFGenerator.Core.Interfaces
{
  public interface ITemplateRepository : IRepository<Template>
  {
    bool GenerateLetterAndSavePdf(RequestLetterData requestLetter);
  }
}
