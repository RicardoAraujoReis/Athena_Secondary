using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class FuncaoController : BaseApiController
{
    /// <summary>
    /// Adiciona uma Função
    /// </summary>
    /// <param name="CreateFuncaoAsync">Objeto com os campos necessários para criação de uma Função</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateFuncaoAsync([FromBody] CreateFuncao createFuncao)
    {
        var response = await Sender.Send(new CreateFuncaoCommand { CreateFuncao = createFuncao });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza uma Função
    /// </summary>
    /// <param name="UpdateFuncaoAsync">Objeto com os campos necessários para atualização de uma Função</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateFuncaoAsync([FromBody] UpdateFuncao updateFuncao)
    {
        var response = await Sender.Send(new UpdateFuncaoCommand { UpdateFuncao = updateFuncao });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Deleta uma Função
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteFuncaoAsync(int id)
    {
        var response = await Sender.Send(new DeleteFuncaoCommand { IdFuncaoToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todas as Funções cadastradas
    /// </summary>
    /// <param name="GetFuncaoAllAsync">Objeto com os campos necessários para busca das Funções</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFuncaoAllAsync()
    {
        var response = await Sender.Send(new GetFuncaoAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca uma Função cadastrada por Id
    /// </summary>
    /// <param name="GetFuncaoByIdAsync">Objeto com os campos necessários para busca da Função</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFuncaoByIdAsync(int id)
    {
        var response = await Sender.Send(new GetFuncaoById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}