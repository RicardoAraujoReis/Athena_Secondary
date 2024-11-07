namespace Common.Requests;

public record CreateTipoDadosListas(        
    String Tid_descri,
    String Tid_usubdd,
    DateTime Tid_datcri,
    DateTime Tid_datalt,
    int Tid_usucri,
    int Tid_usualt
);

public record UpdateTipoDadosListas(
    int Id,
    String Tid_descri,
    String Tid_usubdd,
    DateTime Tid_datcri,
    DateTime Tid_datalt,
    int Tid_usucri,
    int Tid_usualt
);