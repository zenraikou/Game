using Game.API.Data;
using Game.API.Models.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")]
    public ActionResult<List<ItemDTO>> GetAll()
    {
        var items = DB.Items;

        if (items.Any() is false)
        {
            return NoContent();
        }

        _logger.LogInformation("Items fetched successfully.");
        return Ok(items);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public ActionResult<ItemDTO> Get(int id)
    {
        var item = DB.Items.Find(i => i.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    //[ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult<ItemDTO> Post([FromBody] ItemDTO item) // change ItemDTO to Item when using AutoMapper
    {
        DB.Items.Add(item);
        // save changes when using ef core if needed

        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ItemDTO item) // change ItemDTO to Item when using AutoMapper
    {
        var updateItem = DB.Items.Find(i => i.Id == id);

        if (updateItem is null)
        {
            return NotFound();
        }

        updateItem.Name = item.Name;
        updateItem.Description = item.Description;
        // save changes when using ef core if needed

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ValidateAntiForgeryToken]
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ItemDTO> patchDoc) // change ItemDTO to Item when using AutoMapper
    {
        var updateItem = DB.Items.Find(i => i.Id == id);

        if (updateItem is null)
        {
            return NotFound();
        }

        var item = new ItemDTO()
        {
            Name = updateItem.Name,
            Description = updateItem.Description
        };
        
        patchDoc.ApplyTo(item, ModelState);

        if (TryValidateModel(item) is false)
        {
            return BadRequest(ModelState);
        }

        updateItem.Name = item.Name;
        updateItem.Description = item.Description;

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = DB.Items.Find(i => i.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        DB.Items.Remove(item);
        // save changes when using ef core if needed

        return NoContent();
    }
}