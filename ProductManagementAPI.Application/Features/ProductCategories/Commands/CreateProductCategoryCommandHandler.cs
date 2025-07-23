using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Application.Interfaces;

namespace ProductManagementAPI.Application.ProductCategories.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IProductCategoryService _service;
        public CreateProductCategoryCommandHandler(IProductCategoryService service)
        {
            _service = service;
        }
        public async Task<ProductCategoryDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.Dto);
        }
    }
} 