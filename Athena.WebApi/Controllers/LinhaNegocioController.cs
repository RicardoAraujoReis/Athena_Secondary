using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Azure;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class LinhaNegocioController : BaseApiController
{
    /// <summary>
    /// Adiciona uma Linha de Negocio
    /// </summary>
    /// <param name="CreateLinhaNegocioAsync">Objeto com os campos necessários para criação de uma Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateLinhaNegocioAsync([FromBody] CreateLinhaNegocio createLinhaNegocio)
    {
        try
        {
            var response = await Sender.Send(new CreateLinhaNegocioCommand { CreateLinhaNegocio = createLinhaNegocio });

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
    /// Atualiza uma Linha de Negocio
    /// </summary>
    /// <param name="UpdateLinhaNegocioAsync">Objeto com os campos necessários para atualização de uma Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateLinhaNegocioAsync([FromBody] UpdateLinhaNegocio updateLinhaNegocio)//, [FromRoute] int id)
    {
        try
        {
            var response = await Sender.Send(new UpdateLinhaNegocioCommand { UpdateLinhaNegocio = updateLinhaNegocio });

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
    /// Deleta uma Linha de Negocio
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteLinhaNegocioAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteLinhaNegocioCommand { IdLinhaNegocioToDelete = id });

            if (response.IsSuccessful)
            {
                return NoContent();
            }
            return BadRequest(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    /// <summary>
    /// Busca todos as Linhas de Negocio cadastradas
    /// </summary>
    /// <param name="GetLinhaNegocioAllAsync">Objeto com os campos necessários para busca das Linhas de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLinhaNegocioAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetLinhaNegocioAll());

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
    /// Busca uma Linha de Negocio cadastrada por Id
    /// </summary>
    /// <param name="GetLinhaNegocioByIdAsync">Objeto com os campos necessários para busca da Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLinhaNegocioByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetLinhaNegocioById { Id = id });

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
    /// Busca uma Linha de Negocio cadastrada por status
    /// </summary>
    /// <param name="GetLinhaNegocioByStatusAsync">Objeto com os campos necessários para busca da Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbystatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLinhaNegocioByStatusAsync(String status)
    {
        try
        {
            var response = await Sender.Send(new GetLinhaNegocioByStatus { LinhaNegocioByStatus = status });

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
    /// Busca uma Linha de Negocio cadastrada de acordo com o parâmetro informado
    /// </summary>
    /// <param name="GetLinhaNegocioByParametersAsync">Objeto com os campos necessários para busca da Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbyparameters")]
    public async Task<IActionResult> GetLinhaNegocioBySearchParameters(int? id, string status = null)
    {
        try
        {
            var request = new GetLinhaNegocioBySearchParameters
            {
                Id = id.HasValue ? id.Value : 0,
                LinhaNegocioByStatus = status
            };

            var results = await Sender.Send(request);

            if (!results.IsSuccessful)
            {
                return BadRequest(results);
            }
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
