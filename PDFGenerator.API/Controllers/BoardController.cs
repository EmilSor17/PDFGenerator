using Microsoft.AspNetCore.Mvc;
using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;

namespace PDFGenerator.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoardController : ControllerBase
  {

    private readonly IUnitOfWork _unitOfWork;
    public BoardController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public ActionResult Get()
    {
      return Ok(_unitOfWork.Boards.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
      return Ok(_unitOfWork.Boards.GetById(id));
    }
    [HttpPost]
    public ActionResult Create(Board Boards)
    {
      Boards.Created = DateTime.Now;
      _unitOfWork.Boards.Add(Boards);
      return Ok(_unitOfWork.Complete());
    }
    [HttpPut]
    public ActionResult Update(Board Boards)
    {
      _unitOfWork.Boards.Update(Boards);
      return Ok(_unitOfWork.Complete());
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
      _unitOfWork.Boards.Delete(id);
      return Ok(_unitOfWork.Complete());
    }
  }
}
