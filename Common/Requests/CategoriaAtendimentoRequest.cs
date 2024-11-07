namespace Common.Requests;

public record CreateCategoriaAtendimento(        
    int Cat_catpai,
    int Cat_nivel,
    String Cat_valor,
    String Cat_usubdd,
    int Cat_usucri,
    int Cat_usualt,
    DateTime Cat_datcri, 
    DateTime Cat_datalt 
);

public record UpdateCategoriaAtendimento(
    int Id,
    int Cat_catpai,
    int Cat_nivel,
    String Cat_valor,
    String Cat_usubdd,
    int Cat_usucri,
    int Cat_usualt,
    DateTime Cat_datcri,
    DateTime Cat_datalt
);