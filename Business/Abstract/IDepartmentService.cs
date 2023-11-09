using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IDepartmentService
{
    IDataResult<List<Department>> GetAll();
    IDataResult<Department> GetById(int brandId);
    IResult Add(Department brand);
    IResult Delete(int id);
    IResult Update(Department brand);
    IDataResult<List<SelectBoxDto>> GetForSelectBox();

}