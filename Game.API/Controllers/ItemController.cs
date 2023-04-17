using Game.API.Data.IRepository;
using Game.API.Mediator.Items.Queries;
using Game.API.Models;
using Game.API.Models.DTOs;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IMediator mediator, IUnitOfWork unitOfWork, ILogger<ItemController> logger)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")]
    public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAll()
    {
        var items = await _mediator.Send(new GetItemsQuery());
        //var items = await _unitOfWork.Items.GetAllAsync();

        if (items.Any() is false)
        {
            _logger.LogInformation("Items are currently empty.");
            return NoContent();
        }

        _logger.LogInformation("Items fetched successfully.");
        return Ok(items.Adapt<List<ItemDTO>>());
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDTO>> Get(Guid id)
    {
        var item = await _mediator.Send(new GetItemQuery(id));
        //var item = await _unitOfWork.Items.GetAsync(i => i.Id == id);

        if (item is null)
        {
            _logger.LogInformation("Item does not exist.");
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
        var item = itemDTO.Adapt<Item>();
        await _unitOfWork.Items.PostAsync(item);
        await _unitOfWork.SaveAsync();

        _logger.LogInformation("Item created successfully.");
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item.Adapt<ItemDTO>());
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ItemDTO itemDTO)
    {
        var item = await _unitOfWork.Items.GetAsync(i => i.Id == id);

        if (item is null)
        {
            _logger.LogInformation("Item does not exist.");
            return NotFound();
        }

        item = itemDTO.Adapt(item);
        _unitOfWork.Items.Update(item);
        await _unitOfWork.SaveAsync();

        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<ItemDTO> patchDoc)
    {
        var item = await _unitOfWork.Items.GetAsync(i => i.Id == id);

        if (item is null)
        {
            _logger.LogInformation("Item does not exist.");
            return NotFound();
        }

        var itemDTO = item.Adapt<ItemDTO>();
        patchDoc.ApplyTo(itemDTO, ModelState);

        if (TryValidateModel(itemDTO) is false)
        {
            _logger.LogInformation("Item is invalid.");
            return BadRequest(ModelState);
        }

        item = itemDTO.Adapt(item);
        _unitOfWork.Items.Update(item);
        await _unitOfWork.SaveAsync();

        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _unitOfWork.Items.GetAsync(i => i.Id == id);

        if (item is null)
        {
            _logger.LogInformation("Item does not exist.");
            return NotFound();
        }

        _unitOfWork.Items.Delete(item);
        await _unitOfWork.SaveAsync();

        _logger.LogInformation("Item deleted successfully.");
        return NoContent();
    }
}
