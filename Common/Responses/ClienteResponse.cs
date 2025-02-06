
namespace Common.Responses;

public class ClienteResponse
{
    public int Id { get; set; }
    public string Cli_descri { get; set; }
    public string Cli_ativo { get; set; }
    public string Cli_usubdd { get; set; }
    public int Cli_usucri { get; set; }
    public int Cli_usualt { get; set; }
    public DateTime Cli_datcri { get; set; }
    public DateTime Cli_datalt { get; set; }
    public int Cli_lhn_identi { get; set; }
    public virtual LinhaNegocioResponse LinhaNegocio { get; set; }
}
