namespace Common.Requests;

public record CreateUsuLhn(        
    int Uln_usu_identi,
    int Uln_lhn_identi,
    String Uln_usubdd,
    int Uln_usucri,
    int Uln_usualt,
    DateTime Uln_datcri,
    DateTime Uln_datalt
);

public record UpdateUsuLhn(
    int Id,
    int Uln_usu_identi,
    int Uln_lhn_identi,
    String Uln_usubdd,
    int Uln_usucri,
    int Uln_usualt,
    DateTime Uln_datcri,
    DateTime Uln_datalt
);