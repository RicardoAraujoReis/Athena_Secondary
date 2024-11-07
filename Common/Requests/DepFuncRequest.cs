namespace Common.Requests;

public record CreateDepFunc(       
    int Dfc_dpt_identi,
    int Dfc_fnc_identi,
    int Dfc_usu_identi,
    String Dfc_usubdd,
    int Dfc_usucri,
    int Dfc_usualt,
    DateTime Dfc_datcri,
    DateTime Dfc_datalt
);

public record UpdateDepFunc(
    int Id,
    int Dfc_dpt_identi,
    int Dfc_fnc_identi,
    int Dfc_usu_identi,
    String Dfc_usubdd,
    int Dfc_usucri,
    int Dfc_usualt,
    DateTime Dfc_datcri,
    DateTime Dfc_datalt
);