using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductManagementAPI.Application.DTOs.ProductGroups;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductGroupController : ControllerBase
{
    private readonly IProductGroupService _service;

    public ProductGroupController(IProductGroupService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _service.GetAllAsync();
        return Ok(groups);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var group = await _service.GetByIdAsync(id);
        if (group == null) return NotFound();
        return Ok(group);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductGroupDto dto)
    {
        var group = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductGroupDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}