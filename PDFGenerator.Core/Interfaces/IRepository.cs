using PDFGenerator.Core.Entities;

namespace PDFGenerator.Core.Interfaces
{
  public interface IRepository<T> where T : Entity
  {
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
  }
}
