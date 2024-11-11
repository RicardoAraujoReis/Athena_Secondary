using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using common.Requests;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class ClienteController : BaseApiController
{
    /// <summary>
    /// Adiciona um Cliente
    /// </summary>
    /// <param name="CreateClienteAsync">Objeto com os campos necessários para criação de um Cliente</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateClienteAsync([FromBody] CreateCliente createCliente)
    {
        var response = await Sender.Send(new CreateClienteCommand { CreateCliente = createCliente });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Cliente
    /// </summary>
    /// <param name="UpdateClienteAsync">Objeto com os campos necessários para atualização de um Cliente</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateClienteAsync([FromBody] UpdateCliente updateCliente)
    {
        var response = await Sender.Send(new UpdateClienteCommand { UpdateCliente = updateCliente });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Deleta um Cliente
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteClienteAsync(int id)
    {
        var response = await Sender.Send(new DeleteClienteCommand { IdClienteToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todos os Clientes cadastrados
    /// </summary>
    /// <param name="GetClienteAllAsync">Objeto com os campos necessários para busca dos Clientes</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClienteAllAsync()
    {
        var response = await Sender.Send(new GetClienteAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca um Cliente cadastrado por Id
    /// </summary>
    /// <param name="GetClienteByIdAsync">Objeto com os campos necessários para busca do Cliente</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClienteByIdAsync(int id)
    {
        var response = await Sender.Send(new GetClienteById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}