namespace PDFGenerator.Core.Entities
{
  public class Entity : BaseEntity
  {
    public int Id { get; set; }
    public bool Status { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
  }
}
