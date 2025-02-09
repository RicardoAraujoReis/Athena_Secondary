using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class ComentariosAtendimentoPlantaoController : BaseApiController
{
    /// <summary>
    /// Adiciona um Comentário a um Atendimento
    /// </summary>
    /// <param name="CreateComentariosAtendimentoPlantaoAsync">Objeto com os campos necessários para criação de um Comentário para um Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateComentariosAtendimentoPlantaoAsync([FromBody] CreateComentariosAtendimentoPlantao createComentariosAtendimentoPlantao)
    {
        try
        {
            var response = await Sender.Send(new CreateComentariosAtendimentoPlantaoCommand { CreateComentariosAtendimentoPlantao = createComentariosAtendimentoPlantao });

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
    /// Atualiza um Comentário de um Atendimento
    /// </summary>
    /// <param name="UpdateComentariosAtendimentoPlantaoAsync">Objeto com os campos necessários para atualização de um Comentário de um Atendimento</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateComentariosAtendimentoPlantaoAsync([FromBody] UpdateComentariosAtendimentoPlantao updateComentariosAtendimentoPlantao)
    {
        try
        {
            var response = await Sender.Send(new UpdateComentariosAtendimentoPlantaoCommand { UpdateComentariosAtendimentoPlantao = updateComentariosAtendimentoPlantao });

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
    /// Deleta um Comentário de um Atendimento
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteComentarioAtendimentoPlantaoAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteComentariosAtendimentoPlantaoCommand { IdComentarioToDelete = id });

            if (response.IsSuccessful)
            {
                return NoContent();
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    /// <summary>
    /// Busca todos os Comentário de um Atendimento
    /// </summary>
    /// <param name="GetAtendimentoPlantaoAllAsync">Objeto com os campos necessários para busca dos Comentários</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetComentariosAtendimentoPlantaoAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetComentariosAtendimentoPlantaoAll());

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
    /// Busca por Id um Comentário de um Atendimento cadastrado
    /// </summary>
    /// <param name="GetComentarioAtendimentoPlantaoByIdAsync">Objeto com os campos necessários para busca do Comentário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetComentarioAtendimentoPlantaoByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetComentarioAtendimentoPlantaoById { Id = id });

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
