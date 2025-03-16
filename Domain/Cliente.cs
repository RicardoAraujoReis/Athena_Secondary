using Models.Interfaces;

namespace Athena.Models;

public class Cliente : BaseEntity<int>
{    
    public string Cli_descri { get; set; }
    public string Cli_ativo { get; set; }
    public string Cli_usubdd { get; set; }
    public int Cli_usucri { get; set; }
    public int? Cli_usualt { get; set; }
    public DateTime Cli_datcri { get; set; }
    public DateTime? Cli_datalt { get; set; }
    public int Cli_lhn_identi { get; set; }
    public virtual LinhaNegocio LinhaNegocio { get; set; }    
    public virtual List<PreAtendimentoPlantao> PreAtendimentos { get; set; }

    public Cliente UpdateCliente(
        int id, 
        string cli_descri,
        string cli_ativo,
        string cli_usubdd,
        int cli_usucri,
        int cli_usualt,
        DateTime cli_datcri,
        DateTime cli_datalt,
        int cli_lhn_identi)
    {
        Id = id;
        Cli_descri = cli_descri;
        Cli_ativo = cli_ativo;
        Cli_usubdd = cli_usubdd;
        Cli_usucri = cli_usucri;
        Cli_usualt = cli_usualt;
        Cli_datcri = cli_datcri;
        Cli_datalt = cli_datalt;
        Cli_lhn_identi = cli_lhn_identi;

        return this;
    }
}
