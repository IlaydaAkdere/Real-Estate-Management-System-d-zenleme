namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync();
        Task<PropertyDto> GetPropertyByIdAsync(int id);
        Task AddPropertyAsync(PropertyDto propertyDto);
        Task ApprovePropertyAsync(int id);
        Task DeletePropertyAsync(int id);
    }

}
