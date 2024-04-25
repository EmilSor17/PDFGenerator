using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Data;

namespace PDFGenerator.Infraestructure.Repositories
{
  public class BoardRepository : BaseRepository<Board>, IBoardRepository
  {
    public BoardRepository(PDFGeneratorContext context) : base(context)
    {
    }
  }
}
