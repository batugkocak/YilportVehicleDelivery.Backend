using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfVehicleOnTaskDal: EfEntityRepositoryBase<VehicleOnTask, VehicleDeliveryContext>, IVehicleOnTaskDal
{
    public List<VehicleOnTaskDetailDto> GetVehicleOnTaskDetail()
    {
        using VehicleDeliveryContext context = new VehicleDeliveryContext();
            var result = (from v in context.VehiclesOnTask
                join d in context.Departments on v.DepartmentId equals d.Id 
                join dr in context.Drivers on v.DriverId equals dr.Id
                join vehicle in context.Vehicles on v.VehicleId equals vehicle.Id 
                where v.IsDeleted != true
                select new VehicleOnTaskDetailDto{
                    VehicleOnTaskId = v.Id,
                    VehiclePlate = vehicle.Plate,
                    VehicleId = v.VehicleId,
                    DriverName = dr.Name + " " + dr.Surname,
                    DepartmentName = d.Name,
                    AuthorizedPerson = v.AuthorizedPerson,
                    Address = v.Address,
                    GivenDate = v.GivenDate,
                    ReturnDate = v.ReturnDate
                    
                }).ToList();
       

            return result;
        
    }
    
    public VehicleOnTaskDetailDto GetVehicleOnTaskDetailById(int id)
    {
        using VehicleDeliveryContext context = new VehicleDeliveryContext();
        var result = (from v in context.VehiclesOnTask
            join d in context.Departments on v.DepartmentId equals d.Id 
            join dr in context.Drivers on v.DriverId equals dr.Id
            join vehicle in context.Vehicles on v.VehicleId equals vehicle.Id 
            where v.Id == id 
            select new VehicleOnTaskDetailDto{
                VehicleOnTaskId = v.Id,
                VehiclePlate = vehicle.Plate,
                VehicleId = v.VehicleId,
                DriverName = dr.Name + " " + dr.Surname,
                DepartmentName = d.Name,
                TaskDefinition= v.TaskDefinition,

                AuthorizedPerson = v.AuthorizedPerson,
                Address = v.Address,
                GivenDate = v.GivenDate,
                ReturnDate = v.ReturnDate
                    
            }).SingleOrDefault();
        return result;
    }

    public List<VehicleOnTaskForTableDto> GetVehicleOnTaskForTable()
    {
        using VehicleDeliveryContext context = new VehicleDeliveryContext();
        var result = (from vot in context.VehiclesOnTask
            join vehicle in context.Vehicles on vot.VehicleId equals vehicle.Id
            join d in context.Departments on vot.DepartmentId equals d.Id
            join department in context.Departments on vot.DepartmentId equals department.Id 
            where vot.IsDeleted != true
            select new VehicleOnTaskForTableDto()
            {
                Id = vot.Id ,
                VehicleId= vot.VehicleId ,
                VehiclePlate= vehicle.Plate,
                DepartmentName= department.Name,
                TaskDefinition= vot.TaskDefinition,
                GivenDate=  vot.GivenDate,
                ReturnDate= vot.ReturnDate,
            }).OrderBy(vot => vot.ReturnDate).ToList();
        return result;
    }
}

// .OrderByDescending(vot => vot.Id)