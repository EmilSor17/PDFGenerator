﻿using Microsoft.Extensions.Options;
using PDFGenerator.Infraestructure.Interfaces;
using PDFGenerator.Infraestructure.Options;
using System.Security.Cryptography;

namespace PDFGenerator.Infraestructure.Services
{

  public class PasswordService : IPasswordService
  {
    private readonly PasswordOption _options;
    public PasswordService(IOptions<PasswordOption> options)
    {
      _options = options.Value;
    }
    public bool Check(string hash, string password)
    {
      var parts = hash.Split('.',3);
      if(parts.Length != 3)      
        throw new FormatException("Unextecped hash Format");
      var iterations = Convert.ToInt32(parts[0]);
      var salt = Convert.FromBase64String(parts[1]);
      var key = Convert.FromBase64String(parts[2]);
      using (var algorithm = new Rfc2898DeriveBytes(
        password,
        salt,
        iterations
        ))
      {
        var keyToCheck = algorithm.GetBytes(_options.KeySize);
        return keyToCheck.SequenceEqual(key);
      }

    }

    public string Hash(string password)
    {
      using (var algorithm = new Rfc2898DeriveBytes(
        password,
        _options.SaltSize,
        _options.Iterations
        ))
      {
        var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);
        return $"{_options.Iterations}.{salt}.{key}";
      }
      
    }
  }
}
