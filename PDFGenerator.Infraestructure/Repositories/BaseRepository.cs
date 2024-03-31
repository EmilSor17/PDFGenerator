using PDFGenerator.Core.Entities;
using PDFGenerator.Core.Interfaces;
using PDFGenerator.Infraestructure.Data;

namespace PDFGenerator.Infraestructure.Repositories
{
  public class BaseRepository<T> : IRepository<T> where T : Entity
  {
    protected readonly PDFGeneratorContext _context;
    public BaseRepository(PDFGeneratorContext context)
    {
      _context = context;
    }
    public IEnumerable<T> GetAll()
    {
      return _context.Set<T>().ToList();
    }
    public T GetById(int id)
    {
      return _context.Set<T>().Find(id);
    }
    public void Add(T entity)
    {
      entity.Created = DateTime.Now;
      _context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
      entity.Updated = DateTime.Now;
      _context.Set<T>().Update(entity);
    }
    public async void Delete(int id)
    {
      T entity = _context.Set<T>().Find(id);
      _context.Set<T>().Remove(entity);
    }
  }
}
