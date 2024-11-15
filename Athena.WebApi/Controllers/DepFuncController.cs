using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class DepFuncController : BaseApiController
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDepFuncAsync([FromBody] CreateDepFunc createDepFunc)
    {
        try
        {
            var response = await Sender.Send(new CreateDepFuncCommand { CreateDepFunc = createDepFunc });

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDepFuncAsync([FromBody] UpdateDepFunc updateDepFunc)
    {
        try
        {
            var response = await Sender.Send(new UpdateDepFuncCommand { UpdateDepFunc = updateDepFunc });

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDepFuncAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteDepFuncCommand { IdDepFuncToDelete = id });

            if (response.IsSuccessful)
            {
                return NoContent();
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepFuncAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetDepFuncAll());

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    [HttpGet("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepFuncByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetDepFuncById { Id = id });

            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }
}