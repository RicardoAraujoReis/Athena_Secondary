using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class PreAtendimentoPlantaoController : BaseApiController
{
    /// <summary>
    /// Adiciona um Pre Atendimento
    /// </summary>
    /// <param name="CreatePreAtendimentoPlantaoAsync">Objeto com os campos necessários para criação de um Pre Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePreAtendimentoPlantaoAsync([FromBody] CreatePreAtendimentoPlantao createPreAtendimentoPlantao)
    {
        var response = await Sender.Send(new CreatePreAtendimentoPlantaoCommand { CreatePreAtendimentoPlantao = createPreAtendimentoPlantao });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Pre Atendimento
    /// </summary>
    /// <param name="UpdatePreAtendimentoPlantaoAsync">Objeto com os campos necessários para atualização de um Pre Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePreAtendimentoPlantaoAsync([FromBody] UpdatePreAtendimentoPlantao updatePreAtendimentoPlantao)
    {
        var response = await Sender.Send(new UpdatePreAtendimentoPlantaoCommand { UpdatePreAtendimentoPlantao = updatePreAtendimentoPlantao });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Deleta um Pre Atendimento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePreAtendimentoPlantaoAsync(int id)
    {
        var response = await Sender.Send(new DeletePreAtendimentoPlantaoCommand { IdPreAtendimentoPlantaoToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todos os Pre Atendimentos cadastrados
    /// </summary>
    /// <param name="GetPreAtendimentoPlantaoAllAsync">Objeto com os campos necessários para busca dos Pre Atendimentos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPreAtendimentoPlantaoAllAsync()
    {
        var response = await Sender.Send(new GetPreAtendimentoPlantaoAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca um Pre Atendimento cadastrado por Id
    /// </summary>
    /// <param name="GetPreAtendimentoPlantaoByIdAsync">Objeto com os campos necessários para busca do Pre Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPreAtendimentoPlantaoByIdAsync(int id)
    {
        var response = await Sender.Send(new GetPreAtendimentoPlantaoById { Ptd_identi = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}