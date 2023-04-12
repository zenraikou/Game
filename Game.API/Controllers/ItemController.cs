using Game.API.Data.IRepository;
using Game.API.Models;
using Game.API.Models.DTOs;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _context;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IItemRepository context, ILogger<ItemController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")]
    public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAll()
    {
        var items = await _context.GetAllAsync();

        if (items.Any() is false)
        {
            return NoContent();
        }

        _logger.LogInformation("Items fetched successfully.");
        return Ok(items.Adapt<IEnumerable<ItemDTO>>());
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDTO>> Get(Guid id)
    {
        var item = await _context.GetAsync(i => i.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        _logger.LogInformation("Item fetched successfully.");
        return Ok(item.Adapt<ItemDTO>());
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<ItemDTO>> Post([FromBody] ItemDTO itemDTO)
    {
        // No need to check if the model is valid since we're using '[ApiController]' attribute.
        // This action method won't execute if model is not valid.
        // If model is not valid, it will automatically produce a response type of Status Code 400 (Bad Request).
        var item = itemDTO.Adapt<Item>();
        await _context.PostAsync(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ItemDTO itemDTO)
    {
        var item = await _context.GetAsync(i => i.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        item = itemDTO.Adapt(item);
  
        await _context.UpdateAsync(item);

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<ItemDTO> patchDoc)
    {
        var item = await _context.GetAsync(i => i.Id == id, tracked: false);

        if (item is null)
        {
            return NotFound();
        }

        var itemDTO = item.Adapt<ItemDTO>();
  
        patchDoc.ApplyTo(itemDTO, ModelState);

        if (TryValidateModel(itemDTO) is false)
        {
            return BadRequest(ModelState);
        }

        item = itemDTO.Adapt(item);

        await _context.UpdateAsync(item);

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _context.GetAsync(i => i.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        await _context.DeleteAsync(item);

        return NoContent();
    }
}
