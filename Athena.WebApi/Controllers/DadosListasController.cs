using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class DadosListasController : BaseApiController
{   
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDadosListasAsync([FromBody] CreateDadosListas createDadosListas)
    {
        var response = await Sender.Send(new CreateDadosListasCommand { CreateDadosListas = createDadosListas });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDadosListasAsync([FromBody] UpdateDadosListas updateDadosListas)
    {
        var response = await Sender.Send(new UpdateDadosListasCommand { UpdateDadosListas = updateDadosListas });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDadosListasAsync(int id)
    {
        var response = await Sender.Send(new DeleteDadosListasCommand { IdDadosListasToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDadosListasAllAsync()
    {
        var response = await Sender.Send(new GetDadosListasAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDadosListasByIdAsync(int id)
    {
        var response = await Sender.Send(new GetDadosListasById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}