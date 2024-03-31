using Microsoft.AspNetCore.Mvc;
using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;

namespace PDFGenerator.API.Controllers
{


  [Route("api/[controller]")]
  [ApiController]
  public class TemplateController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    public TemplateController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public ActionResult Get()
    {
      return Ok(_unitOfWork.Templates.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
      return Ok(_unitOfWork.Templates.GetById(id));
    }
    [HttpPost]
    public ActionResult Create(Template template)
    {
      template.Created = DateTime.Now;
      _unitOfWork.Templates.Add(template);
      return Ok(_unitOfWork.Complete());
    }
    [HttpPut]
    public ActionResult Update(Template template)
    {
      _unitOfWork.Templates.Update(template);
      return Ok(_unitOfWork.Complete());
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
      _unitOfWork.Templates.Delete(id);
      return Ok(_unitOfWork.Complete());
    }
    [HttpPost("CreatePDF")]
    public ActionResult CreatePDF(RequestLetterData letter)
    {      
      return Ok(_unitOfWork.Templates.GenerateLetterAndSavePdf(letter));
    }
  }
}
