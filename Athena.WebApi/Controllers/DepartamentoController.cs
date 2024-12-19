using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class DepartamentoController : BaseApiController
{
    /// <summary>
    /// Adiciona um Departamento
    /// </summary>
    /// <param name="CreateDepartamentoAsync">Objeto com os campos necessários para criação de um Departamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDepartamentoAsync([FromBody] CreateDepartamento createDepartamento)
    {
        try
        {
            var response = await Sender.Send(new CreateDepartamentoCommand { CreateDepartamento = createDepartamento });

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

    /// <summary>
    /// Atualiza um Departamento
    /// </summary>
    /// <param name="UpdateDepartamentoAsync">Objeto com os campos necessários para atualização de um Departamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDepartamentoAsync([FromBody] UpdateDepartamento updateDepartamento)
    {
        try
        {
            var response = await Sender.Send(new UpdateDepartamentoCommand { UpdateDepartamento = updateDepartamento });

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

    /// <summary>
    /// Deleta um Departamento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDepartamentoAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteDepartamentoCommand { IdDepartamentoToDelete = id });

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

    /// <summary>
    /// Busca todos os Departamentos cadastrados
    /// </summary>
    /// <param name="GetDepartamentoAllAsync">Objeto com os campos necessários para busca dos Departamentos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartamentoAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetDepartamentoAll());

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

    /// <summary>
    /// Busca um Departamento cadastrado por Id
    /// </summary>
    /// <param name="GetDepartamentoByIdAsync">Objeto com os campos necessários para busca do Departamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartamentoByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetDepartamentoById { Id = id });

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

    /// <summary>
    /// Busca uma lista de Departamentos cadastrados
    /// </summary>
    /// <param name="GetDepartamentoByIdAsync">Objeto com os campos necessários para busca dos Departamentos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbystatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartamentoByStatus(string status)
    {
        try
        {
            var response = await Sender.Send(new GetDepartamentoByStatus { StatusDepartamento = status });

            if (!response.IsSuccessful)
            {
                return NotFound(response);
            }
            return Ok(response);
        }catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}