using FluentValidation;
using FluentValidation.Results;
using Game.API.Contracts.Item;
using Game.API.Mediator.ItemCQRS.Commands;
using Game.API.Mediator.ItemCQRS.Queries;
using Game.API.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly IMediator _mediator;

    public ItemController(ILogger<ItemController> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")] /* GET: {host}/api/items */
    public async Task<ActionResult<IEnumerable<GetItemResponse>>> GetAll()
    {
        var items = await _mediator.Send(new GetItemsQuery());

        if (items.Any() is false)
        {
            _logger.LogInformation("Items are currently empty.");
            return NoContent();
        }

        _logger.LogInformation("Items fetched successfully.");
        return Ok(items.Adapt<List<GetItemResponse>>());
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")] /* GET: {host}/api/item/{id} */
    public async Task<ActionResult<GetItemResponse>> Get(Guid id)
    {
        var item = await _mediator.Send(new GetItemQuery(id));

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        _logger.LogInformation("Item fetched successfully.");
        return Ok(item.Adapt<GetItemResponse>());
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost] /* POST: {host}/api/item */
    public async Task<ActionResult<GetItemResponse>> Post(UpsertItemRequest request, IValidator<UpsertItemRequest> validator)
    {
        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            var dictionary = new ModelStateDictionary();
            
            foreach (ValidationFailure failure in result.Errors)
            {
                dictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            _logger.LogError("Item is invalid.");
            return ValidationProblem(dictionary);
        }

        var item = request.Adapt<Item>();
        await _mediator.Send(new PostItemCommand(item));

        _logger.LogInformation("Item created successfully.");
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item.Adapt<GetItemResponse>());
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id}")] /* PUT: {host}/api/item/{id} */
    public async Task<IActionResult> Put(Guid id, UpsertItemRequest request, IValidator<UpsertItemRequest> validator)
    {
        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            var dictionary = new ModelStateDictionary();
            
            foreach (ValidationFailure failure in result.Errors)
            {
                dictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            _logger.LogError("Item is invalid.");
            return ValidationProblem(dictionary);
        }

        var item = await _mediator.Send(new GetItemQuery(id));

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        item = request.Adapt(item);
        await _mediator.Send(new UpdateItemCommand(item));

        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("{id}")] /* PATCH: {host}/api/item/{id} */
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<UpsertItemRequest> patchDoc, IValidator<UpsertItemRequest> validator)
    {
        var item = await _mediator.Send(new GetItemQuery(id));

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        var request = item.Adapt<UpsertItemRequest>();
        patchDoc.ApplyTo(request);

        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            var dictionary = new ModelStateDictionary();
            
            foreach (ValidationFailure failure in result.Errors)
            {
                dictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            _logger.LogError("Item is invalid.");
            return ValidationProblem(dictionary);
        }

        request.Adapt(item);
        await _mediator.Send(new UpdateItemCommand(item));

        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")] /* DELETE: {host}/api/item/{id} */
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _mediator.Send(new GetItemQuery(id));

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        await _mediator.Send(new DeleteItemCommand(item));

        _logger.LogInformation("Item deleted successfully.");
        return NoContent();
    }
}
