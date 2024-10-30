using Application.Features.Commands;
using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("[controller]")]

public class UsuarioController : BaseApiController
{
    /// <summary>
    /// Adiciona um Usuário
    /// </summary>
    /// <param name="CreateUsuarioAsync">Objeto com os campos necessários para criação de um Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUsuarioAsync([FromBody] CreateUsuario createUsuario)
    {
        var response = await Sender.Send(new CreateUsuarioCommand { CreateUsuario = createUsuario });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Usuário
    /// </summary>
    /// <param name="UpdateUsuarioAsync">Objeto com os campos necessários para atualização de um Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUsuarioAsync([FromBody] UpdateUsuario updateUsuario)
    {
        var response = await Sender.Send(new UpdateUsuarioCommand { UpdateUsuario = updateUsuario });

        if(!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Deleta um Usuário
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUsuarioAsync(int id)
    {
        var response = await Sender.Send(new DeleteUsuarioCommand { IdUsuarioToDelete = id });

        if (response.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    /// <summary>
    /// Busca todos os Usuários cadastrados
    /// </summary>
    /// <param name="GetUsuarioAllAsync">Objeto com os campos necessários para busca dos Usuários</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuarioAllAsync()
    {
        var response = await Sender.Send(new GetUsuarioAll());

        if (!response.IsSuccessful)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Busca um Usuário cadastrado por Id
    /// </summary>
    /// <param name="GetUsuarioByIdAsync">Objeto com os campos necessários para busca do Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsuarioByIdAsync(int id)
    {
        var response = await Sender.Send(new GetUsuarioById { Usu_identi = id });

        if (!response.IsSuccessful)
        {
            return NotFound();
        }                        
        return Ok(response);
    }
}