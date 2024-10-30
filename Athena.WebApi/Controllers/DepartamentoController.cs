using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class DepartamentoController : BaseApiController
{
    /// <summary>
    /// Adiciona um Departamento
    /// </summary>
    /// <param name="CreateDepartamentoAsync">Objeto com os campos necessários para criação de um Departamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDepartamentoAsync([FromBody] CreateDepartamento createDepartamento)
    {
        var response = await Sender.Send(new CreateDepartamentoCommand { CreateDepartamento = createDepartamento });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Departamento
    /// </summary>
    /// <param name="UpdateDepartamentoAsync">Objeto com os campos necessários para atualização de um Departamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDepartamentoAsync([FromBody] UpdateDepartamento updateDepartamento)
    {
        var response = await Sender.Send(new UpdateDepartamentoCommand { UpdateDepartamento = updateDepartamento });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Deleta um Departamento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDepartamentoAsync(int id)
    {
        var response = await Sender.Send(new DeleteDepartamentoCommand { IdDepartamentoToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todos os Departamentos cadastrados
    /// </summary>
    /// <param name="GetDepartamentoAllAsync">Objeto com os campos necessários para busca dos Departamentos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartamentoAllAsync()
    {
        var response = await Sender.Send(new GetDepartamentoAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca um Departamento cadastrado por Id
    /// </summary>
    /// <param name="GetDepartamentoByIdAsync">Objeto com os campos necessários para busca do Departamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartamentoByIdAsync(int id)
    {
        var response = await Sender.Send(new GetDepartamentoById { Dpt_identi = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}