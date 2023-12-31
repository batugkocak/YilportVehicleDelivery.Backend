using Core.DataAccess.EntityFramework;
using Core.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.FilterQueryObjects.VehicleOnTask;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfVehicleOnTaskDal: EfEntityRepositoryBase<VehicleOnTask, VehicleDeliveryContext>, IVehicleOnTaskDal
{
    public List<VehicleOnTaskDetailDto> GetVehicleOnTaskDetailFinished(VotFilterRequest filterRequest)
    {
        using VehicleDeliveryContext context = new VehicleDeliveryContext();
        var vehiclesOnTask = context.VehiclesOnTask.AsQueryable();
        if (filterRequest.DateType == "returnDate")
        {
            vehiclesOnTask = vehiclesOnTask.Where(v =>
                filterRequest.FirstDate <= v.ReturnDate && filterRequest.LastDate >= v.ReturnDate);
        }
        else //default 
        {
            vehiclesOnTask = vehiclesOnTask.Where(v =>
                filterRequest.FirstDate <= v.GivenDate && filterRequest.LastDate >= v.GivenDate);
        }  
        var result = (from v in vehiclesOnTask
            join d in context.Departments on v.DepartmentId equals d.Id 
            join dr in context.Drivers on v.DriverId equals dr.Id
            join vehicle in context.Vehicles on v.VehicleId equals vehicle.Id 
            where v.IsDeleted != true
            where v.IsFinished == true
            select new VehicleOnTaskDetailDto{
                VehicleOnTaskId = v.Id,
                VehiclePlate = vehicle.Plate,
                VehicleId = v.VehicleId,
                DriverName = $"{dr.Name} {dr.Surname} - {dr.Mission}",
                DepartmentName = d.Name,
                TaskDefinition = v.TaskDefinition,
                AuthorizedPerson = v.AuthorizedPerson,
                Address = v.Address,
                GivenDate = v.GivenDate,
                ReturnDate = (DateTime)v.ReturnDate
            }).OrderByDescending(vot => vot.GivenDate).ToList();
        return result;
    }
    public PagingResponse<VehicleOnTaskForTableDto> GetVehicleOnTaskForTableFinished(VotFilterRequest filterRequest)
    {
        using VehicleDeliveryContext context = new VehicleDeliveryContext();
        var vehiclesOnTask = context.VehiclesOnTask.AsQueryable();
        if (filterRequest.DateType == "returnDate")
        {
            vehiclesOnTask = vehiclesOnTask.Where(v =>
                filterRequest.FirstDate <= v.ReturnDate && filterRequest.LastDate >= v.ReturnDate);
        }
        else //default 
        {
            vehiclesOnTask = vehiclesOnTask.Where(v =>
                filterRequest.FirstDate <= v.GivenDate && filterRequest.LastDate >= v.GivenDate);
        } 
        var result = (from vot in vehiclesOnTask
            join vehicle in context.Vehicles on vot.VehicleId equals vehicle.Id
            join d in context.Departments on vot.DepartmentId equals d.Id
            join department in context.Departments on vot.DepartmentId equals department.Id
            where vot.IsDeleted != true
            where vot.IsFinished == true
            select new VehicleOnTaskForTableDto()
            {
                Id = vot.Id,
                VehicleId = vot.VehicleId,
                VehiclePlate = vehicle.Plate,
                DepartmentName = department.Name,
                TaskDefinition = vot.TaskDefinition,
                GivenDate = vot.GivenDate,
                ReturnDate = vot.ReturnDate,
            }).OrderByDescending(vot => vot.GivenDate).ToPaginate(new ()
        {
            PageSize = filterRequest.Size,
            PageIndex = filterRequest.Page
        });
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
            where v.IsDeleted != true
            select new VehicleOnTaskDetailDto{
                VehicleOnTaskId = v.Id,
                VehiclePlate = vehicle.Plate,
                VehicleId = v.VehicleId,
                DriverName = $"{dr.Name} {dr.Surname} - {dr.Mission}",
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
            where vot.IsFinished == false
            select new VehicleOnTaskForTableDto()
            {
                Id = vot.Id,
                VehicleId = vot.VehicleId,
                VehiclePlate = vehicle.Plate,
                DepartmentName = department.Name,
                TaskDefinition = vot.TaskDefinition,
                GivenDate = vot.GivenDate,
                ReturnDate = vot.ReturnDate,
            }).OrderByDescending(vot => vot.GivenDate).ToList();
        return result;
    }


    
}

// .OrderByDescending(vot => vot.Id)