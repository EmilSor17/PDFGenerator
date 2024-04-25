using Microsoft.EntityFrameworkCore;
using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Data;
using PDFGenerator.Models;

namespace PDFGenerator.Infraestructure.Repositories
{
  public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
  {
    public SecurityRepository(PDFGeneratorContext context) : base(context) { }

    public async Task<Security> GetLoginByCredentials(UserLogin user)
    {
      return await _context.Securities.FirstOrDefaultAsync(x => x.User == user.User);
    }
  }
}