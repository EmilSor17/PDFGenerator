using iText.Html2pdf;
using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Data;
using System.Text;

namespace PDFGenerator.Infraestructure.Repositories
{
  public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
  {
    public TemplateRepository(PDFGeneratorContext context) : base(context)
    {      
    }
    private string CreateHTML(RequestLetterData requestLetter)
    {
      string template = _context.Templates.Find(requestLetter.IdTemplate).Content;
      string fullLetter = template.Replace("[Nombre del Destinatario]", requestLetter.Recipient)
                                  .Replace("[Puesto Deseado]", requestLetter.DesiredPosition)
                                  .Replace("[Tu Nombre]", requestLetter.YourName)
                                  .Replace("[Áreas Relevantes]", requestLetter.RelevantAreas)
                                  .Replace("[Fecha Actual]", DateTime.Today.ToString("dd-MM-yyyy"));

      StringBuilder habilitiesToHTML = new StringBuilder();
      habilitiesToHTML.Append("<ul>\n");
      foreach (string skill in requestLetter.Skills)
      {
        habilitiesToHTML.Append("<li>").Append(skill).Append("</li>\n\n");
      }
      habilitiesToHTML.Append("</ul>");
      fullLetter = fullLetter.Replace("<ul><li>Habilidad</li></ul>", habilitiesToHTML.ToString());

      return fullLetter;
    }

    private void SaveHtmlAsPdf(string htmlContent, string outputPath)
    {
      using (FileStream pdfFile = new FileStream(outputPath, FileMode.Create))
      {
        ConverterProperties properties = new ConverterProperties();
        HtmlConverter.ConvertToPdf(htmlContent, pdfFile, properties);
      }
    }

    public string GenerateLetterAndSavePdf(RequestLetterData requestLetter)
    {
      string htmlContent = CreateHTML(requestLetter);
      SaveHtmlAsPdf(htmlContent, requestLetter.OutputPath);
      return "PDF creado con éxito en la ruta " + requestLetter.OutputPath;
    }
  }
}
