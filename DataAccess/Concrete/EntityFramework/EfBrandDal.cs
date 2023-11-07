using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfBrandDal : EfEntityRepositoryBase<Brand, VehicleDeliveryContext>, IBrandDal
{
    public List<SelectBoxDto> GetBrandsForSelectBox()
    {
        using VehicleDeliveryContext context = new();
        var result =  (from brand in context.Brands
            where brand.IsDeleted != true
            select new SelectBoxDto()
            {
                Id = brand.Id,
                SelectBoxValue = brand.Name,
            }).ToList();

        return result;
    }
}