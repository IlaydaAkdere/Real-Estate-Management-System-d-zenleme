using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync()
        {
            var properties = await _unitOfWork.Properties.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(properties);
        }

        public async Task<PropertyDto> GetPropertyByIdAsync(int id)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            return _mapper.Map<PropertyDto>(property);
        }

        public async Task AddPropertyAsync(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.CompleteAsync();
        }

        public async Task ApprovePropertyAsync(int id)
        {
            var property = await _unitOfWork.Properties.GetByIdAsync(id);
            if (property != null)
            {
                property.IsApproved = true;
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task DeletePropertyAsync(int id)
        {
            await _unitOfWork.Properties.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }

}
