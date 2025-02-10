using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class PreAtendimentoPlantaoController : BaseApiController
{
    /// <summary>
    /// Adiciona um Pre Atendimento
    /// </summary>
    /// <param name="CreatePreAtendimentoPlantaoAsync">Objeto com os campos necessários para criação de um Pre Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePreAtendimentoPlantaoAsync([FromBody] CreatePreAtendimentoPlantao createPreAtendimentoPlantao)
    {
        try
        {
            var response = await Sender.Send(new CreatePreAtendimentoPlantaoCommand { CreatePreAtendimentoPlantao = createPreAtendimentoPlantao });

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
    /// Atualiza um Pre Atendimento
    /// </summary>
    /// <param name="UpdatePreAtendimentoPlantaoAsync">Objeto com os campos necessários para atualização de um Pre Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePreAtendimentoPlantaoAsync([FromBody] UpdatePreAtendimentoPlantao updatePreAtendimentoPlantao)
    {
        try
        {
            var response = await Sender.Send(new UpdatePreAtendimentoPlantaoCommand { UpdatePreAtendimentoPlantao = updatePreAtendimentoPlantao });

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
    /// Deleta um Pre Atendimento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePreAtendimentoPlantaoAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeletePreAtendimentoPlantaoCommand { IdPreAtendimentoPlantaoToDelete = id });

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
    /// Busca todos os Pre Atendimentos cadastrados
    /// </summary>
    /// <param name="GetPreAtendimentoPlantaoAllAsync">Objeto com os campos necessários para busca dos Pre Atendimentos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPreAtendimentoPlantaoAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetPreAtendimentoPlantaoAll());

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
    /// Busca um Pre Atendimento cadastrado por Id
    /// </summary>
    /// <param name="GetPreAtendimentoPlantaoByIdAsync">Objeto com os campos necessários para busca do Pre Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPreAtendimentoPlantaoByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetPreAtendimentoPlantaoById { Id = id });

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