namespace Entities.DTOs;

public class VehicleDTO
{
    public string? Plate { get; set; }
    public int Type { get; set; }
    public int FuelType { get; set; }
    public int OwnerId { get; set; }
    public int BrandId { get; set; }
    public string? ModelName { get; set; }
    public int ModelYear { get; set; }
    public int Color { get; set; }
    public int DepartmentId { get; set; }
    public int Status { get; set; }
    public string? Note { get; set; }
}