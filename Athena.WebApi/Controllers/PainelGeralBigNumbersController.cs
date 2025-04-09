using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]
public class PainelGeralBigNumbersController : BaseApiController
{
    /// <summary>
    /// Busca os valores atuais dos BigNumbers
    /// </summary>
    /// <param name="GetBigNumbersAsync">Objeto com os campos necessários para busca dos valores atuais dos BigNumbers</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getcurrent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBigNumbersCurrentAsync()
    {
        try
        {
            var response = await Sender.Send(new GetPainelGeralBigNumbersCurrent());

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
    /// Busca os valores dos BigNumbers
    /// </summary>
    /// <param name="GetBigNumbersAsync">Objeto com os campos necessários para busca dos valores dos BigNumbers</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBigNumbersAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetPainelGeralBigNumbersAll());

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
}
