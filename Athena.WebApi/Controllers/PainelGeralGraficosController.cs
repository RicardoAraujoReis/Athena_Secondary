using Application.Features.Queries;
using Athena.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Mvc;

namespace Athena.WebApi.Controllers;

[Route("api/[controller]")]
public class PainelGeralGraficosController : BaseApiController
{
    /// <summary>
    /// Busca os valores dos Gráficos
    /// </summary>
    /// <param name="GetPainelGeralGraficosAll">Objeto com os campos necessários para busca dos valores dos Gráficos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPainelGeralGraficosAllAsync()
    {
        try
        {
            var response = await Sender.Send(new GetPainelGeralGraficosAll());

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
