namespace common.Requests;

public record CreateCliente(        
    String Cli_descri,
    String Cli_ativo,
    String Cli_usubdd,
    int Cli_usucri,
    int Cli_usualt,
    DateTime Cli_datcri,
    DateTime Cli_datalt,
    int Cli_lhn_identi        
);

public record UpdateCliente(
    int Id,
    String Cli_descri,
    String Cli_ativo,
    String Cli_usubdd,
    int Cli_usucri,
    int Cli_usualt,
    DateTime Cli_datcri,
    DateTime Cli_datalt,
    int Cli_lhn_identi
);