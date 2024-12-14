namespace common.Requests;

public class CreateCliente {
    public String Cli_descri { get; set; }
    public String Cli_ativo { get; set; }
    public String Cli_usubdd { get; set; }
    public int Cli_usucri { get; set; }
    public int? Cli_usualt { get; set; }
    public DateTime Cli_datcri { get; set; }
    public DateTime? Cli_datalt { get; set; }
    public int Cli_lhn_identi { get; set; }
};

public class UpdateCliente {
    public int Id { get; set; }
    public String Cli_descri { get; set; }
    public String Cli_ativo { get; set; }
    public String Cli_usubdd { get; set; }
    public int Cli_usucri { get; set; }
    public int Cli_usualt { get; set; }
    public DateTime Cli_datcri { get; set; }
    public DateTime Cli_datalt { get; set; }
    public int Cli_lhn_identi { get; set; }
};