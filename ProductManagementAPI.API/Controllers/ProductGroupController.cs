using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.ProductGroups.Queries;
using ProductManagementAPI.Application.ProductGroups.Commands;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _mediator.Send(new GetAllProductGroupsQuery());
        return Ok(groups);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var group = await _mediator.Send(new GetProductGroupByIdQuery(id));
        if (group == null) return NotFound();
        return Ok(group);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductGroupDto dto)
    {
        var group = await _mediator.Send(new CreateProductGroupCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductGroupDto dto)
    {
        var updated = await _mediator.Send(new UpdateProductGroupCommand(id, dto));
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteProductGroupCommand(id));
        if (!deleted) return NotFound();
        return NoContent();
    }
}
