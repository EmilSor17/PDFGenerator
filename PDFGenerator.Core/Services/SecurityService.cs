using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Models;

namespace PDFGenerator.Core.Services
{
  public class SecurityService : ISecurityService
  {
    private readonly IUnitOfWork _unitOfWork;
    public SecurityService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    public async Task<Security> GetLoginByCredentials(UserLogin user)
    {
      return await _unitOfWork.Securities.GetLoginByCredentials(user);
    }
    public async Task Register(Security user)
    {
      _unitOfWork.Securities.Add(user);
      _unitOfWork.Complete();
    }
  }
}
