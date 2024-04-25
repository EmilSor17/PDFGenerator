using PDFGenerator.Core.Entities;
using PDFGenerator.Models;

namespace PDFGenerator.Core.Interfaces
{
  public interface ISecurityRepository : IRepository<Security>
  {
    Task<Security> GetLoginByCredentials(UserLogin user);
  }
}