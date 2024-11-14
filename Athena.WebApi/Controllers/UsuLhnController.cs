using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class UsuLhnController : BaseApiController
{    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUsuLhnAsync([FromBody] CreateUsuLhn createUsuLhn)
    {
        var response = await Sender.Send(new CreateUsuLhnCommand { CreateUsuLhn = createUsuLhn });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUsuLhnAsync([FromBody] UpdateUsuLhn updateUsuLhn)
    {
        var response = await Sender.Send(new UpdateUsuLhnCommand { UpdateUsuLhn = updateUsuLhn });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUsuLhnAsync(int id)
    {
        var response = await Sender.Send(new DeleteUsuLhnCommand { IdUsuLhnToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuLhnAllAsync()
    {
        var response = await Sender.Send(new GetUsuLhnAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuLhnByIdAsync(int id)
    {
        var response = await Sender.Send(new GetUsuLhnById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}