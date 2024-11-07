using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class TipoDadosListasController : BaseApiController
{    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTipoDadosListasAsync([FromBody] CreateTipoDadosListas createTipoDadosListas)
    {
        var response = await Sender.Send(new CreateTipoDadosListasCommand { CreateTipoDadosListas = createTipoDadosListas });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateTipoDadosListasAsync([FromBody] UpdateTipoDadosListas updateTipoDadosListas)
    {
        var response = await Sender.Send(new UpdateTipoDadosListasCommand { UpdateTipoDadosListas = updateTipoDadosListas });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteTipoDadosListasAsync(int id)
    {
        var response = await Sender.Send(new DeleteTipoDadosListasCommand { IdTipoDadosListasToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTipoDadosListasAllAsync()
    {
        var response = await Sender.Send(new GetTipoDadosListasAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTipoDadosListasByIdAsync(int id)
    {
        var response = await Sender.Send(new GetTipoDadosListasById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}