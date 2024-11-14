using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class AtendimentoPlantaoController : BaseApiController
{
    /// <summary>
    /// Adiciona um Atendimento
    /// </summary>
    /// <param name="CreateAtendimentoPlantaoAsync">Objeto com os campos necessários para criação de um Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAtendimentoPlantaoAsync([FromBody] CreateAtendimentoPlantao createAtendimentoPlantao)
    {
        var response = await Sender.Send(new CreateAtendimentoPlantaoCommand { CreateAtendimentoPlantao = createAtendimentoPlantao });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Atendimento
    /// </summary>
    /// <param name="UpdateAtendimentoPlantaoAsync">Objeto com os campos necessários para atualização de um Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAtendimentoPlantaoAsync([FromBody] UpdateAtendimentoPlantao updateAtendimentoPlantao)
    {
        var response = await Sender.Send(new UpdateAtendimentoPlantaoCommand { UpdateAtendimentoPlantao = updateAtendimentoPlantao });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }    

    /// <summary>
    /// Deleta um Atendimento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAtendimentoPlantaoAsync(int id)
    {
        var response = await Sender.Send(new DeleteAtendimentoPlantaoCommand { IdAtendimentoPlantaoToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todos os Atendimentos cadastrados
    /// </summary>
    /// <param name="GetAtendimentoPlantaoAllAsync">Objeto com os campos necessários para busca dos Atendimentos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAtendimentoPlantaoAllAsync()
    {
        var response = await Sender.Send(new GetAtendimentoPlantaoAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca um Atendimento cadastrado por Id
    /// </summary>
    /// <param name="GetAtendimentoPlantaoByIdAsync">Objeto com os campos necessários para busca do Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAtendimentoPlantaoByIdAsync(int id)
    {
        var response = await Sender.Send(new GetAtendimentoPlantaoById { Id = id });

        if (!response.IsSuccessful)
        {
            return NotFound(response);
        }                        
        return Ok(response);
    }

    [HttpGet("{status}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAtendimentoPlantaoByStatusAsync(String status)
    {
        var response = await Sender.Send(new GetAtendimentoPlantaoByStatus { AtendimentoByStatus = status });

        if (!response.IsSuccessful)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}