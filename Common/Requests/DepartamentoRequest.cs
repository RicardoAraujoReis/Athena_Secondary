namespace Common.Requests;

public record CreateDepartamento(
    String Dpt_descri,
    String Dpt_ativo,
    String Dpt_usubdd,
    int Dpt_usucri,
    int Dpt_usualt,
    DateTime Dpt_datcri,
    DateTime Dpt_datalt
);

public record UpdateDepartamento(
    int Id,
    String Dpt_descri,
    String Dpt_ativo,
    String Dpt_usubdd,
    int Dpt_usucri,
    int Dpt_usualt,
    DateTime Dpt_datcri,
    DateTime Dpt_datalt
);