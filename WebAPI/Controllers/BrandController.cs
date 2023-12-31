using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]s")]
[ApiController]
public class BrandController : Controller
{
    private IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    [Route("ForSelectBox")]
    public IActionResult GetForSelectBox()
    {
        var result = _brandService.GetForSelectBox();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("ForTable")]
    public IActionResult GetForTable()
    {
        var result = _brandService.GetForTable();
        return Ok(result);
    }
  
    
    [HttpGet("{brandId}")]
    public IActionResult Get(int brandId)
    {
        var result = _brandService.GetById(brandId);
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Post(Brand brand)
    {
        var result = _brandService.Add(brand);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [Route("Delete/{brandId}")]
    [HttpPost]
    public IActionResult Delete(int brandId)
    {
        var result = _brandService.Delete(brandId);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
    
    [Route("Update")]
    [HttpPost]
    public IActionResult Update(Brand brand)
    {
        var result = _brandService.Update(brand);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
}