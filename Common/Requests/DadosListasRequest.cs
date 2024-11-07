namespace Common.Requests;

public record CreateDadosListas(        
    int Dal_tid_identi,
    String Dal_valor,
    String Dal_usubdd,
    DateTime Dal_datcri,
    DateTime Dal_datalt,
    int Dal_usucri,
    int Dal_usualt
);

public record UpdateDadosListas(
    int Id,
    int Dal_tid_identi,
    String Dal_valor,
    String Dal_usubdd,
    DateTime Dal_datcri,
    DateTime Dal_datalt,
    int Dal_usucri,
    int Dal_usualt
);