using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class DadosListasController : BaseApiController
{   
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDadosListasAsync([FromBody] CreateDadosListas createDadosListas)
    {
        try
        {
            var response = await Sender.Send(new CreateDadosListasCommand { CreateDadosListas = createDadosListas });

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDadosListasAsync([FromBody] UpdateDadosListas updateDadosListas)
    {
        try
        {
            var response = await Sender.Send(new UpdateDadosListasCommand { UpdateDadosListas = updateDadosListas });

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDadosListasAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteDadosListasCommand { IdDadosListasToDelete = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }
    
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDadosListasAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetDadosListasAll());

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDadosListasByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetDadosListasById { Id = id });

            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }
}