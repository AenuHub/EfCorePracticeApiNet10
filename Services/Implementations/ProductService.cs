using AutoMapper;
using EfCorePracticeApiNet10.Data;
using EfCorePracticeApiNet10.DTOs;
using EfCorePracticeApiNet10.Models;
using EfCorePracticeApiNet10.Repositories.Interfaces;
using EfCorePracticeApiNet10.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCorePracticeApiNet10.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _unitOfWork.Products.DeleteAsync(id);
            if (!deleted) return false;

            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<List<ProductReadDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<ProductReadDto>>(products);
        }

        public async Task<ProductReadDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return null;
            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task<ProductReadDto?> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return null;

            _mapper.Map(dto, product);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<ProductReadDto>(product);
        }
    }
}
