using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Enums;

namespace PDFGenerator.Models
{
  public class Security : Entity
  {
    public string User { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
  }
}
