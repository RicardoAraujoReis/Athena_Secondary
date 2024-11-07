namespace Common.Requests;

public record CreateLinhaNegocio(        
    String Lhn_descri,
    String Lhn_ativo,
    String Lhn_usubdd,
    int Lhn_usucri,
    int Lhn_usualt,
    DateTime Lhn_datcri,
    DateTime Lhn_datalt
);

public record UpdateLinhaNegocio(    
    int Id,
    String Lhn_descri,
    String Lhn_ativo,
    String Lhn_usubdd,
    int Lhn_usucri,
    int Lhn_usualt,
    DateTime Lhn_datcri,
    DateTime Lhn_datalt
);