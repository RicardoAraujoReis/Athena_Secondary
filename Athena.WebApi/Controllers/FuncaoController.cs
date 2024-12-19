using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class FuncaoController : BaseApiController
{
    /// <summary>
    /// Adiciona uma Função
    /// </summary>
    /// <param name="CreateFuncaoAsync">Objeto com os campos necessários para criação de uma Função</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateFuncaoAsync([FromBody] CreateFuncao createFuncao)
    {
        try
        {
            var response = await Sender.Send(new CreateFuncaoCommand { CreateFuncao = createFuncao });

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
    /// Atualiza uma Função
    /// </summary>
    /// <param name="UpdateFuncaoAsync">Objeto com os campos necessários para atualização de uma Função</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateFuncaoAsync([FromBody] UpdateFuncao updateFuncao)
    {
        try
        {
            var response = await Sender.Send(new UpdateFuncaoCommand { UpdateFuncao = updateFuncao });

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
    /// Deleta uma Função
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteFuncaoAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteFuncaoCommand { IdFuncaoToDelete = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    /// <summary>
    /// Busca todas as Funções cadastradas
    /// </summary>
    /// <param name="GetFuncaoAllAsync">Objeto com os campos necessários para busca das Funções</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
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
    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFuncaoByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetFuncaoById { Id = id });

            if (!response.IsSuccessful)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    /// <summary>
    /// Busca uma lista de Funções cadastradas
    /// </summary>
    /// <param name="GetDepartamentoByIdAsync">Objeto com os campos necessários para busca das Funções</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbystatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFuncaoByStatus(string status)
    {
        try
        {
            var response = await Sender.Send(new GetFuncaoByStatus { StatusFuncao = status });

            if (!response.IsSuccessful)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}