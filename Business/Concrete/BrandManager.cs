using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Brand;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;
    private readonly IVehicleService _vehicleService;
    public BrandManager(IBrandDal brandDal, IVehicleService vehicleService)
    {
        _brandDal = brandDal;
        _vehicleService = vehicleService;
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
    }

    public IDataResult<Brand> GetById(int brandId)
    {
        return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId), Messages.BrandListed);
    }


    [ValidationAspect(typeof(BrandValidator))]
    public IResult Add(Brand brand)
    {
        if (BrandExists(brand.Name).Success)
        {
            return new ErrorResult(Messages.BrandAlreadyExists);
        }
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }

    public IResult Delete(int id)
    {
        var result = CheckIfBrandHasVehicles(id).Success;
        if (!result)
        {
            return new ErrorResult(Messages.OwnerHasVehicles);
        }
        var deletedBrand= _brandDal.Get(o=> o.Id == id);
        deletedBrand.IsDeleted = true;
        _brandDal.Update(deletedBrand);
        return new SuccessResult(Messages.BrandDeleted);
    }

    [ValidationAspect(typeof(BrandValidator))]
    public IResult Update(Brand brand)
    {
        if (BrandExists(brand.Name).Success)
        {
            return new ErrorResult(Messages.BrandAlreadyExists);
        }
        _brandDal.Update(brand);
        return new SuccessResult(Messages.BrandUpdated);
    }

    public IDataResult<List<SelectBoxDto>> GetForSelectBox()
    {
        return new SuccessDataResult<List<SelectBoxDto>>(_brandDal.GetBrandsForSelectBox(), Messages.BrandsListed);


    }

    public IDataResult<List<BrandForTableDto>> GetForTable()
    {
        return new SuccessDataResult<List<BrandForTableDto>>(_brandDal.GetForTable(), Messages.BrandsListed);

    }
    
    public IResult BrandExists(string name)
    {
        if (_brandDal.GetAll(b => b.Name == name &&  b.IsDeleted != true).Any())
        {
            return new SuccessResult(Messages.BrandAlreadyExists);
        }
        return new ErrorResult();
    }
    
    private IResult CheckIfBrandHasVehicles(int brandId)
    {
        var result = _vehicleService.GetByBrandId(brandId);
        if (result.Data.Any())
        {
            return new ErrorResult(Messages.BrandHasVehicles);
        }

        return new SuccessResult();
    }
}