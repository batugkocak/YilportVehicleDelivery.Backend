using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IBrandDal : IEntityRepository<Brand>
{
    public List<SelectBoxDto> GetBrandsForSelectBox();
    public List<Brand> GetForTable();
    
}