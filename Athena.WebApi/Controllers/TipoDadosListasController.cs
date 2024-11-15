using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class TipoDadosListasController : BaseApiController
{    
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTipoDadosListasAsync([FromBody] CreateTipoDadosListas createTipoDadosListas)
    {
        try
        {
            var response = await Sender.Send(new CreateTipoDadosListasCommand { CreateTipoDadosListas = createTipoDadosListas });

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
    public async Task<IActionResult> UpdateTipoDadosListasAsync([FromBody] UpdateTipoDadosListas updateTipoDadosListas)
    {
        try
        {
            var response = await Sender.Send(new UpdateTipoDadosListasCommand { UpdateTipoDadosListas = updateTipoDadosListas });

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
    public async Task<IActionResult> DeleteTipoDadosListasAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteTipoDadosListasCommand { IdTipoDadosListasToDelete = id });

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
    public async Task<IActionResult> GetTipoDadosListasAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetTipoDadosListasAll());

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

    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTipoDadosListasByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetTipoDadosListasById { Id = id });

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