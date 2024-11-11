namespace Common.Requests;

public record CreateFuncao(       
    String Fnc_descri,
    String Fnc_ativo,
    String Fnc_usubdd,
    int Fnc_usucri,
    int Fnc_usualt,
    DateTime Fnc_datcri,
    DateTime Fnc_datalt
);

public record UpdateFuncao(
    int Id,
    String Fnc_descri,
    String Fnc_ativo,
    String Fnc_usubdd,
    int Fnc_usucri,
    int Fnc_usualt,
    DateTime Fnc_datcri,
    DateTime Fnc_datalt
);