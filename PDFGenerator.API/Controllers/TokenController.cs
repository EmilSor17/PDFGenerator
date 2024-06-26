﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Interfaces;
using PDFGenerator.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PDFGenerator.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokenController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly ISecurityService _securityService;
    private readonly IPasswordService _passwordService;
    public TokenController(IConfiguration configuration, 
      ISecurityService security,
      IPasswordService password)
    {
      _configuration = configuration;
      _securityService = security;
      _passwordService = password;
    }
    [HttpPost]
    public async Task<IActionResult> Authentication(UserLogin login)
    {
      var validation = await IsValidUser(login);
      if (validation.Item1)
      {
        var token = GenerateToken(validation.Item2);
        return Ok(new {token});
      }
      return NotFound();
    }
    private async Task<(bool, Security)> IsValidUser(UserLogin login)
    {
      var user = await _securityService.GetLoginByCredentials(login);
      bool isValid =_passwordService.Check(user.Password, login.Password);
      return (isValid, user);

    }
    private string GenerateToken(Security security)
    {
      //header
      var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
      var sigInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
      var header = new JwtHeader(sigInCredentials);
      //claims
      var claims = new[]
      {
        new Claim(ClaimTypes.Name, security.UserName),
        new Claim("User", security.User),
        new Claim(ClaimTypes.Role, security.Role.ToString())
      };

      //payload
      var payload = new JwtPayload
        (
        _configuration["Authentication:Issuer"],
        _configuration["Authentication:Audience"],
        claims,
        DateTime.Now,
        DateTime.UtcNow.AddMinutes(10)
        );

      //signature
      var token = new JwtSecurityToken(header, payload);
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
