using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Interfaces;
using PDFGenerator.Models;

namespace PDFGenerator.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SecurityController : ControllerBase
  {
    private readonly ISecurityService _secutiryService;
    private readonly IPasswordService _passwordService;
    public SecurityController(ISecurityService securityService, IPasswordService passwordService)
    {
      _secutiryService = securityService;
      _passwordService = passwordService;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(Security security)
    {
      security.Password = _passwordService.Hash(security.Password);
      return Ok(_secutiryService.Register(security).IsCompleted);
    }
  }
}
