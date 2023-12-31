using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;


public interface IVehicleService
{
    IDataResult<List<Vehicle>> GetAll();
    IDataResult<List<VehicleForTableDTO>> GetAllDetailsForTable();
    IDataResult<VehicleDetailDTO> GetDetailsById(int vehicleId);
    IResult CheckIfCarExistByPlate(String plate);
    IDataResult<Vehicle> GetById(int vehicleId);
    IResult Add(Vehicle vehicle);
    IResult Delete(int id);
    IResult Update(Vehicle vehicle);
    IDataResult<List<SelectBoxDto>> GetForSelectBox();
    
    IDataResult<List<Vehicle>> GetByBrandId(int id);
    IDataResult<List<Vehicle>> GetByOwnerId(int id);
    IDataResult<List<Vehicle>> GetByDepartmentId(int id);
}