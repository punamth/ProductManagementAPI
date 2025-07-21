using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Application.ProductCategories.Queries;
using ProductManagementAPI.Application.ProductCategories.Commands;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _mediator.Send(new GetAllProductCategoriesQuery());
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _mediator.Send(new GetProductCategoryByIdQuery(id));
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCategoryDto dto)
    {
        var category = await _mediator.Send(new CreateProductCategoryCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCategoryDto dto)
    {
        var updated = await _mediator.Send(new UpdateProductCategoryCommand(id, dto));
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteProductCategoryCommand(id));
        if (!deleted) return NotFound();
        return NoContent();
    }
}
