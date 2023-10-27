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
    IResult Delete(Vehicle vehicle);
    IResult Update(Vehicle vehicle);
}