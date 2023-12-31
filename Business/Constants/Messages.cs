// ReSharper disable StringLiteralTypo
// ReSharper disable ConvertToConstant.Global
namespace Business.Constants;

public static class Messages
{
    //Vehicle
    public const string VehicleAdded = "Araç başarıyla eklendi";
    public const string VehiclesListed = "Araçlar başarıyla listelendi.";
    public const string VehicleUpdated = "Araç başarıyla güncellendi";
    public const string VehicleListed= "Araç başarıyla getirildi.";
    public const string VehicleDeleted= "Araç kaydı başarıyla silindi.";

    public const string VehicleAlreadyExist = "Bu plakaya ait bir araç zaten var.";
    public const string VehicleIsOnDuty= "Araç görevde, önce görevi bitirin veya aracı düzenleyin.";

    
    //Task
    public const string TaskAdded = "Görev başarıyla eklendi!";
    public const string TasksListed = "Görevler başarıyla listelendi.";
    public const string TaskUpdated = "Görev başarıyla güncellendi";
    public const string TaskListed= "Görev başarıyla getirildi.";
    public const string TaskDeleted= "Görev başarıyla bitirildi.";
    
    //VehicleOnTask
    public const string VehicleAlreadyOnTask = "Seçtiğiniz araç şuan görevde.";
    public const string VehicleOnTaskAdded = "Araç görevlendirildi.";
    public const string VehiclesOnTaskListed = "Araç görevleri başarıyla listelendi.";
    public const string VehicleOnTaskUpdated = "Araç görevi güncellendi.";
    public const string VehicleOnTaskListed = "Araç görev detayı getirildi.";
    public const string VehicleOnTaskTaskFinished = "Araç görevi başarıyla tamamlandı.";
    public const string VehicleOnTaskTaskDeleted = "Araç görevi başarıyla silindi.";

 
    
    //Driver
    public const string DriverAdded = "Sürücü başarıyla eklendi";
    public const string DriversListed = "Sürücüler başarıyla listelendi.";
    public const string DriverUpdated = "Sürücü başarıyla güncellendi";
    public const string DriverListed= "Sürücü başarıyla getirildi.";
    public const string DriverDeleted = "Sürücü kaydı başarıyla silindi.";
    public const string DriverIsOnMission = "Sürücü halihazırda görevde. Lütfen önce görevi bitirin.";
    
    //Brand
    public const string BrandAdded = "Marka başarıyla eklendi.";
    public const string BrandsListed = "Markalar başarıyla listelendi.";
    public const string BrandListed = "Marka başarıyla getirildi.";
    public const string BrandDeleted = "Marka başarıyla silindi.";
    public const string BrandUpdated = "Marka başarıyla güncellendi.";
    public const string BrandAlreadyExists = "Bu adda bir marka zaten var.";
    public const string BrandHasVehicles = "Bu markaya ait araç var, önce onları silin..";
    
    //Owner
    public const string OwnerAdded = "Araç sahibi başarıyla eklendi.";
    public const string OwnersListed = "Araç sahipleri başarıyla listelendi.";
    public const string OwnerListed = "Araç sahibi başarıyla getirildi.";
    public const string OwnerDeleted = "Araç sahibi başarıyla silindi.";
    public const string OwnerUpdated = "Araç sahibi başarıyla güncellendi.";
    public const string OwnerAlreadyExists = "Böyle bir sahip zaten var.";
    public const string OwnerHasVehicles = "Bu sahibe ait araç var, önce onları silin.";
    
    //Departments
    public const string DepartmentsAdded = "Departman başarıyla eklendi.";
    public const string DepartmentsListed = "Departmanlar başarıyla listelendi.";
    public const string DepartmentDeleted = "Departman kaydı başarıyla silindi..";
    public const string DepartmentUpdated = "Departman kaydı başarıyla güncellendi.";
    public const string DepartmentHasVehicles = "Departmana ait araç var, önce onları silin.";
    public const string DepartmentHasActiveTask = "Departmana ait aktif görev var, önce onları silin.";
    public const string DepartmantHasPredefinedTask = "Departmana ait öntanımlı görev var, önce onları silin veya düzenleyin.";

    //Users
    public const string UserRegistered = "Kullanıcı başarıyla kayıt edildi.";
    public const string UserDeleted = "Kullanıcı başarıyla silindi.";
    public const string UserNotFound = "Böyle bir kullanıcı yok.";
    public const string UserUpdated = "Kullanıcı başarıyla güncellendi.";

    public const string PasswordError = "Şifre yanlış.";
    public const string UserAlreadyExists = "Böyle bir kullanıcı zaten var.";
    public const string SuccessfulLogin = "Başarıyla giriş yapıldı.";
    public const string AccessTokenCreated = "Giriş tokeni oluşturuldu.";
    public const string SuccessfulPasswordChange = "Başarıyla şifre değiştirildi.";

    public const string AccessTokenError = "Bir sorun meydana geldi. Sorun doğrulama tipi olabilir.";
    public const string PasswordRequired = "Form Kullanıcıları için şifre gerekli.";

    public const string LdapUserHasNoPassword = "Sizin şifreniz buradan değiştirilemez.";


    public const string NotFound = "İstenilen veri(ler) bulunamadı.";
    public const string AuthorizationDenied = "Bu işlemi yapmaya yetkiniz yok..";


    public const string RoleAdded = "Kullanıcıya rol eklendi.";
    public const string RoleDeleted = "Rol silindi.";
}