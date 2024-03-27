using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFGenerator.Core.Entities
{
  public class Template : Entity
  {
    public string Nombre { get; set; }
    public string Contenido { get; set; }
  }
}
