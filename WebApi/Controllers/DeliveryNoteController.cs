using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Entities.DTO_s;
[Route("api/[controller]")]
[ApiController]
public class DeliveryNoteController : ControllerBase
{
    private readonly IDeliveryNoteService _deliveryNoteService;

    public DeliveryNoteController(IDeliveryNoteService deliveryNoteService)
    {
        _deliveryNoteService = deliveryNoteService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(SevkIrsaliyeCreateDto deliveryNoteDto)
    {
        var result = await _deliveryNoteService.CreateDeliveryNoteAsync(deliveryNoteDto.DeliveryNote, deliveryNoteDto.Items);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

   
    [HttpGet("GetAllWithItemsAndCustomerAsync")]
    public async Task<IActionResult> GetAllWithItemsAndCustomerAsync()
    {
        var result = await _deliveryNoteService.GetAllWithItemsAndCustomerAsync();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(SevkIrsaliye deliveryNote)
    {
        var result = await _deliveryNoteService.DeleteDeliveryNoteAsync(deliveryNote);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(SevkIrsaliyeCreateDto deliveryNoteDto)
    {
        var result = await _deliveryNoteService.UpdateDeliveryNoteAsync(deliveryNoteDto.DeliveryNote, deliveryNoteDto.Items);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _deliveryNoteService.GetDeliveryNoteWithItemsByIdAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("DeleteItem")]
    public async Task<IActionResult> DeleteItem(SevkIrsaliyeKalem item)
    {
        var result = await _deliveryNoteService.DeleteDeliveryNoteItemAsync(item);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);

    }


   
}
