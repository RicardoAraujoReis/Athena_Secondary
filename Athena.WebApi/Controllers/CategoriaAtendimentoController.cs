using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class CategoriaAtendimentoController : BaseApiController
{
    /// <summary>
    /// Adiciona uma Categoria de Atendimento
    /// </summary>
    /// <param name="CreateCategoriaAtendimentoPlantaoAsync">Objeto com os campos necessários para criação de uma Categoria de Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateCategoriaAtendimentoAsync([FromBody] CreateCategoriaAtendimento createCategoriaAtendimento)
    {
        var response = await Sender.Send(new CreateCategoriaAtendimentoCommand { CreateCategoriaAtendimento = createCategoriaAtendimento });

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza uma Categoria de Atendimento
    /// </summary>
    /// <param name="UpdateCategoriaAtendimentoAsync">Objeto com os campos necessários para atualização de uma Categoria de Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateCategoriaAtendimentoAsync([FromBody] UpdateCategoriaAtendimento updateCategoriaAtendimento)
    {
        var response = await Sender.Send(new UpdateCategoriaAtendimentoCommand { UpdateCategoriaAtendimento = updateCategoriaAtendimento });

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }    

    /// <summary>
    /// Deleta uma Categoria de Atendimento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCategoriaAtendimentoAsync(int id)
    {
        var response = await Sender.Send(new DeleteCategoriaAtendimentoCommand { IdCategoriaAtendimentoToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todas as Categorias de Atendimento cadastradas
    /// </summary>
    /// <param name="GetCategoriaAtendimentoAllAsync">Objeto com os campos necessários para busca das Categorias de Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategoriaAtendimentoAllAsync()
    {
        var response = await Sender.Send(new GetCategoriaAtendimentoAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca uma Categoria de Atendimento cadastrada por Id
    /// </summary>
    /// <param name="GetCategoriaAtendimentoByIdAsync">Objeto com os campos necessários para busca da Categoria de Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategoriaAtendimentoByIdAsync(int id)
    {
        var response = await Sender.Send(new GetCategoriaAtendimentoById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
