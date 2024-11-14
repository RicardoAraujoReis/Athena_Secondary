using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class DepFuncController : BaseApiController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDepFuncAsync([FromBody] CreateDepFunc createDepFunc)
    {
        var response = await Sender.Send(new CreateDepFuncCommand { CreateDepFunc = createDepFunc });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDepFuncAsync([FromBody] UpdateDepFunc updateDepFunc)
    {
        var response = await Sender.Send(new UpdateDepFuncCommand { UpdateDepFunc = updateDepFunc });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDepFuncAsync(int id)
    {
        var response = await Sender.Send(new DeleteDepFuncCommand { IdDepFuncToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepFuncAllAsync()
    {
        var response = await Sender.Send(new GetDepFuncAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepFuncByIdAsync(int id)
    {
        var response = await Sender.Send(new GetDepFuncById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}