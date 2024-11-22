using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]

public class UsuarioController : BaseApiController
{
    /// <summary>
    /// Adiciona um Usuário
    /// </summary>
    /// <param name="CreateUsuarioAsync">Objeto com os campos necessários para criação de um Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUsuarioAsync([FromBody] CreateUsuario createUsuario)
    {
        try
        {
            var response = await Sender.Send(new CreateUsuarioCommand { CreateUsuario = createUsuario });

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
    /// Atualiza um Usuário
    /// </summary>
    /// <param name="UpdateUsuarioAsync">Objeto com os campos necessários para atualização de um Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUsuarioAsync([FromBody] UpdateUsuario updateUsuario)
    {
        try
        {
            var response = await Sender.Send(new UpdateUsuarioCommand { UpdateUsuario = updateUsuario });

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
    /// Deleta um Usuário
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUsuarioAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new DeleteUsuarioCommand { IdUsuarioToDelete = id });

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
    /// Busca todos os Usuários cadastrados
    /// </summary>
    /// <param name="GetUsuarioAllAsync">Objeto com os campos necessários para busca dos Usuários</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuarioAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetUsuarioAll());

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
    /// Busca um Usuário cadastrado por Id
    /// </summary>
    /// <param name="GetUsuarioByIdAsync">Objeto com os campos necessários para busca do Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuarioByIdAsync(int id)
    {
        try
        {
            var response = await Sender.Send(new GetUsuarioById { Id = id });

            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }        
    }

    /// <summary>
    /// Busca a lista de Usuários ativos cadastrados
    /// </summary>
    /// <param name="GetUsuarioByIdAsync">Objeto com os campos necessários para busca dos Usuários</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getbystatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuarioByStatusAsync(string status)
    {
        try
        {
            var response = await Sender.Send(new GetUsuarioByStatus { StatusUsuario = status });

            if (!response.IsSuccessful)
            {
                return NotFound(response);
            }
            return Ok(response);

        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}