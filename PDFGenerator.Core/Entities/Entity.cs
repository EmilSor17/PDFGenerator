using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFGenerator.Core.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
