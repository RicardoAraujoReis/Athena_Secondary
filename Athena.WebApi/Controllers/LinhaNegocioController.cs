using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class LinhaNegocioController : BaseApiController
{
    /// <summary>
    /// Adiciona uma Linha de Negocio
    /// </summary>
    /// <param name="CreateLinhaNegocioAsync">Objeto com os campos necessários para criação de uma Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateLinhaNegocioAsync([FromBody] CreateLinhaNegocio createLinhaNegocio)
    {
        var response = await Sender.Send(new CreateLinhaNegocioCommand { CreateLinhaNegocio = createLinhaNegocio });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza uma Linha de Negocio
    /// </summary>
    /// <param name="UpdateLinhaNegocioAsync">Objeto com os campos necessários para atualização de uma Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateLinhaNegocioAsync([FromBody] UpdateLinhaNegocio updateLinhaNegocio)
    {
        var response = await Sender.Send(new UpdateLinhaNegocioCommand { UpdateLinhaNegocio = updateLinhaNegocio });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }   

    /// <summary>
    /// Deleta uma Linha de Negocio
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteLinhaNegocioAsync(int id)
    {
        var response = await Sender.Send(new DeleteLinhaNegocioCommand { IdLinhaNegocioToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todos as Linhas de Negocio cadastradas
    /// </summary>
    /// <param name="GetLinhaNegocioAllAsync">Objeto com os campos necessários para busca das Linhas de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLinhaNegocioAllAsync()
    {
        var response = await Sender.Send(new GetLinhaNegocioAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca uma Linha de Negocio cadastrado por Id
    /// </summary>
    /// <param name="GetLinhaNegocioByIdAsync">Objeto com os campos necessários para busca da Linha de Negocio</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLinhaNegocioByIdAsync(int id)
    {
        var response = await Sender.Send(new GetLinhaNegocioById { Lhn_identi = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}