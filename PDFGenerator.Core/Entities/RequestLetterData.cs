namespace PDFGenerator.Core.Entities
{
  public class RequestLetterData
  {
    public string Recipient { get; set; }
    public string DesiredPosition { get; set; }
    public List<string> Skills { get; set; }
    public string YourName { get; set; }
    public int IdTemplate { get; set; }
    public string OutputPath { get; set; }
    public string RelevantAreas { get; set; }
  }
}
