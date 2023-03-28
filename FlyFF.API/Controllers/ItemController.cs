using FlyFF.API.Data;
using FlyFF.API.Models.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FlyFF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")]
    public ActionResult<List<ItemDTO>> List()
    {
        var items = DB.Items;

        if (items.Any() is false)
        {
            return NoContent();
        }

        return Ok(items);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public ActionResult<ItemDTO> Get(Guid id)
    {
        var item = DB.Items.Find(v => v.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    //[ValidateAntiForgeryToken]
    [HttpPost("create")]
    public ActionResult<ItemDTO> Post([FromBody] ItemDTO item) // change ItemDTO to Item when using AutoMapper
    {
        DB.Items.Add(item);
        // save changes when using ef core if needed

        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("update/{id}")]
    public IActionResult Put(Guid id, [FromBody] ItemDTO item) // change ItemDTO to Item when using AutoMapper
    {
        var itemToUpdate = DB.Items.Find(v => v.Id == id);

        if (itemToUpdate is null)
        {
            return NotFound();
        }

        itemToUpdate.Name = item.Name;
        itemToUpdate.Description = item.Description;
        // save changes when using ef core if needed

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ValidateAntiForgeryToken]
    [HttpPatch("patch/{id}")]
    public IActionResult Patch(Guid id, JsonPatchDocument<ItemDTO> patchDoc) // change ItemDTO to Item when using AutoMapper
    {
        var existingItem = DB.Items.Find(v => v.Id == id);

        if (existingItem is null)
        {
            return NotFound();
        }

        var itemToPatch = new ItemDTO
        {
            Name = existingItem.Name,
            Description = existingItem.Description
        };
        
        patchDoc.ApplyTo(itemToPatch, ModelState);

        if (!TryValidateModel(itemToPatch))
        {
            return BadRequest(ModelState);
        }

        existingItem.Name = itemToPatch.Name;
        existingItem.Description = itemToPatch.Description;

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        var item = DB.Items.Find(v => v.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        DB.Items.Remove(item);
        // save changes when using ef core if needed

        return NoContent();
    }
}