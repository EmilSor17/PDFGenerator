using PDFGenerator.Core.Entities;
using PDFGenerator.Models;

namespace PDFGenerator.Core.Interfaces
{
  public interface ISecurityService
  {
    Task<Security> GetLoginByCredentials(UserLogin user);
    Task Register(Security user);
  }
}