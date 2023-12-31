using Business.Abstract;
using DataAccess.FilterQueryObjects.VehicleOnTask;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]s")]
[ApiController]
public class VehicleOnTaskController : Controller
{
    private IVehicleOnTaskService _vehicleOnTaskService;

    public VehicleOnTaskController(IVehicleOnTaskService vehicleOnTaskService)
    {
        _vehicleOnTaskService = vehicleOnTaskService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _vehicleOnTaskService.GetAll();
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Add(VehicleOnTask vehicleOnTask)
    {
        var result = _vehicleOnTaskService.Add(vehicleOnTask);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
    
    
    [Route("ForNormalTable")]
    [HttpGet]
    public IActionResult GetForNormalTable([FromQuery]VotFilterRequest filterRequest)
    {
        
        var result = _vehicleOnTaskService.GetAllForTable();
        return Ok(result);
    }
    [Route("Details")]
    [HttpGet]
    public IActionResult GetDetailed([FromQuery]VotFilterRequest filterRequest)
    {
        var result = _vehicleOnTaskService.GetAllDetails(filterRequest);
        return Ok(result);
    }
    
    [Route("ForArchiveTable")]
    [HttpGet]
    public IActionResult GetForArchiveTable([FromQuery]VotFilterRequest filterRequest)
    {
        var result = _vehicleOnTaskService.GetAllForArchiveTable(filterRequest);

        return Ok(
        new
        {
            result.Data,
            result.Message,
            result.Success,

        }
        );
    }
    
    [Route("Details/{id}")]
    [HttpGet]
    public IActionResult GetDetailedById(int id)
    {
        var result = _vehicleOnTaskService.GetAllDetailsById(id);
        return Ok(result);
    }
    
    [HttpGet("{vehicleOnTaskId}")]
    public IActionResult Get(int vehicleOnTaskId)
    {
        var result = _vehicleOnTaskService.GetById(vehicleOnTaskId);
        return Ok(result);
    }
    
    
    [Route("Finish/{taskId}")]
    [HttpPost]
    public IActionResult FinishTask(int taskId)
    {
        var result = _vehicleOnTaskService.FinishTask(taskId);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
    
    [Route("Update")]
    [HttpPost]
    public IActionResult Update(VehicleOnTask vehicleOnTask)
    {
        var result = _vehicleOnTaskService.Update(vehicleOnTask);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
    
    [Route("Delete/{taskId}")]
    [HttpPost]
    public IActionResult DeleteTask(int taskId)
    {
        var result = _vehicleOnTaskService.DeleteTask(taskId);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
    
   
    
}
